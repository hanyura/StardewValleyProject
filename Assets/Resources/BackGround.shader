Shader "Custom/FourColorGradient"
{
    Properties
    {
        _Color1("Color 1", Color) = (1, 0, 0, 1)  // ����
        _Color2("Color 2", Color) = (0, 1, 0, 1)  // �ʷ�
        _Color3("Color 3", Color) = (0, 0, 1, 1)  // �Ķ�
        _Color4("Color 4", Color) = (1, 1, 0, 1)  // ���
        _Range1("Range 1", Range(0, 1)) = 0.25    // ù ��° ���� ����
        _Range2("Range 2", Range(0, 1)) = 0.5     // �� ��° ���� ����
        _Range3("Range 3", Range(0, 1)) = 0.75    // �� ��° ���� ����
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            float4 _Color1;
            float4 _Color2;
            float4 _Color3;
            float4 _Color4;
            float _Range1;
            float _Range2;
            float _Range3;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy * 0.5 + 0.5; // 0~1�� UV ��ǥ�� ��ȯ
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                // �׶��̼��� ��ġ�� UV ��ǥ�� y ���� �������� ����
                float gradientPosition = i.uv.y;

            // ù ��° ���� �������� Color1 -> Color2 �׶��̼�
            if (gradientPosition < _Range1)
            {
                float t = gradientPosition / _Range1;
                return lerp(_Color1, _Color2, t);
            }
            // �� ��° ���� �������� Color2 -> Color3 �׶��̼�
            else if (gradientPosition < _Range2)
            {
                float t = (gradientPosition - _Range1) / (_Range2 - _Range1);
                return lerp(_Color2, _Color3, t);
            }
            // �� ��° ���� �������� Color3 -> Color4 �׶��̼�
            else if (gradientPosition < _Range3)
            {
                float t = (gradientPosition - _Range2) / (_Range3 - _Range2);
                return lerp(_Color3, _Color4, t);
            }
            // �������� Color4�� ����
            else
            {
                return _Color4;
            }
        }
        ENDCG
    }
    }
        FallBack "Diffuse"
}
