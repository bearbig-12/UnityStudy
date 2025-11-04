using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixtureTrigger : MonoBehaviour
{

    [SerializeField] private BallGameMain _GamePlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayBall") == 0)
        {
            _GamePlay.GameOver();
            Debug.Log("GameOver");
            Destroy(this.gameObject);
        }

    }
}
