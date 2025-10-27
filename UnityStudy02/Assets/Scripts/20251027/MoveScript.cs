using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    Stop
}

public class MoveScript : MonoBehaviour
{
    [SerializeField] private GameObject _targetObj;

    [SerializeField] private Direction _currentDirect = Direction.Stop;

    Vector3 _MoveDirect = Vector3.zero;
    private float _speed = 3.0f;

    // smooth damp��
    float smoothTime = 1.0f;
    Vector3 velocity = Vector3.zero;




    // Start is called before the first frame update
    void Start()
    {



    }

    void SetDirection()
    {
        switch (_currentDirect)
        {
            case Direction.Up:
                _MoveDirect = new Vector3(0.0f, 1.0f, 0.0f);
                break;

            case Direction.Down:
                _MoveDirect = new Vector3(0.0f, -1.0f, 0.0f);
                break;

            case Direction.Left:
                _MoveDirect = new Vector3(-1.0f, 0.0f, 0.0f);
                break;

            case Direction.Right:
                _MoveDirect = new Vector3(1.0f, 0.0f, 0.0f);
                break;

            case Direction.Stop:
                _MoveDirect = Vector3.zero;
                break;
        }
    }

    void FixedUpdate()
    {
        //  �����Լ��� �̿�
        // Vector3.Lerp(������ġ, ��ǥ��ġ, ������(0 ~ 1.0������ ��) // ��������

        //this.transform.position = Vector3.Lerp(this.transform.position, _targetObj.transform.position, 0.25f);


        // Vector3.Slerp(������ġ, ��ǥ��ġ, ������(0 ~ 1.0f ������ ��)) // ���麸��
        this.transform.position = Vector3.Slerp(transform.position, _targetObj.transform.position, 0.08f);
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 
        //SetDirection();
        // transform ������Ʈ�� ���� ����
        //this.transform.position += _MoveDirect.normalized * _speed * Time.deltaTime;

        // 2.
        //this.transform.Translate(new Vector3(0.0f, 1.0f, 0.0f) * _speed * Time.deltaTime);

        // 3.
        // ��ǥ�踦 �������� ������ ������ǥ�谡 ����.
        // this.transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);

        // 4.
        //this.transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.World);

        // 5. 
        /*
        _MoveDirect = _targetObj.transform.position - this.transform.position;  //  Ÿ�ٹ������� ���� ����
        _MoveDirect = _MoveDirect.normalized;

        this.transform.Translate(_MoveDirect * _speed * Time.deltaTime, Space.World);
        */

        // 6.
        //transform.position = Vector3.MoveTowards(transform.position, _targetObj.transform.position, _speed * Time.deltaTime);

        // 7.
        //transform.position = Vector3.SmoothDamp(transform.position, _targetObj.transform.position, ref velocity, smoothTime);
    }
}
