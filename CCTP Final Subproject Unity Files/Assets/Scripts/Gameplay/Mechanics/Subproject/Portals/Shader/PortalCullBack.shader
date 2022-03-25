Shader "Unlit/PortalCullBack"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Transparent"}
		LOD 100
		cull back
		ZTest Less
		ZWrite On
		
		// Fog{ Mode Off }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#pragma multi_compile_fog


			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct Vertex2Fragment
			{
				float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD0;
				
				UNITY_FOG_COORDS(1)
			};

			sampler2D _MainTex;
			
			Vertex2Fragment vert (appdata v)
			{
				Vertex2Fragment vertex2Fragment;
				vertex2Fragment.vertex = UnityObjectToClipPos(v.vertex);
				vertex2Fragment.screenPos = ComputeScreenPos(vertex2Fragment.vertex);

				UNITY_TRANSFER_FOG(vertex2Fragment, vertex2Fragment.vertex);

				return vertex2Fragment;
			}
			
			fixed4 frag (Vertex2Fragment i) : SV_Target
			{
				float2 uv = i.screenPos.xy / i.screenPos.w;
				fixed4 col = tex2D(_MainTex, uv);

				UNITY_APPLY_FOG(i.fogCoord, col);
				UNITY_OPAQUE_ALPHA(col.a);

                return col;
			}
			ENDCG
		}
	}
}
