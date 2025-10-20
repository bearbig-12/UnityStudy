using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest4 : MonoBehaviour
{
    [SerializeField] private Transform _BasePointTr;
    [SerializeField] private Transform _Point1Tr;
    [SerializeField] private Transform _Point2Tr;

    Vector3 _vec1 = Vector3.zero;
    Vector3 _vec2 = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDrawGizmos()
    {
        _vec1 = _Point1Tr.position - _BasePointTr.position;
        _vec2 = _Point2Tr.position - _BasePointTr.position;

        float dot = Vector3.Dot(_vec1, _vec2);  // �κ����� ����
        float mag = _vec1.magnitude * _vec2.magnitude;   // �� ������ ũ���� ��

        float radian = Mathf.Acos(dot / mag);

        float angle = radian * Mathf.Rad2Deg;

        Vector3 nVec = Vector3.Cross(_vec1, _vec2); // �� ������ �����ϸ� �� ���Ϳ� ������ nVector�� �������.

        float cross = nVec.z;

        if (cross >= 0.0f)
        {
            Debug.Log($"angle = {angle}");
        }
        else
        {
            Debug.Log($"angle = {360.0f - angle}");
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(_BasePointTr.position, _Point1Tr.position);
        Gizmos.DrawLine(_BasePointTr.position, _Point2Tr.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
