using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProductTest : MonoBehaviour
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
        // ���͸� �����.
        _vec1 = _Point1Tr.position - _BasePointTr.position;
        _vec2 = _Point2Tr.position - _BasePointTr.position;

        Vector3 normVec = Vector3.Cross(_vec1, _vec2); // �� ���͸� �����Ѵ�.

        normVec = normVec.normalized * 10.0f;   // normVec�� �������ͷ� ����� 10.0f�� ���ؼ� ����ũ�⸦ 10���� �����Ѵ�.

        Gizmos.color = Color.red;

        Gizmos.DrawLine(_BasePointTr.position, _BasePointTr.position + normVec);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(_BasePointTr.position, _Point1Tr.position);
        Gizmos.DrawLine(_BasePointTr.position, _Point2Tr.position);

        Debug.Log($"vec1 to vec2 Angle = {CalculateVectoVecAngle(_vec1, _vec2)}");
        Debug.Log($"vec1 to Norm Angle = {CalculateVectoVecAngle(_vec1, normVec)}");
        Debug.Log($"vec2 to Norm Angle = {CalculateVectoVecAngle(_vec2, normVec)}");

    }


    private float CalculateVectoVecAngle(Vector3 vec1, Vector3 vec2)
    {
        float dot = Vector3.Dot(vec1, vec2);
        float mag = vec1.magnitude * vec2.magnitude;

        float radian = Mathf.Acos(dot / mag);

        float angle = radian * Mathf.Rad2Deg;

        return angle;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
