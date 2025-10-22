using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTr;
    [SerializeField] private float _speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void EnemyMove()
    {
        Vector3 directVec = _playerTr.position - transform.position;

        directVec = directVec.normalized;

        transform.position += directVec * _speed * Time.deltaTime;

    }


    // Update is called once per frame
    void Update()
    {
        EnemyMove();

    }
}
