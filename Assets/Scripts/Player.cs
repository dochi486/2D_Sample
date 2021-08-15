using System.Collections;

using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Animator animator;
    public Vector2 move = Vector2.zero;
    public GameObject playerSprite;
    public int hp = 4;
    public static Player instance;
    public PlayerState m_state = PlayerState.Idle;
    Rigidbody2D rigid;
    public Vector2 jumpForce = new Vector2(0, 500);
    public int power = 2;

    //todo: 점프했다가 떨어질 때 조금 더 자연스럽게 고쳐야함
    //todo: 카메라 범위 고정
    //todo: 플레이어 죽고 나서 죽는 모션 끝나는 거 기다렸다가 게임오버 띄우기
    //[완료]: 피격 후에 idle로 잠시 멈춰있는 문제 해결 
    //todo: 언덕에서 어떻게하면 자연스럽게 이동할지 고민 -> 정 방법이 없으면 언덕 말고 계단으로 맵 수정


    PlayerState State
    {
        get { return m_state; }
        set
        {
            if (m_state == value)
                return;
            //Debug.LogWarning($"{state} -> {value}로 변함");

            m_state = value;
            animator.Play(m_state.ToString());
        }
    }
    public enum PlayerState
    {
        Idle,
        Run,
        Attack,
        Jump,
        TakeHit,
        Die
    }

    private void Awake()
    {
        instance = this;
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public Vector2 previousPos;
    public Vector2 CurrentPos;
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

    //public AnimationCurve jumpYac;
    //public float jumpYMultiply = 20;
    //public float jumpTimeMultiply = 1;

    //private IEnumerator JumpCo()
    //{
    //    State = PlayerState.Jump;
    //    float jumpStartTime = Time.time;
    //    float jumpDuration = jumpYac[jumpYac.length - 1].time;
    //    jumpDuration *= jumpTimeMultiply;
    //    float jumpEndTime = jumpStartTime + jumpDuration;
    //    float sumEvaluateTime = 0;

    //    float jumpStartY = transform.position.y;
    //    while (Time.time < jumpEndTime)
    //    {
    //        float y = jumpYac.Evaluate(sumEvaluateTime / jumpTimeMultiply);
    //        y *= jumpYMultiply;
    //        float currentY = jumpStartY + y;
    //        var trPos = transform.position;
    //        trPos.y = currentY;
    //        transform.position = trPos;
    //        yield return null;
    //        sumEvaluateTime += Time.deltaTime;
    //    }

    //    State = PlayerState.Idle;
    //}

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
            transform.Translate(speed * move * Time.deltaTime);

            if (State != PlayerState.Jump && State != PlayerState.Attack)
                State = PlayerState.Run;
        }
        else
        {
            if (State != PlayerState.Jump && State != PlayerState.Attack)
                State = PlayerState.Idle;
        }

        CurrentPos = transform.position;

        if (previousPos.x < CurrentPos.x)
            playerSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (previousPos.x > CurrentPos.x)
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);

        previousPos = CurrentPos;

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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Monster monster = collision.gameObject.GetComponent<Monster>();

    //    if (collision.CompareTag("Monster"))
    //        hp -= monster.damage;

    //    //if (monster == null || monster.hp <= 0)
    //    //    return;
    //    //else
    //    //{
    //    //    hp -= monster.damage;
    //    //    //StartCoroutine(HitCo());
    //    //    //if (hp <= 0)
    //    //    //{
    //    //    //StartCoroutine(DieCo());
    //    //    //}

    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            if (hp > 0)
            {
                hp--;
                State = PlayerState.TakeHit;
            }
            else if (hp <= 0)
                State = PlayerState.Die;
            else
                State = PlayerState.Idle;
        }


    }
}
//public float delayHit = 0.3f;
//IEnumerator HitCo()
//{
//    state = PlayerState.Attacked;
//    //animator.Play("Damage");
//    yield return new WaitForSeconds(delayHit);
//    state = PlayerState.Idle;
//}


