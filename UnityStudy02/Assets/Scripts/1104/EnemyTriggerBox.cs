using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerBox : MonoBehaviour
{
    enum Type
    {
        Make,
        Delete
    };
    [SerializeField] private BallGameMain _GamePlay;
    [SerializeField] private int _CreateBallCount = 10;
    [SerializeField] private int _DeleteBallCount = 5;

    [SerializeField] private Type _Type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayBall") == 0 && _Type == Type.Make)
        {
            _GamePlay.MakeEnemyBall(_CreateBallCount, transform.position);

            Destroy(this.gameObject);
        }
        if (other.tag.CompareTo("PlayBall") == 0 && _Type == Type.Delete)
        {
            _GamePlay.DeleteEnemyBall(_DeleteBallCount);

            Destroy(this.gameObject);
        }
    }
}
