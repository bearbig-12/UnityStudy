using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FixtureMove : MonoBehaviour
{
    private float _moveSpeed = 2.0f;
    bool _direct = true;    // �����̴� ����
    float _distance = 2.0f;
    Vector3 _destination;   // �����̴� ��ġ
    Vector3 _originPos;  // �ʱ���ġ.


    // Start is called before the first frame update
    void Start()
    {
        _originPos = this.transform.position;   // ������ġ�� ���
        _destination = _originPos + transform.up * _distance; // �̵��� ��ġ���� ���

    }

    // Update is called once per frame
    void Update()
    {

        if (_direct)
        {
            this.transform.position += transform.up.normalized * _moveSpeed * Time.deltaTime;

            if (Vector3.Distance(this.transform.position, _destination) <= 0.01f) // �������� ����������
            {
                _destination = _originPos - transform.up * _distance;
                _direct = false;
            }
        }
        else
        {
            this.transform.position += -transform.up.normalized * _moveSpeed * Time.deltaTime;
            if (Vector3.Distance(this.transform.position, _destination) <= 0.01f)
            {
                _destination = _originPos + transform.up * _distance;
                _direct = true;
            }
        }


    }
}
