using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetComponentTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1. ������ ���ӿ�����Ʈ�� �ִ� component�� �ҷ��ö�
        /*
        var com = this.GetComponent<EatTest>();
        com?.Eat();
        */


        // 2. ������ ������Ʈ �� �ִ� ��� ������Ʈ�� �ҷ��ö�

        /*
        var coms = this.GetComponents<EatTest>();

        Debug.Log($"Eat Test Component Count: {coms.Length}");

        foreach(var eat in coms)
        {
            eat.Move();
        }
        */

        // 3. �ڽĿ�����Ʈ�� ������ ������Ʈ �����Ͽ�
        //    ó�� ã�� ������Ʈ��  ���Ѵ�.
        /*
        var com2 = this.GetComponentInChildren<EatTest>();

        com2.Eat();
        */

        // 4. ���������� �ڽĿ�����Ʈ�� ������ ������Ʈ�� ��� ã�� �� ���.
        /*
        var com3 = this.GetComponentsInChildren<EatTest>();

        foreach(var eat in com3)
        {
            eat.Move();
        }
        */

        // 5. ���������� �θ������Ʈ�� �ִ� ������Ʈ�� ã����
        var com4 = this.GetComponentInParent<EatTest>();

        com4.Move();


        // 6. ���������� �θ������Ʈ�� �ִ� ��� ������Ʈ�� ã����
        var com5 = this.GetComponentsInParent<EatTest>();

        foreach (var com in com5)
        {
            com4.Move();
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
