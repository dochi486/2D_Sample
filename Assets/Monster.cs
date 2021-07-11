using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject crankDown;
    SpriteRenderer beeSprite;

    private void Awake()
    {
        beeSprite = GetComponentInChildren<SpriteRenderer>();
        
    }

    private void Start()
    {
        beeSprite.gameObject.SetActive(false);
    }
    void Update()
    {
        if (crankDown.activeInHierarchy == true)
        {
            beeSprite.gameObject.SetActive(true);
        }
    }
}
