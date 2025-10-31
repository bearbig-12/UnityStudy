using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageUpwardScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SendMessageUpwards("Eat"); // 부모쪽 게임오브젝트 방향으로 메세지를 보낼때
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
