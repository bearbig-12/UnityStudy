using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direct
{
    Stop,
    Forward,
    Right
}


public class ObjectMove : MonoBehaviour
{
    [SerializeField] private Direct _direct = Direct.Stop;
    [SerializeField] private bool _coordinate = true;   // true: ·ÎÄÃÁÂÇ¥°è, false: ¿ùµåÁÂÇ¥°ê

    private float _speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (_direct)
        {
            case Direct.Forward:
                if (_coordinate)
                {
                    this.transform.position += transform.forward * _speed * Time.deltaTime;

                }
                else
                {
                    this.transform.position += Vector3.forward * _speed * Time.deltaTime;

                }
                break;

            case Direct.Right:
                if (_coordinate)
                {
                    this.transform.position += transform.right * _speed * Time.deltaTime;
                }
                else
                {
                    this.transform.position += Vector3.right * _speed * Time.deltaTime;
                }
                break;
        }
    }
}
