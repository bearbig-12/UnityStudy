Shader "Custom/TransformMatrixShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1, 1, 1, 1)
    
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            // Propertices
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;


            //  변환 행렬들 (DiceCreator 스크립트에서 전달)
            float4x4 _WorldMatrix;  //  월드 변환 행렬
            float4x4 _ViewMatrix;   // 카메라(뷰) 변환 행렬
            float4x4 _ProjectionMatrix;     // 투영 변환 행렬

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;

                // 로컬 -> 월드 , 월드변환
                float4 worldPos = mul(_WorldMatrix, v.vertex);

                // 월드 -> 카메라, 카메라변환
                float4 viewPos = mul(_ViewMatrix, worldPos);

                //  카메라공간 -> 클립공간 , 투영변환
                float4 clipPos = mul(_ProjectionMatrix, viewPos);

                o.pos = clipPos;

                // UV 좌표                
                o.uv = TRANSFORM_TEX(v.uv, _MainTex); 

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;

                return col;
            }
            ENDCG
        }
    }
}
