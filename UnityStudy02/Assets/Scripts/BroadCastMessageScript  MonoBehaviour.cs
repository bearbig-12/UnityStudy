using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadCastMessageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BroadcastMessage("Eat"); // 자식오브젝트 방향으로 메세지 보낼때 사용
    }

    // Update is called once per frame
    void Update()
    {

    }
}