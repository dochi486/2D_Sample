using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject crankDown;
    SpriteRenderer beeSprite;
    Animator animator;

    private void Awake()
    {
        beeSprite = GetComponentInChildren<SpriteRenderer>();
        beeSprite.gameObject.SetActive(false);
    }
    void Update()
    {
        if (crankDown.activeInHierarchy == true)
        {
            beeSprite.gameObject.SetActive(true);
        }
    }
    public int range = 5;
    public float minWorldX;
    public float maxWorldX;
    public float speed = 5;
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
            
                }
            }
            else
            {
                if (transform.position.x < minWorldX)
                {
                    direction = DirectionType.Right;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }

            yield return null;
            //if (state == StateType.Die)
            //    yield break; //코루틴에서 함수밖으로 나갈 때는 yield break;로 할 수있따.

        }
    }
}
