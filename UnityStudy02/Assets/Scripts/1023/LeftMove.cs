using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{
    public float _speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Eat()
    {
        Debug.Log($"LeftMove Method Eat");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * _speed * Time.deltaTime;
    }
}
