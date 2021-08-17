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
        animator = GetComponentInChildren<Animator>(true); 
        //꺼져있는 GameObject의 컴포넌트를 get하려면 파라미터로 true를 주면 됨
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
        //단순한 TriggerEnter에서 FSM으로 변환해야함
        if (collision.gameObject.GetComponent<Player>() == null)
        {
            Debug.Log("안 맞았다");
            return;
        }
        else if (collision.gameObject.GetComponent<Player>() != null)
        {
            hp -= Player.instance.power;
            animator.Play("Hit");
            //애니메이터가 null인 이유 찾기 -> 꺼져있는 오브젝트의 애니메이터를 겟컴포넌트로 가져오려고 해서
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
    //공격하는 모션? -> 공격 애니메이션 있는 2D 애셋 몬스터 필요
    //

}
