using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject crankDown;


    // Update is called once per frame
    void Update()
    {
        if (crankDown.activeInHierarchy == true)
        {
            //sprite.SetActive(true);
            print("Trap Activated");
        }
    }
}
