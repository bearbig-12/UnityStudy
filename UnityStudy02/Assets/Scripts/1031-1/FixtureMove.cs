using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FixtureMove : MonoBehaviour
{
    private float _moveSpeed = 2.0f;
    bool _direct = true;    // 움직이는 방향
    float _distance = 2.0f;
    Vector3 _destination;   // 움직이는 위치
    Vector3 _originPos;  // 초기위치.


    // Start is called before the first frame update
    void Start()
    {
        _originPos = this.transform.position;   // 시작위치를 기록
        _destination = _originPos + transform.up * _distance; // 이동할 위치값을 계산

    }

    // Update is called once per frame
    void Update()
    {

        if (_direct)
        {
            this.transform.position += transform.up.normalized * _moveSpeed * Time.deltaTime;

            if (Vector3.Distance(this.transform.position, _destination) <= 0.01f) // 목적지에 도착했으면
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
