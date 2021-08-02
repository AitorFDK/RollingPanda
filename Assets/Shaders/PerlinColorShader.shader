// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/PerlinColorShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (0,0,0,0)
        _SaturationScaler ("Saturation Scaler", Float) = 1
        _BrightnessScaler ("Brightness Scaler", Float) = 1
        _Levels ("Illumination Levels", Int) = 8
    }
    SubShader
    {
        Tags { "LightMode" = "ForwardBase" }
        LOD 100

        Pass
        {
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
            #pragma multi_compile_fwdbase

            #include "UnityCG.cginc"
            #include "colorspaces.cginc"
            #include "AutoLight.cginc"

            struct appdata
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                LIGHTING_COORDS(0,1)
                float4 pos : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;
            float _SaturationScaler;
            float _BrightnessScaler;
            int _Levels;
            float4 _MainTex_ST;
            

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.pos);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o);
                return o;
            }

            float luminance (float3 rgb) {
                return 0.216*rgb.r + 0.7152*rgb.g + 0.0722*rgb.b;
            }

            float4 frag (v2f i) : SV_Target
            {
                // 0 . Obtener textura perlin
                float4 col = tex2D(_MainTex, i.uv);

                // 1 . Limitar los colores oscuros del perlin noise
                if (col.x < .4 & col.y < .4 & col.z < .4) {
                    col.xyz += float3(.2,.2,.2);
                }

                // 2 . Multiplicar por el color definido
                col.xyz *= _Color.xyz;

                // 3 . Covnertir el resultado a hsv
                float3 hsv = rgb_to_hsv(col.xyz);

                // 4 . Multiplicar las escalas de saturacion y brillo
                hsv.y *= _SaturationScaler;
                hsv.z *= _BrightnessScaler;

                col.xyz = hsv_to_rgb(hsv);
                
                // 5 . Reducir la iluminacion a los niveles definidos
                float luminance_orig = luminance(col);
                float luminance_new = floor(luminance_orig * _Levels) / _Levels;
                col.rgb *= luminance_new / luminance_orig;

                // 6 . Aplicar las sombras suavizadas
                float attenuation = LIGHT_ATTENUATION(i);
                return lerp(lerp(col, _Color, .7), attenuation, .1);
            }
            ENDCG
        }
    }

    Fallback "VertexLit"
    
}
