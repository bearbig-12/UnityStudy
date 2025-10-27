using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] private Transform _targetTr;

    float _angle = 0.0f;
    float _rotSpeed = 30.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _angle += _rotSpeed * Time.deltaTime;
        // 1.
        //this.transform.rotation = Quaternion.Euler(30.0f, _angle, 0);   //  각축방식 -> 쿼터니언

        //this.transform.rotation = Quaternion.AngleAxis(_angle, new Vector3(0.5f, 1.0f, 0.0f));

        // 2.
        this.transform.Rotate(new Vector3(1.0f, 1.0f, 0.0f), Space.Self);

    }
}
