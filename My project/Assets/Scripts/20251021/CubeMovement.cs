using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement
    : MonoBehaviour
{
    [SerializeField] private Texture _texture;

    // Material
    [SerializeField] private Material _targetMaterial;

    // ���庯ȯ
    public Vector3 _position = Vector3.zero;    //  �̵� (translate)
    public Vector3 _rotation = Vector3.zero;    //  ȸ�� (rotation) (euler angle)
    public Vector3 _scale = Vector3.one;        //  ũ�� (scale)

    // ī�޶�
    public Camera _targetCamera;

    public float _moveSpeed = 5.0f; //  �̵� �ӵ�
    public float _rotationSpeed = 70.0f; //  ȸ�� �ӵ�

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
            // �ո�(front)                    
            new Vector3(-1.0f, -1.0f, -1.0f), // 0 (0)
            new Vector3(-1.0f, 1.0f, -1.0f),  // 1 (1)
            new Vector3(1.0f, 1.0f, -1.0f),  // 2  (2)
            new Vector3(1.0f, -1.0f, -1.0f), // 3  (3)

            // ����(up)
            new Vector3(-1.0f, 1.0f, -1.0f),  // 4 (1)
            new Vector3(-1.0f, 1.0f, 1.0f),   // 5 (5)
            new Vector3(1.0f, 1.0f, 1.0f),    // 6 (6)
            new Vector3(1.0f, 1.0f, -1.0f),   // 7 (2)

            //  �޸�(back)
            new Vector3(-1.0f, 1.0f, 1.0f),    //8 (5)
            new Vector3(-1.0f, -1.0f, 1.0f),  // 9 (4)
            new Vector3(1.0f, -1.0f, 1.0f),   // 10 (7)
            new Vector3(1.0f, 1.0f, 1.0f),    // 11 (6)

            //  �ظ�(Base)
            new Vector3(-1.0f, -1.0f, 1.0f),   // 12 (4)
            new Vector3(-1.0f, -1.0f, -1.0f),  // 13 (0)
            new Vector3(1.0f, -1.0f, -1.0f),   // 14 (3)
            new Vector3(1.0f, -1.0f, 1.0f),    // 15 (7)

            // ������(Left)
            new Vector3(-1.0f, -1.0f, 1.0f),    // 16 (4)
            new Vector3(-1.0f, 1.0f, 1.0f),    // 17 (5)
            new Vector3(-1.0f, 1.0f, -1.0f),   // 18 (1)
            new Vector3(-1.0f, -1.0f, -1.0f),   // 19 (0)


            //  ������(Right)
            new Vector3(1.0f, -1.0f, -1.0f),    // 20 (3)
            new Vector3(1.0f, 1.0f, -1.0f),     // 21 (2)
            new Vector3(1.0f, 1.0f, 1.0f),      // 22 (6)
            new Vector3(1.0f, -1.0f, 1.0f)      // 23 (7)
      };

        // �ε��� ���ۿ� ������ ������ ����Ÿ
        int[] triangles = new int[]
        {
            // ����(front)
            0, 1, 2,
            0, 2, 3,

            // ����(Up)
            4, 5, 6,
            4, 6, 7,

            // �޸�(back)
            8, 9, 10,
            8, 10, 11,

            //  �ظ�(Base)
            12, 13, 14,
            12, 14, 15,

            // ������(Left)
            16, 17, 18,
            16, 18, 19,

            //  ������(Right)
            20, 21, 22,
            20, 22, 23
        };


        // Uv��ǥ
        Vector2[] uvs = new Vector2[]
        {
            //  ���� (5)
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 0.3333f),
            new Vector2(0.5f, 0.3333f),
            new Vector2(0.5f, 0.0f),

            // ���� (6)
            new Vector2(0.5f, 0.0f),
            new Vector2(0.5f, 0.3333f),
            new Vector2(1.0f, 0.3333f),
            new Vector2(1.0f, 0.0f),

            // �޸� (2)
            new Vector2(0.5f, 0.6666f),
            new Vector2(0.5f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.6666f),

            // �ظ� (1)
            new Vector2(0.0f, 0.6666f),
            new Vector2(0.0f, 1.0f),
            new Vector2(0.5f, 1.0f),
            new Vector2(0.5f, 0.6666f),

            //  ������ (3)
            new Vector2(0.0f, 0.3333f),
            new Vector2(0.0f, 0.6666f),
            new Vector2(0.5f, 0.6666f),
            new Vector2(0.5f, 0.3333f),

            // ������ (4)
            new Vector2(0.5f, 0.3333f),
            new Vector2(0.5f, 0.6666f),
            new Vector2(1.0f, 0.6666f),
            new Vector2(1.0f, 0.3333f)
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;   //  ���ؽ� ���ۿ� ���� ���� ����
        mesh.triangles = triangles; //  �ε��� ���ۿ� ������ ���� ����
        mesh.uv = uvs;              //  �ؽ�ó uv ��ǥ �� ����

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

        // ���/�ϰ� (Space / Left Ctrl)
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.position += Vector3.up * _moveSpeed * deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            this.transform.position += Vector3.down * _moveSpeed * deltaTime;
        }



        // ȸ�� �Է� (Q/E)
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.y -= _rotationSpeed * deltaTime; // ���� ȸ��
            transform.rotation = Quaternion.Euler(rot);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.y += _rotationSpeed * deltaTime; // ������ ȸ��
            transform.rotation = Quaternion.Euler(rot);
        }

        // ���� ȸ�� (R/F)
        if (Input.GetKey(KeyCode.R))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.x += _rotationSpeed * deltaTime; // ������ ȸ��
            transform.rotation = Quaternion.Euler(rot);
        }
        if (Input.GetKey(KeyCode.F))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.x -= _rotationSpeed * deltaTime; // ������ ȸ��
            transform.rotation = Quaternion.Euler(rot);
        }

        // Z�� ȸ�� (Z/X)
        if (Input.GetKey(KeyCode.Z))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.z -= _rotationSpeed * deltaTime; // ������ ȸ��
            transform.rotation = Quaternion.Euler(rot);
        }
        if (Input.GetKey(KeyCode.X))
        {
            Vector3 rot = transform.rotation.eulerAngles;

            rot.z += _rotationSpeed * deltaTime; // ������ ȸ��
            transform.rotation = Quaternion.Euler(rot);
        }

        // ������ ���� (1/2)
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _scale -= Vector3.one * deltaTime; // ���
            _scale = Vector3.Max(_scale, Vector3.one * 0.1f); // �ּҰ� ����
            this.transform.localScale = _scale;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            _scale += Vector3.one * deltaTime; // Ȯ��
            this.transform.localScale = _scale;
        }

        // ���� (�齺���̽�)
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetTransform();
        }
    }

    //  ��ȯ��� �ʱ�ȭ
    void ResetTransform()
    {
        _position = Vector3.zero;
        _rotation = Vector3.zero;
        _scale = Vector3.one;
    }

    void UnseUnityMatrices()
    {
        Matrix4x4 worldMatrix = transform.localToWorldMatrix;   //  ���庯ȯ ���
        Matrix4x4 viewMatrix = _targetCamera.worldToCameraMatrix;   //  �亯ȯ ���
        Matrix4x4 projectionMatrix = _targetCamera.projectionMatrix; //  ������ȯ ���

        // shader�� ���� ����
        materialInstance.SetMatrix("_WorldMatrix", worldMatrix);
        materialInstance.SetMatrix("_ViewMatrix", viewMatrix);
        materialInstance.SetMatrix("_ProjectionMatrix", projectionMatrix);
    }
}