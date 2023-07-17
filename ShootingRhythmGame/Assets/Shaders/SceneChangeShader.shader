Shader "Custom/SceneChange"
{
	Properties
	{
		[PerRenderData] _MainTex("Sprite Texture", 2D) = "white" {}
		_X("X", float) = 0
		_Y("Y", float) = 0
		_Fill("Fill", float) = 0
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
				// �ؽ����� ��
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				// -6�� ~ 6��
				half2 texcoord : TEXCOORD0;
			};

			//�Լ�
			v2f vert(appdata_t IN)
			{
				v2f OUT;

				//��ǥ�� ��ȯ
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;

				return OUT;
			}

			//���� �ִ� �Ͱ� �ؿ� �ִ°� �����ֱ�
			//sampler2D �� �̹����� ���� �� ����
			sampler2D _MainTex;
			float _X;
			float _Y;
			float _Fill;

			// �ȼ� ���̴�
			float4 frag(v2f IN) : COLOR
			{
				float4 texcol = tex2D(_MainTex, IN.texcoord);
				float a = texcol.a;
				float x = lerp(0, _X, _Fill);
				float y = lerp(0, _Y, 1 - _Fill);
				
				float xCheck = step(texcol.x, x);
				float yCheck = step(texcol.y, y);
	
				texcol.a = lerp(0, a, min(xCheck, yCheck));
				return texcol;
			}
			ENDCG
		}
	}
}