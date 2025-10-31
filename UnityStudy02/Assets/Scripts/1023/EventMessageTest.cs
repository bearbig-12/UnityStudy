using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMessageTest : MonoBehaviour
{
    [SerializeField] private bool isUpdate = false;
    [SerializeField] private bool isFixedUpdate = false;
    [SerializeField] private bool isLateUpdate = false;

    private void Reset()
    {
        Debug.Log($"{this.gameObject.name} -- Reset");

        isUpdate = false;
        isFixedUpdate = false;
        isLateUpdate = false;
    }


    private void Awake() // 컴포넌트가 생성될때 한번 호출
    {
        Debug.Log($"{this.gameObject.name} -- Awake");
    }

    private void OnEnable() // 컴포넌트가 활성화 될때 
    {
         Debug.Log($"{this.gameObject.name} -- OnEnable");

    }

    private void OnDisable()    // 컴포넌트가 비활성화 될때
    {
        Debug.Log($"{this.gameObject.name} -- OnDisable");
    }


    // Start is called before the first frame update
    void Start() // Update 메세지가 발생되지 직전에 Start 메세지가 한번 발생
    {
        Debug.Log($"{this.gameObject.name} -- Start()");   
    }

    private void FixedUpdate() // default: 0.02초 마다 한번씩 호출
    {
        if (isFixedUpdate)
        {
            Debug.Log($"{this.gameObject.name} -- FixedUpdate");
        }
    }


    // Update is called once per frame
    void Update() // 매플레임 ,  반복적으로 처리할 작업
    {
        if (isUpdate)
        {
            Debug.Log($"{this.gameObject.name} -- Update");
        }
    }

    private void LateUpdate()
    {
        if (isLateUpdate)
        {
            Debug.Log($"{this.gameObject.name} -- LateUpdate");
        }
    }
}
