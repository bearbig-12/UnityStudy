using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement
    : MonoBehaviour
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
        MakeDice();

        if (_targetMaterial == null) // material
        {
            materialInstance = GetComponent<MeshRenderer>().material;
        }

        if (_targetCamera == null) // camera
        {
            _targetCamera = Camera.main;
        }
    }

    void MakeDice()
    {
        Vector3[] vertices = new Vector3[]
        {
            // 앞면(front)                    
            new Vector3(-1.0f, -1.0f, -1.0f), // 0 (0)
            new Vector3(-1.0f, 1.0f, -1.0f),  // 1 (1)
            new Vector3(1.0f, 1.0f, -1.0f),  // 2  (2)
            new Vector3(1.0f, -1.0f, -1.0f), // 3  (3)

            // 윗면(up)
            new Vector3(-1.0f, 1.0f, -1.0f),  // 4 (1)
            new Vector3(-1.0f, 1.0f, 1.0f),   // 5 (5)
            new Vector3(1.0f, 1.0f, 1.0f),    // 6 (6)
            new Vector3(1.0f, 1.0f, -1.0f),   // 7 (2)

            //  뒷면(back)
            new Vector3(-1.0f, 1.0f, 1.0f),    //8 (5)
            new Vector3(-1.0f, -1.0f, 1.0f),  // 9 (4)
            new Vector3(1.0f, -1.0f, 1.0f),   // 10 (7)
            new Vector3(1.0f, 1.0f, 1.0f),    // 11 (6)

            //  밑면(Base)
            new Vector3(-1.0f, -1.0f, 1.0f),   // 12 (4)
            new Vector3(-1.0f, -1.0f, -1.0f),  // 13 (0)
            new Vector3(1.0f, -1.0f, -1.0f),   // 14 (3)
            new Vector3(1.0f, -1.0f, 1.0f),    // 15 (7)

            // 좌측면(Left)
            new Vector3(-1.0f, -1.0f, 1.0f),    // 16 (4)
            new Vector3(-1.0f, 1.0f, 1.0f),    // 17 (5)
            new Vector3(-1.0f, 1.0f, -1.0f),   // 18 (1)
            new Vector3(-1.0f, -1.0f, -1.0f),   // 19 (0)


            //  우측면(Right)
            new Vector3(1.0f, -1.0f, -1.0f),    // 20 (3)
            new Vector3(1.0f, 1.0f, -1.0f),     // 21 (2)
            new Vector3(1.0f, 1.0f, 1.0f),      // 22 (6)
            new Vector3(1.0f, -1.0f, 1.0f)      // 23 (7)
      };

        // 인덱스 버퍼에 전달할 폴리곤 데이타
        int[] triangles = new int[]
        {
            // 전면(front)
            0, 1, 2,
            0, 2, 3,

            // 윗면(Up)
            4, 5, 6,
            4, 6, 7,

            // 뒷면(back)
            8, 9, 10,
            8, 10, 11,

            //  밑면(Base)
            12, 13, 14,
            12, 14, 15,

            // 좌측면(Left)
            16, 17, 18,
            16, 18, 19,

            //  우측면(Right)
            20, 21, 22,
            20, 22, 23
        };


        // Uv좌표
        Vector2[] uvs = new Vector2[]
        {
            //  정면 (5)
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 0.3333f),
            new Vector2(0.5f, 0.3333f),
            new Vector2(0.5f, 0.0f),

            // 윗면 (6)
            new Vector2(0.5f, 0.0f),
            new Vector2(0.5f, 0.3333f),
            new Vector2(1.0f, 0.3333f),
            new Vector2(1.0f, 0.0f),

            // 뒷면 (2)
            new Vector2(0.5f, 0.6666f),
            new Vector2(0.5f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.6666f),

            // 밑면 (1)
            new Vector2(0.0f, 0.6666f),
            new Vector2(0.0f, 1.0f),
            new Vector2(0.5f, 1.0f),
            new Vector2(0.5f, 0.6666f),

            //  좌측면 (3)
            new Vector2(0.0f, 0.3333f),
            new Vector2(0.0f, 0.6666f),
            new Vector2(0.5f, 0.6666f),
            new Vector2(0.5f, 0.3333f),

            // 우측면 (4)
            new Vector2(0.5f, 0.3333f),
            new Vector2(0.5f, 0.6666f),
            new Vector2(1.0f, 0.6666f),
            new Vector2(1.0f, 0.3333f)
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;   //  버텍스 버퍼에 정점 정보 저장
        mesh.triangles = triangles; //  인덱스 버퍼에 폴리곤 정보 저장
        mesh.uv = uvs;              //  텍스처 uv 좌표 값 전달

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        Material material = new Material(Shader.Find("Custom/TransformMatrixShader"));
        material.SetTexture("_MainTex", _texture);

        GetComponent<MeshRenderer>().material = material;

    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        UnseUnityMatrices();
    }


    void HandleInput()
    {
        float deltaTime = Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal"); // A/D <-, ->
        float vertical = Input.GetAxis("Vertical");      // W/S 

        this.transform.position += Vector3.forward * vertical * _moveSpeed * deltaTime;

        this.transform.position += Vector3.right * horizontal * _moveSpeed * deltaTime;

        // 상승/하강 (Space / Left Ctrl)
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.position += Vector3.up * _moveSpeed * deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            this.transform.position += Vector3.down * _moveSpeed * deltaTime;
        }



        // 회전 입력 (Q/E)
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.y -= _rotationSpeed * deltaTime; // 왼쪽 회전
            transform.rotation = Quaternion.Euler(rot);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.y += _rotationSpeed * deltaTime; // 오른쪽 회전
            transform.rotation = Quaternion.Euler(rot);
        }

        // 상하 회전 (R/F)
        if (Input.GetKey(KeyCode.R))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.x += _rotationSpeed * deltaTime; // 오른쪽 회전
            transform.rotation = Quaternion.Euler(rot);
        }
        if (Input.GetKey(KeyCode.F))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.x -= _rotationSpeed * deltaTime; // 오른쪽 회전
            transform.rotation = Quaternion.Euler(rot);
        }

        // Z축 회전 (Z/X)
        if (Input.GetKey(KeyCode.Z))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.z -= _rotationSpeed * deltaTime; // 오른쪽 회전
            transform.rotation = Quaternion.Euler(rot);
        }
        if (Input.GetKey(KeyCode.X))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.z += _rotationSpeed * deltaTime; // 오른쪽 회전
            transform.rotation = Quaternion.Euler(rot);
        }

        // 스케일 조절 (1/2)
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _scale -= Vector3.one * deltaTime; // 축소
            _scale = Vector3.Max(_scale, Vector3.one * 0.1f); // 최소값 제한
            this.transform.localScale = _scale;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            _scale += Vector3.one * deltaTime; // 확대
            this.transform.localScale = _scale;
        }

        // 리셋 (백스페이스)
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetTransform();
        }
    }

    //  변환행렬 초기화
    void ResetTransform()
    {
        _position = Vector3.zero;
        _rotation = Vector3.zero;
        _scale = Vector3.one;
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