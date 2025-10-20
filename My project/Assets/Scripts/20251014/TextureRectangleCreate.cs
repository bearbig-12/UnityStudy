using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureRectangleCreate : MonoBehaviour
{
    [SerializeField] private Texture _texture;


    // Start is called before the first frame update
    void Start()
    {
        MakeSquare();

    }

    void MakeSquare()
    {
        // 정점버퍼에 입력할 정점 데이타
        //Vector3[] vertices = new Vector3[]
        //{
        //    new Vector3(-1.0f, -1.0f, 0.0f), // 0
        //    new Vector3(-1.0f, 1.0f, 0.0f),  // 1
        //    new Vector3(1.0f, 1.0f, 0.0f),   // 2
        //    new Vector3(1.0f, -1.0f, 0.0f)   // 3
        //};

        Vector3[] vertices = new Vector3[]
    {
            new Vector3(-1.0f, -1.0f, 0.0f), // 0
            new Vector3(-1.0f, 1.0f, 0.0f),  // 1
            new Vector3(0.0f, 1.5f, 0.0f),   // 2
            new Vector3(1.0f, 1.0f, 0.0f),   // 3
            new Vector3(1.0f, -1.0f, 0.0f)   // 4
    };

        // 인덱스버퍼에 전달할 삼각형 Data
        int[] triangles =
        {
            0, 1, 3,   // 바디 왼쪽
            0, 3, 4,   // 바디 오른쪽
            1, 2, 3    // 지붕
        };
        // uv 좌표에 저장할 Data
        Vector2[] uvs =
    {
            new Vector2(0f, 0f),   // v0
            new Vector2(0f, 0.75f),// v1 (지붕 시작 높이)
            new Vector2(0.5f, 1f), // v2
            new Vector2(1f, 0.75f),// v3
            new Vector2(1f, 0f)    // v4
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;   // 정점버퍼에 정점 데이타전달
        mesh.triangles = triangles; // 인덱스버퍼에 삼각형 정보 전달
        mesh.uv = uvs;  // 삼각형에 입힐 Texture uv 좌표값 정보 전달

        GetComponent<MeshFilter>().mesh = mesh; // MeshFilter 컴포넌트에 구성된 메쉬정보 전달

        Material material = new Material(Shader.Find("Standard"));  // 면의 재질의 설정

        GetComponent<MeshRenderer>().material = material;

        material.SetTexture("_MainTex", _texture);





    }

    // Update is called once per frame
    void Update()
    {

    }
}
