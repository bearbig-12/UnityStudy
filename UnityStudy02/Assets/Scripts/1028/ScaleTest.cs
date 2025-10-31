using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        /*
        this.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
        Debug.Log($"lossyScale = {this.transform.lossyScale}"); // lossyScale은 읽기만 가능 절대적인 스케일 값
        Debug.Log($"localScale = {this.transform.localScale}"); //  localScale은 읽기, 쓰기 가능 상대적 스케일 값
        */

        GameObject parentObj = GameObject.Find("Cube");

        this.transform.SetParent(parentObj.transform);
		Debug.Log($"lossyScale = {this.transform.lossyScale}"); // lossyScale은 읽기만 가능 절대적인 스케일 값
		Debug.Log($"localScale = {this.transform.localScale}"); //  localScale은 읽기, 쓰기 가능 상대적 스케일 값


	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
