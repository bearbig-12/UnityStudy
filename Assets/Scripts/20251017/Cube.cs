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
        // 정점버퍼에 입력할 정점.
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

        // 인덱스 버퍼에 저장할 Data
        int[] triangles = new int[]
        {
            // 앞
            0, 1, 2,
            2, 3, 0,

           // 뒤
           7,6,5,
           5,4,7,

           // 왼
           0,4,5,
           5,1,0,

           // 오
           3,2,6,
           6,7,3,

           // 위
           1,5,6,
           6,2,1,

           ////아래
           0,3,7,
           7,4,0


        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices; // 정점버퍼에 정점 데이타 전달
        mesh.triangles = triangles; // 인덱스버퍼에 폴리곤(삼각형)의 인덱스값을 전달

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
