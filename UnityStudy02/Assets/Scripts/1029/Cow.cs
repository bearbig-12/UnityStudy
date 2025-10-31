using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : PatrolTest
{
	void Start()
	{
		this.GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	private new void Update()
    {
        base.Update();
    }

}
