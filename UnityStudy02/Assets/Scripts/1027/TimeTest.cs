using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
    // Time.timeScale =  0// 정지, 1: normal, 2: 2배 빠름 0.5: 반느려짐.

    float _speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
