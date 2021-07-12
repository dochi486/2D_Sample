using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject closed;
    public GameObject opened;

    public bool isBoxOpened = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.transform.name);
        if (collision.CompareTag("Player"))
        {
            isBoxOpened = true;
            opened.gameObject.SetActive(true);
            closed.gameObject.SetActive(false);
        }
        //else if (collision.CompareTag("Player"))
        //{
        //    down.gameObject.SetActive(false);
        //    up.gameObject.SetActive(true);
        //}
    }
}
