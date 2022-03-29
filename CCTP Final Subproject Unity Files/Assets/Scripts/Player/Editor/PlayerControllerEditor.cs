using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    PlayerController editScript;
    bool showNoConflictMenus;

    // Conditional variables
    bool sphericalWallWalk = false;

    public override void OnInspectorGUI()
    {
        editScript = target as PlayerController;

        base.OnInspectorGUI();

        EditorGUILayout.Space();
        GUILayout.Label ("Extra Movement Options", EditorStyles.boldLabel);

        SphericalMovement();
        WallWalking();

        EditorGUILayout.Space();
        GUILayout.Label ("Extra Visual Options", EditorStyles.boldLabel);

        DissolvingFloor();
        InsideSphere();

        EditorGUILayout.Space();
        GUILayout.Label ("Extra Options", EditorStyles.boldLabel);

        Shooting();
    }

    private void SphericalMovement()
    {
        // BOOL SPHERICALMOVEMENT (header)
        editScript.sphericalMovement = EditorGUILayout.Toggle (new GUIContent ("Spherical Movement", "Enable Planet-Based Movement?"), editScript.sphericalMovement);

        if (editScript.sphericalMovement)
        {
            // GAMEOBJECT PLANETGAMEOBJECT
            editScript.planetGameObject = EditorGUILayout.ObjectField (new GUIContent ("Planet GameObject", "Object for planet-based gravity."), editScript.planetGameObject, typeof (GameObject),  true) as GameObject;
        }
    }

    private void WallWalking()
    {
        // BOOL WALLWALK (header)
        editScript.wallWalk = EditorGUILayout.Toggle (new GUIContent ("Wall Walking", "Enable Wall-Based Movement?"), editScript.wallWalk);

        if (editScript.wallWalk)
        {
            // FLOAT GRAVITYROTATIONSPEED
            editScript.gravityRotationSpeed = EditorGUILayout.FloatField (new GUIContent ("Gravity Rotation Speed", "Set the rotation speed of the player to the wall."), editScript.gravityRotationSpeed);

            // FLOAT WALLDETECTION
            editScript.wallWalkDetection = EditorGUILayout.FloatField (new GUIContent ("Wall Walk Detection Range", "Set range of the collision detection raycasts."), editScript.wallWalkDetection);
        }
    }

    private void DissolvingFloor()
    {
        // BOOL DISSOLVINGFLOOR (header) 
        editScript.dissolvingFloor = EditorGUILayout.Toggle (new GUIContent ("Dissolving Floor VFX", "Enable the dissolving floor visual effect"), editScript.dissolvingFloor);
        
        if (editScript.dissolvingFloor)
        {

        }
    }

    private void InsideSphere()
    {
        // BOOL INSIDESPHERE (header)
        editScript.insideSphere = EditorGUILayout.Toggle (new GUIContent ("Inside Sphere VFX", "Enable the inner sphere visual effect"), editScript.insideSphere);

        if (editScript.insideSphere)
        {
            editScript.insideSphereRadius = EditorGUILayout.FloatField (new GUIContent ("VFX Radius", "Set the sight radius."), editScript.insideSphereRadius);
        }
    }

    private void Shooting()
    {
        // BOOL SHOOTING (header)
        editScript.enableShooting = EditorGUILayout.Toggle (new GUIContent ("Enable Shooting"), editScript.enableShooting);

        if (editScript.enableShooting)
        {
            // RIGIDBODY PROJECTILE
            editScript.projectileRigidbody = EditorGUILayout.ObjectField (new GUIContent ("Bullet GameObject", "The bullet rigidbody."), editScript.projectileRigidbody, typeof (Rigidbody), true) as Rigidbody;

            // FLOAT PROJECTILESPEED
            editScript.projectileSpeed = EditorGUILayout.FloatField (new GUIContent ("Projectile shoot speed", "Set speed of the projectile after firing."), editScript.projectileSpeed);
        }
    }
}
