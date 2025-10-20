using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    float _rotSpeed = 40.0f;
    float _angle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        MakeRectangle();
    }

    void MakeRectangle()
    {
        // �������ۿ� �Է��� ����.
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0.0f, 0.0f, 0.0f), // 0
            new Vector3(0.0f, 1.0f, 0.0f),  // 1
            new Vector3(1.0f, 1.0f, 0.0f),  // 2
            new Vector3(1.0f, 0.0f, 0.0f),  // 3


            new Vector3(0.0f, 0.0f, 1.0f),  // 4
            new Vector3(0.0f, 1.0f, 1.0f),  // 5
            new Vector3(1.0f, 1.0f, 1.0f),  // 6
            new Vector3(1.0f, 0.0f, 1.0f),  // 7
        };

        // �ε��� ���ۿ� ������ Data
        int[] triangles = new int[]
        {
            // ��
            0, 1, 2,
            2, 3, 0,

           // ��
           7,6,5,
           5,4,7,

           // ��
           0,4,5,
           5,1,0,

           // ��
           3,2,6,
           6,7,3,

           // ��
           1,5,6,
           6,2,1,

           ////�Ʒ�
           0,3,7,
           7,4,0


        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices; // �������ۿ� ���� ����Ÿ ����
        mesh.triangles = triangles; // �ε������ۿ� ������(�ﰢ��)�� �ε������� ����

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        Material material = new Material(Shader.Find("Standard"));

        GetComponent<MeshRenderer>().material = material;

    }



    // Update is called once per frame
    void Update()
    {
        //_angle += Time.deltaTime * _rotSpeed;
        //this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, _angle);
    }
}
