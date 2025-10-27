using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Eat()
    {
        this.gameObject.SetActive(false);
    }

    public void Move()
    {
        this.transform.position += new Vector3(1.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}