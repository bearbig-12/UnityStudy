using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Texture _texture;

    // Material
    [SerializeField] private Material _targetMaterial;

    // 월드변환
    public Vector3 _position = Vector3.zero;    //  이동 (translate)
    public Vector3 _rotation = Vector3.zero;    //  회전 (rotation) (euler angle)
    public Vector3 _scale = Vector3.one;        //  크기 (scale)

    // 카메라
    public Camera _targetCamera;

    public float _moveSpeed = 5.0f; //  이동 속도
    public float _rotationSpeed = 70.0f; //  회전 속도

    private Material materialInstance = null;  // Material

    // Start is called before the first frame update
    void Start()
    {
        MakeCube();

        if (_targetMaterial == null) // material
        {
            materialInstance = GetComponent<MeshRenderer>().material;
        }
    }
    void MakeCube()
    {
        // 정점버퍼에 입력할 정점.
        // 텍스쳐를 위한 정점 24개
        Vector3[] vertices = new Vector3[]
        {
            // 앞
            new Vector3(0.0f, 0.0f, 0.0f), // 0
            new Vector3(0.0f, 1.0f, 0.0f),  // 1
            new Vector3(1.0f, 1.0f, 0.0f),  // 2
            new Vector3(1.0f, 0.0f, 0.0f),  // 3

            // 뒤
            new Vector3(0.0f, 0.0f, 1.0f),  // 4
            new Vector3(0.0f, 1.0f, 1.0f),  // 5
            new Vector3(1.0f, 1.0f, 1.0f),  // 6
            new Vector3(1.0f, 0.0f, 1.0f),  // 7

            // 왼 
            new Vector3(0.0f, 0.0f, 1.0f), // 8
            new Vector3(0.0f, 1.0f, 1.0f), // 9
            new Vector3(0.0f, 1.0f, 0.0f), // 10
            new Vector3(0.0f, 0.0f, 0.0f), // 11

            // 오 
            new Vector3(1.0f, 0.0f, 0.0f), // 12
            new Vector3(1.0f, 1.0f, 0.0f), // 13
            new Vector3(1.0f, 1.0f, 1.0f), // 14
            new Vector3(1.0f, 0.0f, 1.0f), // 15

            // 위 
            new Vector3(0.0f, 1.0f, 0.0f), // 16
            new Vector3(0.0f, 1.0f, 1.0f), // 17
            new Vector3(1.0f, 1.0f, 1.0f), // 18
            new Vector3(1.0f, 1.0f, 0.0f), // 19

            // 아래 (
            new Vector3(0.0f, 0.0f, 1.0f), // 20
            new Vector3(0.0f, 0.0f, 0.0f), // 21
            new Vector3(1.0f, 0.0f, 0.0f), // 22
            new Vector3(1.0f, 0.0f, 1.0f), // 23
        };

        // 인덱스 버퍼에 저장할 Data
        int[] triangles = new int[]
        {
            // 앞 
            0, 1, 2,  0, 2, 3,

            // 뒤 
            5 ,4 ,7 , 5 ,7 ,6,
            
            // 왼 
            8, 9, 10,  8, 10, 11,

            // 오 
            12, 13, 14,  12, 14, 15,

            // 위 
            16, 17, 18,  16, 18, 19,

            // 아래 
            20, 21, 22,  20, 22, 23,


        };

        //float h = 1f / 3f;
        //float w = 0.5f;

        //Vector2[] uvFull = new Vector2[24];
        //// 앞 - 1
        //uvFull[0] = new Vector2(0f, 2 * h); 
        //uvFull[1] = new Vector2(0f, 3 * h); 
        //uvFull[2] = new Vector2(w, 3 * h); 
        //uvFull[3] = new Vector2(w, 2 * h);

        //// 뒤 - 6
        //uvFull[4] = new Vector2(w, 0f);
        //uvFull[5] = new Vector2(w, h);
        //uvFull[6] = new Vector2(2 * w, h);
        //uvFull[7] = new Vector2(2 * w, 0f);

        //// 왼 - 5
        //uvFull[8] = new Vector2(0f, 0f);
        //uvFull[9] = new Vector2(0f, h);
        //uvFull[10] = new Vector2(w, h);
        //uvFull[11] = new Vector2(w, 0f);

        ////오 - 2
        //uvFull[12] = new Vector2(w, 2 * h);
        //uvFull[13] = new Vector2(w, 3 * h);
        //uvFull[14] = new Vector2(2 * w, 3 * h);
        //uvFull[15] = new Vector2(2 * w, 2 * h);

        ////위 - 3
        //uvFull[16] = new Vector2(0f, h);
        //uvFull[17] = new Vector2(0, 2 * h);
        //uvFull[18] = new Vector2(w, 2 * h);
        //uvFull[19] = new Vector2(w, h);

        ////아래 - 4
        //uvFull[20] = new Vector2(w, h);
        //uvFull[21] = new Vector2(w, 2 * h);
        //uvFull[22] = new Vector2(2 * w, 2 * h);
        //uvFull[23] = new Vector2(2 * w, h);


        float h = 1f / 4f;
        float w = 1f / 4f;

        Vector2[] uvFull = new Vector2[24];
        // 앞 - 1
        uvFull[0] = new Vector2(w, 2 * h);
        uvFull[1] = new Vector2(w, 3 * h);
        uvFull[2] = new Vector2(2 * w, 3 * h);
        uvFull[3] = new Vector2(2 * w, 2 * h);

        // 뒤 - 6
        uvFull[4] = new Vector2(w, 0f);
        uvFull[5] = new Vector2(w, h);
        uvFull[6] = new Vector2(2 * w, h);
        uvFull[7] = new Vector2(2 * w, 0f);

        // 왼 - 5
        uvFull[8] = new Vector2(0f, 0f);
        uvFull[9] = new Vector2(0f, h);
        uvFull[10] = new Vector2(w, h);
        uvFull[11] = new Vector2(w, 0f);

        //오 - 2
        uvFull[12] = new Vector2(2 * w, 0f);
        uvFull[13] = new Vector2(2 * w, h);
        uvFull[14] = new Vector2(3 * w, h);
        uvFull[15] = new Vector2(3 * w, 0f);

        //위 - 3
        uvFull[16] = new Vector2(w, h);
        uvFull[17] = new Vector2(w, 2 * h);
        uvFull[18] = new Vector2(2 * w, 2 * h);
        uvFull[19] = new Vector2(2 * w, h);

        //아래 - 4
        uvFull[20] = new Vector2(w, 3 * h);
        uvFull[21] = new Vector2(w, 4 * h);
        uvFull[22] = new Vector2(2 * w, 4 * h);
        uvFull[23] = new Vector2(2 * w, 3 * h);


        Mesh mesh = new Mesh();
        mesh.vertices = vertices; // 정점버퍼에 정점 데이타 전달
        mesh.triangles = triangles; // 인덱스버퍼에 폴리곤(삼각형)의 인덱스값을 전달
        mesh.uv = uvFull;  // 삼각형에 입힐 Texture uv 좌표값 정보 전달

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

            HandleInput();
            UnseUnityMatrices();
            //_angle += Time.deltaTime * _rotSpeed;
            //this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, _angle);
    }

    void HandleInput()
    {
        float deltaTime = Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal"); // A/D <-, ->
        float vertical = Input.GetAxis("Vertical");      // W/S 

        this.transform.position += Vector3.forward * vertical * _moveSpeed * deltaTime;

        this.transform.position += Vector3.right * horizontal * _moveSpeed * deltaTime;
    }

    void UnseUnityMatrices()
    {
        Matrix4x4 worldMatrix = transform.localToWorldMatrix;   //  월드변환 행렬
        Matrix4x4 viewMatrix = _targetCamera.worldToCameraMatrix;   //  뷰변환 행렬
        Matrix4x4 projectionMatrix = _targetCamera.projectionMatrix; //  투영변환 행렬

        // shader에 값을 셋팅
        materialInstance.SetMatrix("_WorldMatrix", worldMatrix);
        materialInstance.SetMatrix("_ViewMatrix", viewMatrix);
        materialInstance.SetMatrix("_ProjectionMatrix", projectionMatrix);
    }
}
