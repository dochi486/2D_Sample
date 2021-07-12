using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject chest;
    SpriteRenderer gem;

    private void Start()
    {
        gem = GetComponentInChildren<SpriteRenderer>();
        gem.enabled = false;
    }
    private void Update()
    {
        if (chest.activeInHierarchy == true)
            gem.enabled = true;
    }
}
