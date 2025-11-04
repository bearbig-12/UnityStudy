using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusTimeTriggerBox : MonoBehaviour
{
    [SerializeField] private BallGameMain _GamePlay;
    [SerializeField] private float _AddTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayBall") == 0)
        {
            _GamePlay.MinusTime(_AddTime);
            Destroy(gameObject);

        }
    }


}