using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogCube : MonoBehaviour
{
    enum State
    {
        Jump,
        Ground
    }

    private Rigidbody _rb;
    private float _jumpPower = 1.0f;
    State _currentState = State.Ground;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _jumpPower = Random.Range(10.0f, 20.0f);

        Jump();


    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.CompareTo("Land") == 0)
        {
            _currentState = State.Ground;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag.CompareTo("Land") == 0)
        {
            _currentState = State.Jump;
        }
    }

    public void Hit()
    {
        if (_currentState == State.Jump)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
