using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerTr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(_playerTr.position.x, _playerTr.position.y, this.transform.position.z);

    }
}

