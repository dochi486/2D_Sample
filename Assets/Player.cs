using System.Collections;

using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Animator animator;
    Vector2 move = Vector2.zero;
    public GameObject playerSprite;
    public float jumpForce = 30;
    Rigidbody2D rigid;

    public PlayerState state = PlayerState.Idle;
    PlayerState State
    {
        get { return state; }
        set
        {
            if (state == value)
                return;
            state = value;
            animator.Play(state.ToString());

        }
    }
    public enum PlayerState
    {
        Idle,
        Run,
        Attack,
        Jump
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponentInChildren<Rigidbody2D>();
    }
    void Update()
    {
        Move();

        if (move.x >= 0)
            playerSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);

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

    public AnimationCurve jumpYac;
    public float jumpYMultiply = 20;
    public float jumpTimeMultiply = 1;

    private IEnumerator JumpCo()
    {


        State = PlayerState.Jump;
        float jumpStartTime = Time.time;
        float jumpDuration = jumpYac[jumpYac.length - 1].time;
        jumpDuration *= jumpTimeMultiply;
        float jumpEndTime = jumpStartTime + jumpDuration;
        float sumEvaluateTime = 0;

        while (Time.time < jumpEndTime)
        {
            float y = jumpYac.Evaluate(sumEvaluateTime / jumpTimeMultiply);
            y *= jumpYMultiply;
            transform.Translate(0, y, 0);
            yield return null;
            sumEvaluateTime += Time.deltaTime;

        }
        State = PlayerState.Idle;
    }

    private void Move()
    {
        if (State != PlayerState.Idle || State != PlayerState.Run)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                State = PlayerState.Attack;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            move.x = -1;
            State = PlayerState.Run;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move.x = 1;
            State = PlayerState.Run;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(new Vector2(0, jumpForce));
            State = PlayerState.Jump;
        }
        else
        {
            State = PlayerState.Idle;
            return;
        }

        if (move.sqrMagnitude > 0)
        {
            transform.Translate(speed * move * Time.deltaTime);
        }
        else
            return;
    }
}
