using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 3.0f;
    private Transform _shootPos;

    private float _distance = 5.0f;

    public Transform ShootPos
    {
        set
        {
            _shootPos = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * _speed * Time.deltaTime;

        if(Vector3.Distance(_shootPos.position, this.transform.position) > _distance)
        {
            Destroy(this.gameObject);
        }
        
    }
}
