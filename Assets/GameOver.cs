using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    CanvasGroup blackScreen;

    private void Start()
    {
        blackScreen = GameObject.Find("PersistCanvas").transform.Find("BlackScreen").GetComponent<CanvasGroup>();
        blackScreen.gameObject.SetActive(true);
        blackScreen.alpha = 1;
        blackScreen.DOFade(0, 1.5f).OnComplete(() => blackScreen.gameObject.SetActive(false));
    }

}
