Shader "Custom/FourColorGradient"
{
    Properties
    {
        _Color1("Color 1", Color) = (1, 0, 0, 1)  // 빨강
        _Color2("Color 2", Color) = (0, 1, 0, 1)  // 초록
        _Color3("Color 3", Color) = (0, 0, 1, 1)  // 파랑
        _Color4("Color 4", Color) = (1, 1, 0, 1)  // 노랑
        _Range1("Range 1", Range(0, 1)) = 0.25    // 첫 번째 색상 범위
        _Range2("Range 2", Range(0, 1)) = 0.5     // 두 번째 색상 범위
        _Range3("Range 3", Range(0, 1)) = 0.75    // 세 번째 색상 범위
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
                o.uv = v.vertex.xy * 0.5 + 0.5; // 0~1의 UV 좌표로 변환
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                // 그라데이션의 위치는 UV 좌표의 y 값을 기준으로 결정
                float gradientPosition = i.uv.y;

            // 첫 번째 범위 내에서는 Color1 -> Color2 그라데이션
            if (gradientPosition < _Range1)
            {
                float t = gradientPosition / _Range1;
                return lerp(_Color1, _Color2, t);
            }
            // 두 번째 범위 내에서는 Color2 -> Color3 그라데이션
            else if (gradientPosition < _Range2)
            {
                float t = (gradientPosition - _Range1) / (_Range2 - _Range1);
                return lerp(_Color2, _Color3, t);
            }
            // 세 번째 범위 내에서는 Color3 -> Color4 그라데이션
            else if (gradientPosition < _Range3)
            {
                float t = (gradientPosition - _Range2) / (_Range3 - _Range2);
                return lerp(_Color3, _Color4, t);
            }
            // 마지막은 Color4로 설정
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
