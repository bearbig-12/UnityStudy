using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateTest2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Vector3 worldPos = new Vector3(3.0f, 3.0f, 2.0f);

        // 월드 좌표를 로컬좌표로 변환 (위치값)
        Vector3 localPosition = transform.InverseTransformPoint(worldPos);

        Debug.Log($"world position = {worldPos}");
        Debug.Log($"local Position = {localPosition}");


        /*
        //  월드 방향으로 로컬방향으로 변환
        Vector3 worldDirect = new Vector3(0.0f, 0.0f, 1.0f);

        Vector3 localDirect = transform.InverseTransformDirection(worldDirect);

        Debug.Log($"World Direction = {worldDirect}");
        Debug.Log($"local Direciton = {localDirect}");
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
