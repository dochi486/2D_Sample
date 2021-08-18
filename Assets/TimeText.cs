using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = transform.Find("TimeText").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = $"{DateTime.Now.ToString("HH:mm:ss")}";
    }
}
