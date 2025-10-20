using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Texture _texture;

    float _rotSpeed = 40.0f;
    float _angle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        MakeCube();
    }

    void MakeCube()
    {
        // �������ۿ� �Է��� ����.
        // �ؽ��ĸ� ���� ���� 24��
        Vector3[] vertices = new Vector3[]
        {
            // ��
            new Vector3(0.0f, 0.0f, 0.0f), // 0
            new Vector3(0.0f, 1.0f, 0.0f),  // 1
            new Vector3(1.0f, 1.0f, 0.0f),  // 2
            new Vector3(1.0f, 0.0f, 0.0f),  // 3

            // ��
            new Vector3(0.0f, 0.0f, 1.0f),  // 4
            new Vector3(0.0f, 1.0f, 1.0f),  // 5
            new Vector3(1.0f, 1.0f, 1.0f),  // 6
            new Vector3(1.0f, 0.0f, 1.0f),  // 7

            // �� 
            new Vector3(0.0f, 0.0f, 1.0f), // 8
            new Vector3(0.0f, 1.0f, 1.0f), // 9
            new Vector3(0.0f, 1.0f, 0.0f), // 10
            new Vector3(0.0f, 0.0f, 0.0f), // 11

            // �� 
            new Vector3(1.0f, 0.0f, 0.0f), // 12
            new Vector3(1.0f, 1.0f, 0.0f), // 13
            new Vector3(1.0f, 1.0f, 1.0f), // 14
            new Vector3(1.0f, 0.0f, 1.0f), // 15

            // �� 
            new Vector3(0.0f, 1.0f, 0.0f), // 16
            new Vector3(0.0f, 1.0f, 1.0f), // 17
            new Vector3(1.0f, 1.0f, 1.0f), // 18
            new Vector3(1.0f, 1.0f, 0.0f), // 19

            // �Ʒ� (
            new Vector3(0.0f, 0.0f, 1.0f), // 20
            new Vector3(0.0f, 0.0f, 0.0f), // 21
            new Vector3(1.0f, 0.0f, 0.0f), // 22
            new Vector3(1.0f, 0.0f, 1.0f), // 23
        };

        // �ε��� ���ۿ� ������ Data
        int[] triangles = new int[]
        {
            // �� 
            0, 1, 2,  0, 2, 3,

            // �� 
            5 ,4 ,7 , 5 ,7 ,6,
            
            // �� 
            8, 9, 10,  8, 10, 11,

            // �� 
            12, 13, 14,  12, 14, 15,

            // �� 
            16, 17, 18,  16, 18, 19,

            // �Ʒ� 
            20, 21, 22,  20, 22, 23,


        };

        //float h = 1f / 3f;
        //float w = 0.5f;

        //Vector2[] uvFull = new Vector2[24];
        //// �� - 1
        //uvFull[0] = new Vector2(0f, 2 * h); 
        //uvFull[1] = new Vector2(0f, 3 * h); 
        //uvFull[2] = new Vector2(w, 3 * h); 
        //uvFull[3] = new Vector2(w, 2 * h);

        //// �� - 6
        //uvFull[4] = new Vector2(w, 0f);
        //uvFull[5] = new Vector2(w, h);
        //uvFull[6] = new Vector2(2 * w, h);
        //uvFull[7] = new Vector2(2 * w, 0f);

        //// �� - 5
        //uvFull[8] = new Vector2(0f, 0f);
        //uvFull[9] = new Vector2(0f, h);
        //uvFull[10] = new Vector2(w, h);
        //uvFull[11] = new Vector2(w, 0f);

        ////�� - 2
        //uvFull[12] = new Vector2(w, 2 * h);
        //uvFull[13] = new Vector2(w, 3 * h);
        //uvFull[14] = new Vector2(2 * w, 3 * h);
        //uvFull[15] = new Vector2(2 * w, 2 * h);

        ////�� - 3
        //uvFull[16] = new Vector2(0f, h);
        //uvFull[17] = new Vector2(0, 2 * h);
        //uvFull[18] = new Vector2(w, 2 * h);
        //uvFull[19] = new Vector2(w, h);

        ////�Ʒ� - 4
        //uvFull[20] = new Vector2(w, h);
        //uvFull[21] = new Vector2(w, 2 * h);
        //uvFull[22] = new Vector2(2 * w, 2 * h);
        //uvFull[23] = new Vector2(2 * w, h);


        float h = 1f / 4f;
        float w = 1f / 4f;

        Vector2[] uvFull = new Vector2[24];
        // �� - 1
        uvFull[0] = new Vector2(w, 2 * h);
        uvFull[1] = new Vector2(w, 3 * h);
        uvFull[2] = new Vector2(2 * w, 3 * h);
        uvFull[3] = new Vector2(2 * w, 2 * h);

        // �� - 6
        uvFull[4] = new Vector2(w, 0f);
        uvFull[5] = new Vector2(w, h);
        uvFull[6] = new Vector2(2 * w, h);
        uvFull[7] = new Vector2(2 * w, 0f);

        // �� - 5
        uvFull[8] = new Vector2(0f, 0f);
        uvFull[9] = new Vector2(0f, h);
        uvFull[10] = new Vector2(w, h);
        uvFull[11] = new Vector2(w, 0f);

        //�� - 2
        uvFull[12] = new Vector2(2 * w, 0f);
        uvFull[13] = new Vector2(2 * w, h);
        uvFull[14] = new Vector2(3 * w, h);
        uvFull[15] = new Vector2(3 * w, 0f);

        //�� - 3
        uvFull[16] = new Vector2(w, h);
        uvFull[17] = new Vector2(w, 2 * h);
        uvFull[18] = new Vector2(2 * w, 2 * h);
        uvFull[19] = new Vector2(2 * w, h);

        //�Ʒ� - 4
        uvFull[20] = new Vector2(w, 3 * h);
        uvFull[21] = new Vector2(w, 4 * h);
        uvFull[22] = new Vector2(2 * w, 4 * h);
        uvFull[23] = new Vector2(2 * w, 3 * h);


        Mesh mesh = new Mesh();
        mesh.vertices = vertices; // �������ۿ� ���� ����Ÿ ����
        mesh.triangles = triangles; // �ε������ۿ� ������(�ﰢ��)�� �ε������� ����
        mesh.uv = uvFull;  // �ﰢ���� ���� Texture uv ��ǥ�� ���� ����

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
