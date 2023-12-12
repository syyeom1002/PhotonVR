Shader "Custom/Outline"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Thickness ("Outline Thickness", Range(0, 0.5)) = 0.1
        _OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Cull Front

        //1pass 
        CGPROGRAM
        #pragma surface surf _NoLight vertex:vert 
        #pragma target 3.0

        float _Thickness;
        float4 _OutlineColor;

        void vert(inout appdata_full v)
        {
            v.vertex.xyz += v.normal.xyz * _Thickness;
        }

        struct Input
        {
            float4 color : COLOR;
           
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
           
        }

        float4 Lighting_NoLight(SurfaceOutput s, float3 lightDir, float atten)
        {
            return _OutlineColor;   
        }

        ENDCG

        //2pass

        Cull Back 

        CGPROGRAM
        #pragma surface surf Standard
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float4 color : COLOR;
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}