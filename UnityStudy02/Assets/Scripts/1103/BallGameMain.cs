using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallGameMain : MonoBehaviour
{
    [SerializeField] private Text _EnemyBallCountText;
    [SerializeField] private Text _GameClearText;
    [SerializeField] private Text _PlayTimeText;
    [SerializeField] private GameObject _EnemyBallPrefab;
    [SerializeField] private Transform _EnemyParent;
    [SerializeField] private EnemyBallControl _EnemyBallCtrl;

    private float _radius = 5.0f;
    private int _ballCount = 20;

    float _lapTime = 100.0f;    //  게임 진행시간
    float _spendTime = 0.0f;

    bool _isPlay = false;       //  게임 실행 유무

    public bool isPlay
    {
        get => _isPlay;
    }

    // Start is called before the first frame update
    void Start()
    {
        _PlayTimeText.text = "PlayTime: 0.00f";
        _spendTime = 0.0f;
        MakeEnemyBall(_ballCount);
        _isPlay = true;

        _EnemyBallCountText.text = _ballCount.ToString();
    }

    void MakeEnemyBall(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 createPos = Random.insideUnitCircle * _radius;

            var ball = Instantiate(_EnemyBallPrefab, new Vector3(createPos.x, 2.0f, createPos.y), Quaternion.identity, _EnemyParent);
            ball.GetComponent<EnemyBall>().SetGamePlay(this);
        }
    }

    public void MakeEnemyBall(int enemyCount, Vector3 pos)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 createPos = Random.insideUnitCircle * _radius;

            var ball = Instantiate(_EnemyBallPrefab, new Vector3(pos.x + createPos.x, 2.0f, pos.z + createPos.y), Quaternion.identity, _EnemyParent);
            ball.GetComponent<EnemyBall>().SetGamePlay(this);
        }

        _ballCount += enemyCount;

    }

    public void DeleteEnemyBall(int Count)
    {
        // 씬에 있는 Enemy Ball 찾기
        List<GameObject> EnemyList = new List<GameObject>(GameObject.FindGameObjectsWithTag("EnemyBall"));

        if(EnemyList.Count < Count)
        {
            Count = EnemyList.Count;
        }

        for (int i = 0; i < Count; i++)
        {
            if(EnemyList.Count == 0)
            {
                break;
            }
            int index = Random.Range(0, EnemyList.Count);

            Destroy(EnemyList[index]);

            EnemyList.RemoveAt(index);

            _ballCount--;
        }

        _EnemyBallCountText.text = _ballCount.ToString();


        if (_ballCount <= 0)
        {
            _GameClearText.text = "Game Clear";
            _GameClearText.gameObject.SetActive(true);

            _isPlay = false;

        }

    }

    public void DecreaseDead()
    {
        _ballCount--;

        _EnemyBallCountText.text = _ballCount.ToString();

        if (_ballCount <= 0)
        {
            _GameClearText.text = "Game Clear";
            _GameClearText.gameObject.SetActive(true);

            _isPlay = false;


        }
    }

    public void AddTime(float time)
    {
        _lapTime += time;
    }

    public void MinusTime(float time)
    {
        _lapTime -= time;
    }

    public void GameOver()
    {
        _EnemyBallCtrl.StopAllBalls();

        _isPlay = false;

        _GameClearText.text = "Game Over";
        _GameClearText.gameObject.SetActive(true);
        // 게임 일시정지
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlay)
        {
            _spendTime += Time.deltaTime;

            if (_spendTime >= _lapTime)
            {
                GameOver();
                _isPlay = false;
            }
            else
            {
                _PlayTimeText.text = "PlayTime: " + (_lapTime - _spendTime).ToString("0.00");
            }

        }

    }
}
