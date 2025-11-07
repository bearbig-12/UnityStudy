using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Test;
using UnityEngine;

public enum PlayerState
{
    Walk,
    Idle,
    Attack
};

public class Sprite2DTest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite[] _walkSprites;
    [SerializeField] private Sprite[] _idleSprites;
    [SerializeField] private Sprite[] _attackSprite;


    private int _animIndex = 0;

    private float _nextFrameTime = 0.1f;
    private float _spendTime = 0.0f;

    private bool _dir = true;
    private float _walkSpeed = 2.0f;

    private PlayerState _currentState = PlayerState.Idle; //  현재 상태 저장.


    // Start is called before the first frame update
    void Start()
    {
        _renderer.sprite = _walkSprites[_animIndex];

    }

    void Walk()
    {
        _renderer.flipX = _dir;

        if (_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;

            if (_animIndex >= _walkSprites.Length)
            {
                _animIndex = 0;
            }

            _renderer.sprite = _walkSprites[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }

    void Idle()
    {
        if (_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;

            if (_animIndex >= _idleSprites.Length)
            {
                _animIndex = 0;
            }

            _renderer.sprite = _idleSprites[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }

    void Attack()
    {
        if (_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;

            if (_animIndex >= _attackSprite.Length)
            {
                _animIndex = 0;

                // Attack 애니메이션이 끝났을때 idle상태로 변경.
                _currentState = PlayerState.Idle;
            }

            _renderer.sprite = _attackSprite[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }


    void Move()
    {
        float xmove = Input.GetAxis("Horizontal"); // -1 ~ 1


        switch (_currentState)
        {
            case PlayerState.Walk:
                Walk();
                this.transform.position += new Vector3(xmove, 0.0f, 0.0f).normalized * _walkSpeed * Time.deltaTime;
                break;

            case PlayerState.Idle:
                Idle();
                break;

            case PlayerState.Attack:
                Attack();
                break;
        }

        // 키입력에 따른 상태처리
        if (xmove < 0.0f)
        {
            _currentState = PlayerState.Walk;
            _dir = true;
        }
        else if (xmove > 0.0f)
        {
            _currentState = PlayerState.Walk;
            _dir = false;
        }
        else
        {
            if (_currentState != PlayerState.Attack)
            {
                _currentState = PlayerState.Idle;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentState == PlayerState.Attack) return;

            Debug.Log("Attack");
            _animIndex = 0;

            _currentState = PlayerState.Attack;
        }

    }
}
