using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Image hpStatus5;
    public Image hpStatus4;
    public Image hpStatus3;
    public Image hpStatus2;
    public string loadSceneName;
    void Start()
    {
        hpStatus4.enabled = false;
        hpStatus3.enabled = false;
        hpStatus2.enabled = false;
    }

    void Update()
    {

        switch (Player.instance.hp)
        {
            case 4:
                hpStatus5.enabled = true;
                break;
            case 3:
                hpStatus5.enabled = false;
                hpStatus4.enabled = true;
                break;
            case 2:
                hpStatus3.enabled = true;
                hpStatus4.enabled = false;
                hpStatus5.enabled = false;
                break;
            case 1:
                hpStatus2.enabled = true;
                hpStatus3.enabled = false;
                hpStatus4.enabled = false;
                hpStatus5.enabled = false;
                break;
            case 0:
                StartCoroutine(GameOverCo());
                UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneName);
                break;
        }

    }
    public float gameEndTime = 5;
    IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(gameEndTime);
    }
}
