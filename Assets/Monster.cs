using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster :  Crank
{
    public GameObject crankDown;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrapActivated == true)
        {
            gameObject.SetActive(true);
            print("Trap Activated");
        }
    }
}
