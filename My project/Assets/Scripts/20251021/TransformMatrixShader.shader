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


            //  ��ȯ ��ĵ� (DiceCreator ��ũ��Ʈ���� ����)
            float4x4 _WorldMatrix;  //  ���� ��ȯ ���
            float4x4 _ViewMatrix;   // ī�޶�(��) ��ȯ ���
            float4x4 _ProjectionMatrix;     // ���� ��ȯ ���

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

                // ���� -> ���� , ���庯ȯ
                float4 worldPos = mul(_WorldMatrix, v.vertex);

                // ���� -> ī�޶�, ī�޶�ȯ
                float4 viewPos = mul(_ViewMatrix, worldPos);

                //  ī�޶���� -> Ŭ������ , ������ȯ
                float4 clipPos = mul(_ProjectionMatrix, viewPos);

                o.pos = clipPos;

                // UV ��ǥ                
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
