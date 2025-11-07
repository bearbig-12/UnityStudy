using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Test;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    void Walk()
    {
        _renderer.flipX = _dir;

        if (_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;
            _animIndex++;

            if (_animIndex >= _walkSprites.Length)
            {
                _animIndex = 0;
            }

            _renderer.sprite = _walkSprites[_animIndex];
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
            }

            _renderer.sprite = _attackSprite[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }


    void Move()
    {
        float xmove = Input.GetAxis("Horizontal"); // -1 ~ 1

        if (xmove < 0.0f)
        {
            _dir = true;
        }
        else if (xmove > 0.0f)
        {
            _dir = false;
        }
        else
        {

        }

        this.transform.position += new Vector3(xmove, 0.0f, 0.0f).normalized * _walkSpeed * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Walk();
        //Idle();
        Attack();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animIndex = 0;
        }

    }
}
