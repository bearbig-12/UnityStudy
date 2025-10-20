using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TriangleCreate();

    }

    private void TriangleCreate()
    {
        // ���ؽ� ����(��������)
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1.0f, -1.0f, 0.0f), // 0
            new Vector3(0.0f, 1.0f, 0.0f),  // 1
            new Vector3(1.0f, -1.0f, 0.0f) // 2
        };


        // �ε�������
        int[] triangles = new int[] { 0, 1, 2 };

        Mesh mesh = new Mesh(); // �޽���ü�� ����
        mesh.vertices = vertices;   // ����� ���������� ���ؽ����ۿ� ����
        mesh.triangles = triangles; // �������ۿ� �Էµ� �������� �ﰢ���� � ������ �׸� �������� ���� ������ �ε��� ���ۿ� ����


        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh; // ����� �޽������͸� �޽����� ������Ʈ�� ����

        Material material = new Material(Shader.Find("Standard"));

        GetComponent<MeshRenderer>().material = material;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
