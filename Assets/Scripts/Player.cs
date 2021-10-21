using System;
using System.Collections;

using UnityEngine;

public enum PlayerState
{
    Idle,
    Run,
    Attack,
    Jump,
    TakeHit,
    Die
}

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Animator animator;
    public Vector2 move = Vector2.zero;
    public GameObject playerSprite;
    public int hp = 4;
    public static Player instance;
    public PlayerState m_state = PlayerState.Idle;

    //internal void OnHit(Collider other)
    //{
    //    var monster = other.GetComponent<Monster>();
    //    //monster.
    //    //AttackCollider로 몬스터 피격 판정하려면 몬스터 스크립트 피격 부분 구조 바꿔야함
    //}

    Rigidbody2D rigid;
    public Vector2 jumpForce = new Vector2(0, 500);
    public int power = 2;

    //todo: 점프했다가 떨어질 때 조금 더 자연스럽게 고쳐야함
    //todo: 카메라 범위 고정
    //todo: 플레이어 죽고 나서 죽는 모션 끝나는 거 기다렸다가 게임오버 띄우기
    //[완료]: 피격 후에 idle로 잠시 멈춰있는 문제 해결 
    //todo: 언덕에서 어떻게하면 자연스럽게 이동할지 고민 -> 정 방법이 없으면 언덕 말고 계단으로 맵 수정


    internal PlayerState State
    {
        get { return m_state; }
        set
        {
            if (m_state == value)
                return;
            Debug.LogWarning($"{m_state} -> {value}로 변함");

            m_state = value;
            animator.Play(m_state.ToString());
        }
    }


    private void Awake()
    {
        instance = this;
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public Vector2 previousPos;
    public Vector2 currentPos;
    void Update()
    {
        Attack();
        Move();
        Jump();
    }

    private void Jump()
    {

        if (State == PlayerState.Jump)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(JumpCo());
        }
    }
    public float jumpAnimationTime = 0.5f;
    IEnumerator JumpCo()
    {
        State = PlayerState.Jump;

        rigid.velocity = Vector2.zero;
        rigid.AddForce(jumpForce);

        yield return new WaitForSeconds(jumpAnimationTime);
        State = PlayerState.Idle;
    }

    //todo: 점프 코루틴 없애고 레이로 땅 판정하게 해보기?

    private void Move()
    {

        move = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move.x += 1;
        }

        if (move.sqrMagnitude > 0)
        {
            UpdateRotation(move.x);
            transform.Translate(speed * move * Time.deltaTime, Space.World);

            if (State != PlayerState.Jump && State != PlayerState.Attack)
                State = PlayerState.Run;
        }
        else
        {
            if (State != PlayerState.Jump && State != PlayerState.Attack)
                State = PlayerState.Idle;
        }

        //currentPos = transform.position;

        //if (previousPos.x < currentPos.x)
        //    transform.rotation = Quaternion.Euler(0, 180, 0);
        //else if (previousPos.x > currentPos.x)
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        ////여기서 playersprite를 돌려줬었는데 그걸 transform rotation으로 하니까 버그 생김..

        //previousPos = currentPos;

    }

    private void UpdateRotation(float currentMove)
    {
        if (currentMove == 0)
            return;

        transform.rotation = Quaternion.Euler(0, currentMove < 0 ? 0 : 180, 0);
    }

    private void Attack()
    {
        if (State != PlayerState.Idle || State != PlayerState.Run)

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(AttackCo());
            }

    }

    public float attackTime = 0.3f;
    private IEnumerator AttackCo()
    {
        State = PlayerState.Attack;
        yield return new WaitForSeconds(attackTime);
        State = PlayerState.Idle;
    }


}

