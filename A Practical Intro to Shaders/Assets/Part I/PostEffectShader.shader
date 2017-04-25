Shader "Custom/PostEffectShader"
{
	Properties
	{
		_MainTex ("Main Texture", 2D) = "white" {}
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
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				// You could make some data here
			};

			// Is called once at each vertece on the object that this shader is attached to
			// It's good to manipulate thing based on his vertices
			// Example: distorce an especific object
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			// This is being called for each pixel on each frame
			// We could manipulate each pixel affected by our shader from here
			fixed4 frag (v2f input) : SV_Target
			{
				// For a full screen effect, it will have to be called 1960 x 1080 = about 2 million pixels!

				fixed4 col = tex2D(_MainTex, input.uv + float2(0, sin(input.vertex.x/25 + _Time[1]) / 100 ) );
				// input.uv gives the coordinates of each pixel at the main texture
				// OBS: _Time[n] will be always zero on editor mode
				// _MainTex is the default texture for full screen, it's not applied for an especific object
				// For a non-full-screen effect, said, a one-unique-object effect, we could use GRAB PASS (google it!)

				// We coulg just invert the colors
				//col = 1 - col;
				// or, for the same effect,
				//col.r = 1 - col.r;
				//col.g = 1 - col.g;
				//col.b = 1 - col.b;


				// or we could just turn thing a little bit more red!
				//col.r = 1;

				return col;
			}
			ENDCG
		}
	}
}
