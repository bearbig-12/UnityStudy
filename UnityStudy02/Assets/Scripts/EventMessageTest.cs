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


    private void Awake() // ������Ʈ�� �����ɶ� �ѹ� ȣ��
    {
        Debug.Log($"{this.gameObject.name} -- Awake");
    }

    private void OnEnable() // ������Ʈ�� Ȱ��ȭ �ɶ� 
    {
        Debug.Log($"{this.gameObject.name} -- OnEnable");

    }

    private void OnDisable()    // ������Ʈ�� ��Ȱ��ȭ �ɶ�
    {
        Debug.Log($"{this.gameObject.name} -- OnDisable");
    }


    // Start is called before the first frame update
    void Start() // Update �޼����� �߻����� ������ Start �޼����� �ѹ� �߻�
    {
        Debug.Log($"{this.gameObject.name} -- Start()");
    }

    private void FixedUpdate() // default: 0.02�� ���� �ѹ��� ȣ��
    {
        if (isFixedUpdate)
        {
            Debug.Log($"{this.gameObject.name} -- FixedUpdate");
        }
    }


    // Update is called once per frame
    void Update() // ���÷��� ,  �ݺ������� ó���� �۾�
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
