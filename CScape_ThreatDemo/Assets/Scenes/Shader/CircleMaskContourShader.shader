Shader "Custom/CircleMaskContourShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        _Radius("Radius", Range(0, 1)) = 0.5
        _Softness("Softness", Range(0, 1)) = 0.5
        _ContourColor("Contour Color", Color) = (0,0,0,1)
        _ContourThickness("Contour Thickness", Range(0, 0.5)) = 0.01
    }
        SubShader
        {
            Tags { "RenderType" = "Transparent" }
            LOD 100

            Pass
            {
                ZWrite Off
                Blend SrcAlpha OneMinusSrcAlpha

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
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _Color;
                float _Radius;
                float _Softness;
                float4 _ContourColor;
                float _ContourThickness;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float2 center = float2(0.5, 0.5);
                    float2 uv = i.uv - center;
                    float dist = length(uv);

                    // Center content calculation
                    float alpha = 1.0 - smoothstep(_Radius, _Radius, dist);
                    fixed4 texColor = tex2D(_MainTex, i.uv) * _Color;
                    texColor.a *= alpha;

                    // Contour calculation
                    float contourAlpha = smoothstep(_Radius - _ContourThickness, _Radius, dist) - smoothstep(_Radius, _Radius + _ContourThickness, dist);
                    fixed4 contourColor = _ContourColor;
                    contourColor.a = contourAlpha * _ContourColor.a;

                    // Blend center content with the contour 
                    // To ensure proper blending, the contour color is modulated by (1 - texColor.a), meaning the contour is only applied where the central content is not fully opaque.
                    // fixed4 result = texColor * texColor.a + contourColor * (1 - texColor.a);
                    fixed4 result = contourColor * (1 - texColor.a);

                    return result;
                }
                ENDCG
            }
        }
}