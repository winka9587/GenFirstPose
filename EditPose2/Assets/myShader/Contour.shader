// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Contour"
{
    Properties
    {
		_Color("Color", Color) = (0.9,0.9,0.9,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Diffuse("Diffuse", Color) = (1,1,1,1)
		_ContourColor("Contour Color",Color) = (1,0.5,0.1,1)
		_ContourPower("Contour Power",range(0,1)) = 0.01
    }

	SubShader
	{
		Tags { "RenderType" = "Opaque"}
		LOD 100

		Pass
		{
			//ZWrite off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float3 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _AlphaTex;
			float4 _MainTex_ST;
			float _DisappearOffset;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv.z = o.vertex.y - _DisappearOffset;
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{

				clip(i.uv.z);
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv.xy);

				//fixed4 mAlpha = tex2D(_AlphaTex, i.uv.xy);
				//clip(mAlpha.r-0.5);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}

    FallBack "Diffuse"
}
