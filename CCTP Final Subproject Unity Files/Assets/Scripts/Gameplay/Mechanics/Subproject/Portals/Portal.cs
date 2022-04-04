using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using RenderPipeline = UnityEngine.Rendering.RenderPipelineManager;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
[RequireComponent(typeof(Collider))]
public class Portal : MonoBehaviour
{
	// Base variables required
	private Camera mainCamera; // For referencing the player camera in this script
	private Camera portalCamera; // For referencing the created portal camera

	// Essentials for portal functioning
	[Header ("Essentials")]
	[Tooltip ("Link the two connected portals")]
	public Portal linkedPortal;
	private RenderTexture[] iterationRender;

	// Create variables for portal render
	[Header ("Portal Rendering")]
	[Tooltip ("Amount of times a portal can render another portal")]
	public int portalIterations = 1; // Set the desired amount of portal iterations
	private MeshRenderer portalScreen; // Used as the portal screen material

	[Header ("Advanced Portal Rendering")]
    public float nearClipOffset = 0.2f;
    public float nearClipLimit = 0.3f;

	[Header ("Portal Movement")]
	private List<PortalObject> portalObjects = new List<PortalObject>(); // Create a list that will record gameobjects entering portals

	[Header ("Helpful")]
	[Tooltip ("Will draw a line between connected portals for visual aid.")]
	public Color portalLineInEditor = Color.green;



	private RenderTexture tempTexture1;
	private float portalToPlayerDistance = 0;
	public float activateDistance = 20.0f;
	

	// Awake is called when the script instance is being loaded
	private void Awake()
	{
		/* VISUALS */
		mainCamera = Camera.main; // Set mainCamera variable to mean the player camera
		portalCamera = GetComponentInChildren <Camera>(); // Set portalCamera to portal
		portalScreen = GetComponent <MeshRenderer>(); // Get portal screen for rendering


		tempTexture1 = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
	}

	// Start is called before the first frame update
	void Start()
	{
		/* VISUALS */

		portalScreen.material.mainTexture = tempTexture1;
	}

	// Update is called once per frame
	private void LateUpdate()
	{
		/* COLLISIONS */
		PortalMovement();

		if (linkedPortal == null)
		{
			gameObject.SetActive (false);
		}
	}

	/* VISUALS */

	private void OnWillRenderObject() 
	{
		PreparePortalCameras();
	}

	private void PreparePortalCameras ()
	{
		// Check that the gameobject this script is attached to is active. Used just in case something calls the script when it shouldn't
		if (!gameObject.activeInHierarchy)
		{
			return;
		}

		portalToPlayerDistance = Vector3.Distance (mainCamera.transform.position, transform.position);

		if (portalScreen.isVisible && portalToPlayerDistance < activateDistance)
		{
			portalCamera.targetTexture = tempTexture1;

			for (int i = portalIterations - 1; i >= 0; i--)
			{
				BeginPortalCamera (i);
			}
		}
	}

	// This function handles the visuals. It moves the portal cameras to match the player's P.O.V. and clip out anything that shouldn't be seen.
	private void BeginPortalCamera (int iterationID)
	{
		// Clear the portal view of backside of portals
		int excludePortal = (gameObject.layer == 11) ? 12 : 11;
		portalCamera.cullingMask = ~(1 << excludePortal);

        for(int i = 0; i <= iterationID; ++i)
        {
			PortalCameraTransform();
        }

		CameraClipping ();
	}

	private void PortalCameraTransform ()
	{
		// Check to make sure that the camera transforms aren't changing when they don't need to be
		Vector3 camToPortal = transform.InverseTransformPoint (mainCamera.transform.position);

		if (camToPortal.z < 0.0f)
		{
			// Reposition the portal camera so that the offsets match angles at each portal
			Transform portalCameraTransform = portalCamera.transform;
			portalCameraTransform.position  = mainCamera.transform.position;
			portalCameraTransform.rotation  = mainCamera.transform.rotation;
			
			// Positioning
			Vector3 relativePosition = transform.InverseTransformPoint (portalCamera.transform.position); // Convert portal camera's position from world space to the portal's local space
			relativePosition = Quaternion.Euler (0.0f, 180.0f, 0.0f) * relativePosition; // Rotate around y-axis by 180 degrees to move behind the other portal
			portalCameraTransform.position = linkedPortal.transform.TransformPoint (relativePosition); // With the camera in the correct relative position, set the portal camera's transform back into world space using the other portal

			// Rotating
			Quaternion relativeRotation = Quaternion.Inverse (transform.rotation) * portalCameraTransform.rotation; // Convert portal camera's rotation from world space to the portals local space
			relativeRotation = Quaternion.Euler (0.0f, 180.0f, 0.0f) * relativeRotation; // Rotate y-axis by 180 degrees to have the portal camera looking at the other portal
			portalCameraTransform.rotation = linkedPortal.transform.rotation * relativeRotation; // With the camera in the correct relative rotation, set the portal camera's rotation back into world space
		}
	}

