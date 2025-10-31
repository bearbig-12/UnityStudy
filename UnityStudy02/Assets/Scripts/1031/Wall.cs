using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool _isRemoving = false;
    private float _lapTime = 2.0f;
    private float _spendTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.CompareTo("CannonBall") == 0 && _isRemoving == false)
        {
            _isRemoving = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRemoving)
        {
            _spendTime += Time.deltaTime;

            if(_spendTime >= _lapTime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
