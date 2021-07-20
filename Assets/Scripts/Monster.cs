using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject crankDown;
    SpriteRenderer monsterSpriteRenderer;
    Animator animator;
    new Collider2D collider;

    private void Awake()
    {
        monsterSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        monsterSpriteRenderer.gameObject.SetActive(false);
        collider.enabled = false;
    }
    void Update()
    {
        if (crankDown.activeInHierarchy == true)
        {
            collider.enabled = true;
            monsterSpriteRenderer.gameObject.SetActive(true);
        }
    }
    public int range = 5;
    public float minWorldX;
    public float maxWorldX;
    public float speed = 5;

    public int hp = 3;
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() == null)
        {
            Debug.Log("안 맞았다");
            return;
        }
        else if (collision.gameObject.GetComponent<Player>() != null)
        {
            hp -= Player.instance.power;
            animator.Play("Hit");
            //애니메이터가 null인 이유 찾기
        }
        else
            animator.Play("Idle");
    }

    public enum DirectionType
    {
        Right,
        Left,
    }

    DirectionType direction = DirectionType.Right;


    IEnumerator Start()
    {
        animator = GetComponentInChildren<Animator>();
        minWorldX = transform.position.x - range;
        maxWorldX = transform.position.x + range;

        while (true)
        {
            //direction == DirectionType.Right
            transform.Translate(speed * Time.deltaTime, 0, 0);

            if (direction == DirectionType.Right)
            {

                if (transform.position.x > maxWorldX)
                {
                    direction = DirectionType.Left;
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    monsterSpriteRenderer.transform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }
            else
            {
                if (transform.position.x < minWorldX)
                {
                    direction = DirectionType.Right;
                    transform.rotation = Quaternion.Euler(Vector3.zero);
                    monsterSpriteRenderer.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }

            yield return null;
            //if (state == StateType.Die)
            //    yield break; //코루틴에서 함수밖으로 나갈 때는 yield break;로 할 수있따.

        }
    }

}
