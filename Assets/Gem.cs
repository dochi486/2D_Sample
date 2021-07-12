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
            gem.enabled = true;
            animator.Play("gem");
        }
    }
}
