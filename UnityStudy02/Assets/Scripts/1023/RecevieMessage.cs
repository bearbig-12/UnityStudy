using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecevieMessage : MonoBehaviour
{
    private static int count = 0;
    [SerializeField] private bool _isFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Eat()  // Eat 메세지를 받는 메소드
    {
        if (_isFlag)
        {
            Debug.Log($"ReceiveMessage {this.gameObject.name} -- Eat {count++}");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
