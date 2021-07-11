using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject crankDown;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (crankDown.gameObject == isActiveAndEnabled)
        {
            gameObject.SetActive(true);
        }
    }
}
