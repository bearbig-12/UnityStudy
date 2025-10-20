Shader "Custom/RotateShader"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
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
            #include "UnityCG.cginc"

            fixed4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };


            v2f vert (appdata v)
            {
                v2f o;

                // ȸ���ӵ�
                float t = _Time.y * 1.0;

                // ũ�⺯ȯ���
                float4x4 scaleMatrix = float4x4( 
                    2, 0, 0, 0,
                    0, 2, 0, 0,
                    0, 0, 2, 0,
                    0, 0, 0, 1
                );

                //
                float c = cos(t);
                float s = sin(t);

                // Y�� ���� ȸ�� ���
                float4x4 rotationY = float4x4( 
                    c, 0, s, 0,
                    0, 1, 0, 0,
                    -s, 0, c, 0,
                    0, 0, 0, 1
                );

                // X�� ���� ȸ�� ���
                float4x4 rotationX = float4x4(
                    1, 0, 0, 0,
                    0, c, s, 0,
                    0, -s, c, 0,
                    0, 0, 0, 1
                );

                // Z�� ���� ȸ�� ���
                float4x4 rotationZ = float4x4(
                    c, s, 0, 0,
                    -s, c, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1
                );

                // ������Ʈ ���� -> ������ǥ��ȯ
                float4 worldPos = mul(unity_ObjectToWorld, v.vertex);

                // ũ�⺯ȯ���
                worldPos = mul(scaleMatrix, worldPos);

                // ����ȸ��
                worldPos = mul(rotationX, worldPos);

                // ������ǥ -> Ŭ����ǥ�� ��ȯ
                o.vertex = mul(UNITY_MATRIX_VP, worldPos);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
}
