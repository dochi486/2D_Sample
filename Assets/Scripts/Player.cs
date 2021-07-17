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
    public PlayerState state = PlayerState.Idle;
    Rigidbody2D rigid;
    public Vector2 jumpForce = new Vector2(0, 500);

    PlayerState State
    {
        get { return state; }
        set
        {
            if (state == value)
                return;
            //Debug.LogWarning($"{state} -> {value}로 변함");

            state = value;
            animator.Play(state.ToString());
        }
    }
    public enum PlayerState
    {
        Idle,
        Run,
        Attack,
        Jump,
        Hurt,
        Death
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

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(JumpCo());
        }
    }
    public float jumpAnimationTime = 0.5f;
    IEnumerator JumpCo()
    {
        State = PlayerState.Jump;
        //점프로.. State변경이 안되는데 점프 모션은 하네?
        //StartCoroutine(JumpCo());
        rigid.velocity = Vector2.zero;
        rigid.AddForce(jumpForce);

        yield return new WaitForSeconds(jumpAnimationTime);
        //점프 끝난 뒤 움직임 없으면 아이들로 안 바뀌고 점프모션 그대로 멈춰있는데..?
        State = PlayerState.Idle;
    }

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

            if (Input.GetKeyDown(KeyCode.Space))
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
            hp--;
            State = PlayerState.Hurt;
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


