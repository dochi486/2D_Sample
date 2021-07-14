using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjects : MonoBehaviour
{
    public GameObject objectOff; //플레이어와 닿기 전에 켜져있는 오브젝트
    public GameObject objectOn; //플레이어와 충돌하면 켜지는 오브젝트

    public bool isObjectActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isObjectActivated = true;
            objectOff.gameObject.SetActive(false);
            objectOn.gameObject.SetActive(true);
        }
    }
}
