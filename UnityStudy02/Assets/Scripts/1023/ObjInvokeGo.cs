using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInvokeGo : MonoBehaviour
{
	[SerializeField] private GameObject[] _gameObjects;
	// Start is called before the first frame update
	void Start()
	{
		foreach (var obj in _gameObjects)
		{
			obj.GetComponent<CarRaceTest>().Go();
		}

	}

	// Update is called once per frame
	void Update()
	{

	}
}