	private void CameraClipping ()
	{
		// Define the camera's clip plane in world space by converting a defined plane object into a Vector4
		Plane plane = new Plane (-linkedPortal.transform.forward, linkedPortal.transform.position);

		float distance = plane.distance + nearClipOffset;

		float planeToPlayerDistance = Vector3.Distance (mainCamera.transform.position, linkedPortal.transform.position);

		Vector4 clipPlaneWorldSpace = new Vector4 (plane.normal.x, plane.normal.y, plane.normal.z, distance); // Via normal distance format, get the defined plane transform for calculations

		// If camera is not close to portal then use oblique matrix
		if (Mathf.Abs (planeToPlayerDistance) > (nearClipOffset)) 
		{
			// Convert from world space to camera space by getting the inverse transposr of the camera's worldToCameraMatrix and then use that to multiply the world space clip plane.
			Vector4 clipPlaneCameraSpace = Matrix4x4.Transpose (Matrix4x4.Inverse (portalCamera.worldToCameraMatrix)) * clipPlaneWorldSpace; 

			// Set the camera's oblique view with the defined clip plane vector 4
			var cameraMatrix = mainCamera.CalculateObliqueMatrix (clipPlaneCameraSpace);
			portalCamera.projectionMatrix = cameraMatrix;
		} 
		else 
		{
			portalCamera.projectionMatrix = mainCamera.projectionMatrix;
		}
	}

	/* COLLISIONS */
	private void PortalMovement()
	{
		for (int i = 0; i < portalObjects.Count; i++)
		{
			PortalObject portalObject = portalObjects [i];
            Transform portalObjectChild = portalObject.transform.GetChild(0);

			Quaternion halfTurn = Quaternion.Euler (0.0f, 180.0f, 0.0f); // halfTurn is required to have player facing the correct direction after teleportation

			// Update position of portal object.
			Vector3 relativePos = transform.InverseTransformPoint (portalObject.transform.position); // Get local position of the portal object
			relativePos = halfTurn * relativePos; // Apply the halfTurn to portal object's transform position
			Vector3 teleportPosition = linkedPortal.transform.TransformPoint (relativePos); // Establish world space transform for portal object now that halfturn is applied

			// Update rotation of portal object.
			Quaternion relativeRot = Quaternion.Inverse (transform.rotation) * portalObjectChild.rotation; // Get the opposite rotation of current rotation
			relativeRot = halfTurn * relativeRot; // Apply the halfTurn to portal object's inverse transform rotation
			Quaternion teleportRotation = linkedPortal.transform.rotation * relativeRot; // Establish rotation variable for correct way to face after teleportation

			Vector3 offsetFromPortal = portalObject.transform.position - transform.position; // Record where the portal object is in regards to the portal

			// Record if portal object has crossed from one side of the portal to the other
			float preTeleportDot = System.Math.Sign (Vector3.Dot (offsetFromPortal, transform.forward));
            float postTeleportDot = System.Math.Sign (Vector3.Dot (portalObject.previousOffsetFromPortal, transform.forward));

			// If portal object has crossed, then teleport. If not then update previous portal offset
			if ((preTeleportDot < 0) != (postTeleportDot < 0))
			{
				portalObject.Teleport (transform, linkedPortal.transform, teleportPosition, teleportRotation); // Teleport the portal object

				// This is required to ensure portal enter/exit tracking occurs in LateUpdate() due to complications with Character Controller
				linkedPortal.OnEnterPortal (portalObject); 
				portalObjects.RemoveAt (i);
				i--;
			}
			else
			{
				portalObject.previousOffsetFromPortal = offsetFromPortal;
			}
		}
	}

	// Record when a portal object enters the portal collision space
	private void OnTriggerEnter(Collider other)
	{
		// Check that other is a portal object. Avoid requiring to add a tag to portal objects (Player follows player tag, so it simplifies things)
		if (other.GetComponent<PortalObject>() != null)
		{
			PortalObject portalObject = other.GetComponent<PortalObject>();

			if (portalObject)
			{
				OnEnterPortal (portalObject);
			}
		}
	}

	// Record portal object location and add portal object to list
	private void OnEnterPortal (PortalObject portalObject)
	{
		if (!portalObjects.Contains (portalObject))
		{
			portalObject.previousOffsetFromPortal = portalObject.transform.position - transform.position;

			portalObjects.Add(portalObject); // Add portal object to list of Portal Objects as it is attempting to teleport
		}
	}

	// Record when a portal object leaves the portal collision space
	private void OnTriggerExit(Collider other)
	{
		// Check that other is a portal object. Avoid requiring to add a tag to portal objects (Player follows player tag, so it simplifies things)
		if (other.GetComponent<PortalObject>() != null)
		{
			PortalObject portalObject = other.GetComponent<PortalObject>();

			if(portalObject && portalObjects.Contains(portalObject))
			{
				portalObjects.Remove(portalObject); // Remove portal object from list of Portal Objects as it is no longer attempting to teleport
			}
		}
	}

	private void OnDrawGizmos()
	{	
		if (linkedPortal != null)
		{
			portalLineInEditor.a = 1f;
			Gizmos.color = portalLineInEditor;
			Gizmos.DrawLine (transform.position, linkedPortal.transform.position);
		}
	}
}
