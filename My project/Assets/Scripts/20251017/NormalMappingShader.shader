Shader "Custom/NormalMappingShader"
{    
    Properties
    {
        _MainTex ("Albedo Texture", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _NormalStrength ("Normal Strength", Range(0, 2)) = 1.0
        _Color ("Color", Color) = (1,1,1,1)
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        Pass
        {
            Tags { "LightMode"="ForwardBase" }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            
            // Properties
            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NormalMap;
            float4 _NormalMap_ST;
            float _NormalStrength;
            fixed4 _Color;
            
            // Vertex Shader Input
            struct appdata
            {
                float4 vertex : POSITION;      // ���� ��ġ
                float3 normal : NORMAL;        // ���� ���
                float4 tangent : TANGENT;      // ���� ����
                float2 uv : TEXCOORD0;         // UV ��ǥ
            };
            
            // Vertex to Fragment
            struct v2f
            {
                float4 pos : SV_POSITION;      // Ŭ�� ���� ��ġ
                float2 uv : TEXCOORD0;         // ���� �ؽ�ó UV
                float2 uv_normal : TEXCOORD1;  // ��ָ� UV
                float3 worldPos : TEXCOORD2;   // ���� ��ġ
                float3 tspace0 : TEXCOORD3;    // TBN ��� ù��° ��
                float3 tspace1 : TEXCOORD4;    // TBN ��� �ι�° ��
                float3 tspace2 : TEXCOORD5;    // TBN ��� ����° ��
            };
            
            // Vertex Shader
            v2f vert(appdata v)
            {
                v2f o;
                
                // Ŭ�� ���� ��ġ ���
                o.pos = UnityObjectToClipPos(v.vertex);
                
                // UV ��ǥ ��ȯ (tiling, offset ����)
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv_normal = TRANSFORM_TEX(v.uv, _NormalMap);
                
                // ���� ���� ��ġ
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                
                // ���� ���� ���, ����, ������ ���
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;
                
                // TBN ����� �� ������ ���� (�޸� ȿ��)
                o.tspace0 = float3(worldTangent.x, worldBinormal.x, worldNormal.x);
                o.tspace1 = float3(worldTangent.y, worldBinormal.y, worldNormal.y);
                o.tspace2 = float3(worldTangent.z, worldBinormal.z, worldNormal.z);
                
                return o;
            }
            
            // Pixel/Fragment Shader
            fixed4 frag(v2f i) : SV_Target
            {
                // 1. ���� �ؽ�ó ���ø�
                fixed4 albedo = tex2D(_MainTex, i.uv) * _Color;
                
                // 2. ��ָ� ���ø�
                // ��ָ��� 0~1 �����̹Ƿ� -1~1 ������ ��ȯ
                fixed3 tangentNormal = UnpackNormal(tex2D(_NormalMap, i.uv_normal));
                
                // ��� ���� ����
                tangentNormal.xy *= _NormalStrength;
                
                // ��� ������ȭ (z ���� ����)
                tangentNormal.z = sqrt(1.0 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));
                
                // 3. ź��Ʈ ���� ����� ���� �������� ��ȯ
                // TBN ��� ����
                float3 worldNormal;
                worldNormal.x = dot(i.tspace0, tangentNormal);
                worldNormal.y = dot(i.tspace1, tangentNormal);
                worldNormal.z = dot(i.tspace2, tangentNormal);
                worldNormal = normalize(worldNormal);
                
                // 4. ���� ���
                // ���� �𷺼ų� ����Ʈ ����
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                
                // Diffuse (Lambert)
                float NdotL = max(0, dot(worldNormal, lightDir));
                fixed3 diffuse = albedo.rgb * _LightColor0.rgb * NdotL;
                
                // Ambient
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo.rgb;
                
                // 5. ���� ����
                fixed3 finalColor = ambient + diffuse;
                
                return fixed4(finalColor, albedo.a);
            }
            
            ENDCG
        }
    }
    
    FallBack "Diffuse"
}