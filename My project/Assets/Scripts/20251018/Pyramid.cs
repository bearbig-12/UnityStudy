using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid: MonoBehaviour
{
    [SerializeField] private Texture _texture;

    float _rotSpeed = 40.0f;
    float _angle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        MakePyramid();
    }

    void MakePyramid()
    {
        // �������ۿ� �Է��� ����.
        // �ؽ��ĸ� ���� ���� 24��
        Vector3[] vertices = new Vector3[]
        {
            // ��
            new Vector3(0.0f, 0.0f, 0.0f), // 0
            new Vector3(0.5f, 1.0f, 0.5f),  // 1
            new Vector3(1.0f, 0.0f, 0.0f),  // 2

            // ��
            new Vector3(0.0f, 0.0f, 1.0f), // 3
            new Vector3(0.5f, 1.0f, 0.5f),  // 4
            new Vector3(1.0f, 0.0f, 1.0f),  // 5

            // �� 
            new Vector3(0.0f, 0.0f, 1.0f), // 6
            new Vector3(0.5f, 1.0f, 0.5f), // 7
            new Vector3(0.0f, 0.0f, 0.0f), // 8

            // �� 
            new Vector3(1.0f, 0.0f, 0.0f), // 9
            new Vector3(0.5f, 1.0f, 0.5f), // 10
            new Vector3(1.0f, 0.0f, 1.0f), // 11

        
            // �Ʒ� (
            new Vector3(0.0f, 0.0f, 0.0f), // 12
            new Vector3(0.0f, 0.0f, 1.0f), // 13
            new Vector3(1.0f, 0.0f, 1.0f), // 14
            new Vector3(1.0f, 0.0f, 0.0f), // 15
        };

        // �ε��� ���ۿ� ������ Data
        int[] triangles = new int[]
        {
            // �� 
            0, 1, 2,

            // �� 
            5,4,3,
            
            // �� 
            6, 7, 8,

            // �� 
            9,10,11,

   
            // �Ʒ� 
             12, 14, 13,   12, 15, 14


        };

        float h = 1f / 4f;
        float w = 1f / 4f;

        Vector2[] uvFull = new Vector2[16];
        // �� - 1
        uvFull[0] = new Vector2(w, 2 * h);
        uvFull[1] = new Vector2(1.5f * w, 3 * h);
        uvFull[2] = new Vector2(2 * w, 2 * h);

        // �� - 6
        uvFull[3] = new Vector2(w, 0f);
        uvFull[4] = new Vector2(0.5f * w, h);
        uvFull[5] = new Vector2(2 * w, 0f);

        // �� - 5
        uvFull[6] = new Vector2(0f, 0f);
        uvFull[7] = new Vector2(0.5f * w, h);
        uvFull[8] = new Vector2(w, 0f);

        //�� - 2
        uvFull[9] = new Vector2(2 * w, 0f);
        uvFull[10] = new Vector2(2.5f * w, h);
        uvFull[11] = new Vector2(3 * w, 0f);


        //�Ʒ� - 4
        uvFull[12] = new Vector2( w, 3 * h);
        uvFull[13] = new Vector2( w, 4 * h);
        uvFull[14] = new Vector2(2 * w, 4 * h);
        uvFull[15] = new Vector2(2 * w, 3 * h);




        Mesh mesh = new Mesh();
        mesh.vertices = vertices; // �������ۿ� ���� ����Ÿ ����
        mesh.triangles = triangles; // �ε������ۿ� ������(�ﰢ��)�� �ε������� ����
        mesh.uv = uvFull;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        Material material = new Material(Shader.Find("Standard"));
        material.mainTexture = _texture;

        GetComponent<MeshRenderer>().material = material;


    }



    // Update is called once per frame
    void Update()
    {
        //_angle += Time.deltaTime * _rotSpeed;
        //this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, _angle);
    }
}
