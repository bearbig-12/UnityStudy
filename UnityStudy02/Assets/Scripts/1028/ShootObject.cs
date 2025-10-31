using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObject : MonoBehaviour
{
    private Vector3 _shootVec;
    private bool _isShoot = false;
    private float _speed = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shoot(Vector3 vec)
    {
        _shootVec = vec.normalized;
        _isShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isShoot)
        {
            this.transform.position += _shootVec * _speed * Time.deltaTime;
        }
    }
}
