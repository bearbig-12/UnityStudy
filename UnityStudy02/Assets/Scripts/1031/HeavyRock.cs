using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Drop()
    {
        this.GetComponent<Rigidbody>().useGravity = true;

        this.GetComponent<Rigidbody>().AddForce(-this.transform.up * 20.0f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
