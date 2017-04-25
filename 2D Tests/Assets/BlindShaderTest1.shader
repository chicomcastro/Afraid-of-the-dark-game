Shader "Custom/BlindShaderTest1"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BackgroundTex ("Background Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;

				// For acess world position from input
				float4 worldPosition : TEXCOORD1;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			v2f vert (appdata v)
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				o.worldPosition = v.vertex;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _BackgroundTex;
			float _XCoordinate;
			float _YCoordinate;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col;

				if ((i.worldPosition.x - _XCoordinate)*(i.worldPosition.x - _XCoordinate)
				  + (i.worldPosition.y - _YCoordinate)*(i.worldPosition.y - _YCoordinate) < 0.05f
				  )
				{
					//col = tex2D(_MainTex, i.uv);
					col = tex2D(_BackgroundTex, i.uv);
					col = 1 - col;

				}
				else {
					col = 0; //tex2D(_MainTex, i.uv);
				}

				// just invert the colors

				//col = 1 - col;
				return col;
			}
			ENDCG
		}
	}
}
