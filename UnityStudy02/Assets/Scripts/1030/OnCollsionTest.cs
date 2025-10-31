using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollsionTest : MonoBehaviour
{
    [SerializeField] private GameObject _Tank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision) // 충돌 순간
    {
        if (collision.collider.tag.Contains("CollsionTest"))
        {
			Debug.Log("OnCollisionEnter");

		}

        _Tank.GetComponent<Tank>().SetStop(true);
        
    }

    private void OnCollisionStay(Collision collision) // 충돌유지
    {
		if (collision.collider.tag.Contains("CollsionTest"))
        {
			Debug.Log("OnCollisionStay");
		}
			
    }

    private void OnCollisionExit(Collision collision)   // 충돌해소
    {
		if (collision.collider.tag.Contains("CollsionTest"))
        {
			Debug.Log("OnCollisionExit");
		}
			
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
