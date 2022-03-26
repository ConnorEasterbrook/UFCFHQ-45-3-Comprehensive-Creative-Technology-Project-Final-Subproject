Shader "Unlit/PortalCullBack"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { 
				"RenderType"="Transparent"
				"RenderPipeline"="UniversalPipeline"
			}

		LOD 100
		cull back
		ZTest Less
		ZWrite On

		HLSLINCLUDE
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
		ENDHLSL

		Pass
		{
			HLSLPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				struct appdata
				{
					float4 vertex : POSITION;
				};

				struct Vertex2Fragment
				{
					float4 vertex : SV_POSITION;
					float4 screenPos : TEXCOORD0;
				};

				uniform sampler2D _MainTex;
				
				Vertex2Fragment vert (appdata v)
				{
					Vertex2Fragment vertex2Fragment;
					vertex2Fragment.vertex = TransformObjectToHClip(v.vertex.xyz);
					vertex2Fragment.screenPos = ComputeScreenPos(vertex2Fragment.vertex);

					return vertex2Fragment;
				}
				
				float4 frag (Vertex2Fragment i) : SV_Target
				{
					float2 uv = i.screenPos.xy / i.screenPos.w;
					float4 col = tex2D(_MainTex, uv);

					return col;
				}
			ENDHLSL
		}
	}
}
