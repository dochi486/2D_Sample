using System.Collections;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject chest;
    SpriteRenderer gem;
    Animator animator;

    private void Start()
    {
        gem = GetComponentInChildren<SpriteRenderer>();
        gem.enabled = false;
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (chest.activeInHierarchy == true)
        {
            StartCoroutine(GemFadeCo());
        }
    }
    public float animationTime = 0.5f;
   IEnumerator GemFadeCo()
    {
        gem.enabled = true;
        animator.Play("gem");

        yield return new WaitForSeconds(animationTime);
        yield return null;
        this.gameObject.SetActive(false);
    }
}
