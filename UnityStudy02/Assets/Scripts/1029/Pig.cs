using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : PatrolTest
{
    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private new void Update()
    {
        base.Update();
    }
}
