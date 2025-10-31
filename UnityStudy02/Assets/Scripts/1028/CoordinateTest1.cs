using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateTest1 : MonoBehaviour
{
    [SerializeField] private Transform _targetTr;


    // Start is called before the first frame update
    void Start()
    {
        // 로컬 좌표를 월드좌표로 변환
        /*
        Vector3 worldPosition = transform.TransformDirection(Vector3.forward);

        Debug.Log($"LocalPosition: {transform.forward}");
        Debug.Log($"WorldPosition: {worldPosition}");
        */

        // 로컬의 위치좌표를 월드의 위치좌표로 변환
        Debug.Log($"_targetTr.localPosition = {_targetTr.localPosition}");
        Debug.Log($"_targetTr.Position = {_targetTr.position}");
        Vector3 worldPos = transform.TransformPoint(_targetTr.localPosition);
        Debug.Log($"WorldPos = {worldPos}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
