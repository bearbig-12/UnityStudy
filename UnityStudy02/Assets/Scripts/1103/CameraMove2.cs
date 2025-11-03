using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    [SerializeField] private Transform _PlayerTr;

    float Ypos = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Ypos = this.transform.position.y;
    }

    private void LateUpdate()
    {
        Vector3 playerPos = _PlayerTr.position;
        transform.position = new Vector3(playerPos.x, Ypos, playerPos.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
