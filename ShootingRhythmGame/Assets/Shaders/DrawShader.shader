Shader "Custom/Draw"
{
	Properties
	{
		[PerRenderData] _MainTex("Sprite Texture", 2D) = "white" {}
		_X("X", float) = 0
		_Y("Y", float) = 0
	}
	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
		}

		Cull off
		Lighting off

		ZWrite off
		Fog { Mode off }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"


			struct appdata_t
			{
				float4 vertex : POSITION;
				// 텍스쳐의 값
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				// -6만 ~ 6만
				half2 texcoord : TEXCOORD0;
			};

			//함수
			v2f vert(appdata_t IN)
			{
				v2f OUT;

				//좌표계 변환
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;

				return OUT;
			}

			//위에 있는 것과 밑에 있는거 맞춰주기
			//sampler2D 로 이미지를 담을 수 있음
			sampler2D _MainTex;
			float _X;
			float _Y;

			// 픽셀 쉐이더
			float4 frag(v2f IN) : COLOR
			{
				float4 texcol = tex2D(_MainTex, IN.texcoord);
				float a = texcol.a;
				float x = step(IN.texcoord.x, _X);
				float y = step(IN.texcoord.y, _Y);
	
				texcol.a = lerp(0, a, min(x, y));
				return texcol;
			}
			ENDCG
		}
	}
}