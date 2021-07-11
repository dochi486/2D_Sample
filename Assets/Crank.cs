﻿using UnityEngine;

public class Crank : MonoBehaviour
{

    public GameObject down;
    public GameObject up;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.transform.name);
        if (collision.CompareTag("Player"))
        {
            down.gameObject.SetActive(true);
            up.gameObject.SetActive(false);
        }  
        //else if (collision.CompareTag("Player"))
        //{
        //    down.gameObject.SetActive(false);
        //    up.gameObject.SetActive(true);
        //}
    }
}
