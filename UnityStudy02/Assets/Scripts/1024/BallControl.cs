using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private GameObject _ballObj;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject.Find는 활성화되어있는 게임오브젝트를 대상으로 합니다.
        // 비활성화 되어있는 게임오브젝트는 찾지 못합니다.
        // 1.
       /*
        _ballObj = GameObject.Find("Ball");

        //_ballObj.SetActive(false); // _ballObj  게임 오브젝트를 비활성화.

        if(_ballObj != null)
        {
            // GetComonent는 게임오브젝트에 붙어있는 Component의 참조를 가져옵니다.
            BallScript ballscript = _ballObj.GetComponent<BallScript>();

            ballscript.Go();
        }
        else
        {
            Debug.Log("Ball 오브젝트를 찾지 못했습니다.");
        }
       */

        // 2. 
        // Transform.Find: 계층구조상에 있는 오브젝트 찾을 때 사용. 비활성화된 오브젝트도 찾을 수 있습니다.

        /*
        Transform ballTr = transform.Find("Ball");

       

        if(ballTr != null)
        {
			ballTr.gameObject.SetActive(true);
			ballTr.GetComponent<BallScript>().Go();
        }
        else
        {
            Debug.Log("Ball을 찾지 못했습니다.");

        }
        */

        // 3. Tag로 찾기
        /*
        var obj = GameObject.FindGameObjectWithTag("RollBall");

        obj?.GetComponent<BallScript>().Go();
        */

        /*
        var objs = GameObject.FindGameObjectsWithTag("RollBall");

        foreach(var ob in objs)
        {
            ob.GetComponent<BallScript>().Go();
        }
        */


        // 4. 순서로 찾기
        var tr =  transform.GetChild(3);

        tr.GetComponent<BallScript>().Go();

        // 5.  컴포넌트 type으로 찾기
        var ballScript  = GameObject.FindObjectOfType<BallScript>(); // 전체가 대상
        ballScript.Go();

        var ballScriptTr = Transform.FindObjectOfType<BallScript>();    //  계층구조상있는 컴포넌트

        var ballScripts = GameObject.FindObjectsOfType<BallScript>(); // BallScript 컴포넌트를 가지고 있는 모든 오브젝트

        foreach(var ball in ballScripts)
        {
            ball.Go();
        }

        var ballScriptTrs = Transform.FindObjectsOfType<BallScript>();

        foreach(var ball in ballScriptTrs)
        {
            ball.Go();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
