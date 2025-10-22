using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCheck : MonoBehaviour
{
    [SerializeField] private Transform _enemyTr;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Front_Check()
    {
        //  ���� ���ϴ� ���͸� ����
        Vector3 enemyVec = _enemyTr.position - transform.position;

        // transform.forward (������ǥ�踦 ���������� ���溤��)
        float angle = Vector3.Dot(transform.forward, enemyVec.normalized);

        if (angle > 0)
        {
            Debug.Log($"angle = {angle} ���� �տ� �ֽ��ϴ�.");
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            Debug.Log($"angle = {angle}  ���� �ڿ� �ֽ��ϴ�.");
            GetComponent<Renderer>().material.color = Color.white;
        }


    }

    /// <summary>
    ///  ���� ���� �ִ� �Ʒ��ִ� üũ�ϴ� �޼ҵ常�弼��.
    /// </summary>
    void Front_UpDownCheck()
    {
        // ���� ���ϴ� ����
        Vector3 enemyVec = _enemyTr.position - transform.position;

        float angle = Vector3.Dot(transform.up, enemyVec.normalized);
        float angle2 = Vector3.Dot(transform.forward, enemyVec.normalized);

        if (angle2 > 0.0f)
        {
            if (angle > 0)
            {
                Debug.Log("���� �������� �ֽ��ϴ�.");
                GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                Debug.Log("���� ���� �Ʒ��� �ֽ��ϴ�.");
                GetComponent<Renderer>().material.color = Color.green;

            }

        }
        else
        {
            if (angle > 0)
            {
                Debug.Log("���� �Ĺ����� �ֽ��ϴ�.");
                GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                Debug.Log("���� �Ĺ� �Ʒ��� �ֽ��ϴ�.");
                GetComponent<Renderer>().material.color = Color.blue;

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        //Front_Check();

        Front_UpDownCheck();

    }
}
