using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    private float _health = 100.0f;
    private bool _isDead = false;

    private Animator _animator;
    private SpriteRenderer _renderer;
    private float _speed = 2.0f;

    private Rigidbody _rigid;

    [SerializeField] private BoxCollider _leftAttackCollider;
    [SerializeField] private BoxCollider _rightAttackCollider;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();

        _leftAttackCollider.enabled = false;
        _rightAttackCollider.enabled = false;
    }

    public void StartAttack()
    {

        // 플레이어가 왼쪽을 보고 공격
        if (_renderer.flipX)
        {
            _leftAttackCollider.enabled = true;
            _rightAttackCollider.enabled = false;
        }
        // 플레이어가 오른쪽을 보고 공격
        else
        {
            _leftAttackCollider.enabled = false;
            _rightAttackCollider.enabled = true;

        }
    }

    public void EndAttack()
    {
        _leftAttackCollider.enabled = false;
        _rightAttackCollider.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollisionEnter _health = {_health}");
        if (collision.collider.tag.CompareTo("Rock") == 0)
        {
            _health -= 50.0f;

            if (_health <= 0.0f && !_isDead)
            {

                // 죽는 애니메이션 플레이.
                Dead();

            }
        }
    }

    void Dead()
    {
        _isDead = true;
        _animator.SetBool("IsDead", true);
    }


    public void IsDead()
    {
        Invoke("DeadOk", 2.0f);
    }

    public void DeadOk()
    {
        this.gameObject.SetActive(false);
    }

    /*

    void OnAnimatorMove()
    {
        Debug.Log("OnAnimationMove");

        //Move();
    }
    */

    void Move()
    {
        float xmove = Input.GetAxis("Horizontal"); // -1 ~ 1

        //Debug.Log($"xmove = {xmove}");

        if (xmove < 0.0f)
        {
            _renderer.flipX = true;
            xmove = -xmove;
            _animator.SetFloat("Walk", xmove);

            Vector3 movePos = new Vector3(-xmove, 0.0f, 0.0f).normalized * _speed * Time.deltaTime;
            //Debug.Log($"movePos = {movePos}");

            this.transform.position += movePos;
            //_rigid.position += movePos;
        }
        else if (xmove > 0.0f)
        {
            _renderer.flipX = false;
            _animator.SetFloat("Walk", xmove);
            this.transform.position += new Vector3(xmove, 0.0f, 0.0f).normalized * _speed * Time.deltaTime;
            //_rigid.position += new Vector3(xmove, 0.0f, 0.0f).normalized * _speed * Time.deltaTime;
        }
        else
        {
            _animator.SetFloat("Walk", xmove);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDead)
        {
            Move();


            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetInteger("AttackType", 1);
                _animator.SetTrigger("Attack");
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _animator.SetInteger("AttackType", 2);
                _animator.SetTrigger("Attack");
            }

        }

    }
}
