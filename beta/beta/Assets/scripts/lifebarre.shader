Shader "Custom/lifebarre" {
   Properties //
   {
      _Color ("Main Color", Color) = (1,1,1,0.5)
      _CutValue ("Bar value", Range (0, 0.99)) = 0.99
      _MainTex ("Main Texture", 2D) = ""
      _Gradient ("Gradient", 2D) = ""
      _Border ("Border", 2D) = ""
    }
   SubShader
   {
         Blend SrcAlpha OneMinusSrcAlpha
         Tags {Queue=Transparent}
       
      Pass
      {
         CGPROGRAM
         #pragma vertex vert
         #pragma fragment frag
         #include "UnityCG.cginc"
         
         float4       _Color;
         float       _CutValue;
         sampler2D    _MainTex;
         sampler2D    _Gradient;
         sampler2D    _Border;
         
         uniform float4 _MainTex_ST;
         uniform float4 _Gradient_ST;
         uniform float4 _Border_ST;
         
         struct v2f {
             float4 pos : SV_POSITION;
            float2  UV_MainTex : TEXCOORD0;
            float2  UV_Gradient : TEXCOORD1;
            float2  UV_Border : TEXCOORD2;
         };
         
         v2f vert (appdata_base v)
         {
             v2f o;
             o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
             o.UV_MainTex = TRANSFORM_TEX (v.texcoord, _MainTex);
            o.UV_Gradient = TRANSFORM_TEX (v.texcoord, _Gradient);
            o.UV_Border = TRANSFORM_TEX (v.texcoord, _Border);
             return o;
         }
   
         half4 frag (v2f i) : COLOR
         {
            half4 borderColor = tex2D(_Border, i.UV_Border);
            half4 barColor = float4(0, 0, 0, 0);
            if (tex2D(_Gradient, i.UV_Gradient).x < _CutValue)
                 barColor = tex2D(_MainTex, i.UV_MainTex) * _Color;
             return barColor   (1 - borderColor.a) + borderColor  borderColor.a;
         }
         ENDCG
      }
   }
}