Shader "Custom/TransparentWaterShader"
{
    Properties
    {
        _Color ("Base Color", Color) = (0.0, 0.5, 0.8, 0.5) // 半透明の青
        _Glossiness ("Smoothness", Range(0,1)) = 0.8
        _Metallic ("Metallic", Range(0,1)) = 0.3
        _WaveSpeed ("Wave Speed", Range(0.1, 5.0)) = 1.0 // 波の速さ
        _WaveHeight ("Wave Height", Range(0.0, 1.0)) = 0.2 // 波の高さ
        _WaveFrequency ("Wave Frequency", Range(0.1, 5.0)) = 1.0 // 波の頻度
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200

        Blend SrcAlpha OneMinusSrcAlpha // アルファブレンドを有効化
        ZWrite Off // 透明な部分を正しく描画するために深度バッファを無効化

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade

        sampler2D _MainTex;
        fixed4 _Color;
        half _Glossiness;
        half _Metallic;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = _Color.rgb;
            o.Alpha = _Color.a; // 透明度を適用
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
        }
        ENDCG
    }
    FallBack "Transparent/Diffuse"
}
