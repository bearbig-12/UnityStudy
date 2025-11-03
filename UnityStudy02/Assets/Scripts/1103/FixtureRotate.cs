using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixtureRotate : MonoBehaviour
{
    private enum RotDirection
    {
        Left,
        Right
    }

    [SerializeField] float _rotSpeed = 60.0f;
    [SerializeField] RotDirection _currentRotDirect = RotDirection.Left;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentRotDirect)
        {
            case RotDirection.Left:
                transform.Rotate(transform.up * _rotSpeed * Time.deltaTime);

                break;

            case RotDirection.Right:
                transform.Rotate(transform.up * -_rotSpeed * Time.deltaTime);
                break;
        }

    }
}
