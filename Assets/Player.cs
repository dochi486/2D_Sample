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
    }

    private void Move()
    {
        if (state != PlayerState.Idle || state != PlayerState.Run)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = PlayerState.Attack;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x = -1;
            state = PlayerState.Run;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move.x = 1;
            state = PlayerState.Run;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(new Vector2(0, jumpForce));
            state = PlayerState.Jump;
        }
        else
        {
            state = PlayerState.Idle;
            return;
        }

        if (move.sqrMagnitude > 0)
        {
            transform.Translate(speed * move * Time.deltaTime);
        }
    }
}
