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
        // �������ۿ� �Է��� ���� ����Ÿ
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

        // �ε������ۿ� ������ �ﰢ�� Data
        int[] triangles =
        {
            0, 1, 3,   // �ٵ� ����
            0, 3, 4,   // �ٵ� ������
            1, 2, 3    // ����
        };
        // uv ��ǥ�� ������ Data
        Vector2[] uvs =
    {
            new Vector2(0f, 0f),   // v0
            new Vector2(0f, 0.75f),// v1 (���� ���� ����)
            new Vector2(0.5f, 1f), // v2
            new Vector2(1f, 0.75f),// v3
            new Vector2(1f, 0f)    // v4
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;   // �������ۿ� ���� ����Ÿ����
        mesh.triangles = triangles; // �ε������ۿ� �ﰢ�� ���� ����
        mesh.uv = uvs;  // �ﰢ���� ���� Texture uv ��ǥ�� ���� ����

        GetComponent<MeshFilter>().mesh = mesh; // MeshFilter ������Ʈ�� ������ �޽����� ����

        Material material = new Material(Shader.Find("Standard"));  // ���� ������ ����

        GetComponent<MeshRenderer>().material = material;

        material.SetTexture("_MainTex", _texture);





    }

    // Update is called once per frame
    void Update()
    {

    }
}
