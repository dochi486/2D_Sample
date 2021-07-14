using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    Animator animator;
    SpriteRenderer star;
    void Start()
    {
        animator = GetComponent<Animator>();
        star = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(StarFadeCo());
        }
    }
    public float animationTime = 0.55f;

    IEnumerator StarFadeCo()
    {
        animator.Play("Star_fade");

        yield return new WaitForSeconds(animationTime);

        star.enabled = false;
    }
}
