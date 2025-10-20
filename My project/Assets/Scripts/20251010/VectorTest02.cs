using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2Test : MonoBehaviour
{
    [SerializeField] private Transform _TargetObject;

    private float _speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direct = _TargetObject.position - transform.position;

        this.transform.position += direct.normalized * _speed * Time.deltaTime;

    }
}
