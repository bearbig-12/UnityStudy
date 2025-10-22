using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindVector : MonoBehaviour
{
    [SerializeField] private Vector3 _windVector;
    [SerializeField] private Vector3 _windVector2;

    private float _speed = 0.7f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (new Vector3(1.0f, 0.0f, 0.0f) + _windVector + _windVector2).normalized * _speed * Time.deltaTime;
    }
}
