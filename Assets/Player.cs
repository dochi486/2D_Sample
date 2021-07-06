using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Animator animator;
    Vector2 move = Vector2.zero;
    public GameObject playerSprite;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
            animator.Play("Attack"); //어택에서 자꾸 Idle로 가버리는 현상 -> 애니메이션 길이 구해서 끝나면 idle하도록

        if (move.x >= 0)
            playerSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
            move.x = -1;
        else if (Input.GetKey(KeyCode.D))
            move.x = 1;
        else if (Input.GetKey(KeyCode.W))
            move.y = 1; //위로 이동해버리네~ 점프가 아니라~
        else
        {
            animator.Play("Idle");
            return;
        }

        if (move.sqrMagnitude > 0)
        {
            transform.Translate(speed * move * Time.deltaTime);
            animator.Play("Run");
        }
    }
}
