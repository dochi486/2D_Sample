using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Image[] healthImages;


    public string loadSceneName;
    public int maxHealth = 4;
    void Start()
    {
        healthImages = GetComponentsInChildren<Image>();
        
    }

    void Update()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            if (Player.instance.hp <= maxHealth)
            {
                healthImages[i].enabled = true;
            }
            else if (Player.instance.hp == 0)
            {
                StartCoroutine(GameOverCo());
                UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneName);
            }
            else
            {
                healthImages[i].enabled = false;
            }
        }
        //switch (Player.instance.hp)
        //{
        //    case 4:
        //        healthImages[0].enabled = true;
        //        break;
        //    case 3:
        //        healthImages[0].enabled = false;
        //        healthImages[1].enabled = true;
        //        break;
        //    case 2:
        //        healthImages[2].enabled = true;
        //        healthImages[0].enabled = false;
        //        healthImages[1].enabled = false;
        //        break;
        //    case 1:
        //        healthImages[3].enabled = true;
        //        healthImages[0].enabled = false;
        //        healthImages[1].enabled = false;
        //        healthImages[2].enabled = false;
        //        break;
        //    case 0:
        //        StartCoroutine(GameOverCo());
        //        UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneName);
        //        break;
        //}

    }
    public float gameEndTime = 5;
    IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(gameEndTime);
    }
}
