Shader "Hidden/图片叠加"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlendTex ("Blend Texture", 2D) = "white" {}
        _Blend("Blend", Range(0,1)) = 0
    }
    SubShader
    {
        Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
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
            };
 
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            sampler2D _MainTex;
            sampler2D _BlendTex;
            float _Blend;
 
            fixed4 frag (v2f i) : SV_Target
            {
                //获取两个贴图的颜色信息
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 blendcol = tex2D(_BlendTex, i.uv);
 
                //增加_Blend值控制第二张贴图的混合度
                //saturate限制到0-1
                float blend=saturate(blendcol.a-_Blend);
                //如果叠加贴图当前像素透明度为0，则取底图像素，否则取叠加图片的像素
                fixed4 color=col*(1-blend)*col.a+blendcol*blend;
 
                return color;
            }
            ENDCG
        }
    }
}