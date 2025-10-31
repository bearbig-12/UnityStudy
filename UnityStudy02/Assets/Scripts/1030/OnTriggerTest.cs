using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnTriggerEnter(Collider other) // 막 충돌되는 순간 발생
	{
		Debug.Log("OnTriggerEnter");

	}

	private void OnTriggerStay(Collider other)  // 충돌상태가 유지동안 발생
	{
		Debug.Log("OnTriggerStay");
	}

	private void OnTriggerExit(Collider other)  // 충돌상태가 해제되는 순간 발생
	{
		Debug.Log("OnTriggerExit");
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
