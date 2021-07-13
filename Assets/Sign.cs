using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Image sign;
    public TextMeshProUGUI text;
    Animator animatorSign;
    Animator animatorText;

    private void Awake()
    {
        animatorSign = sign.GetComponent<Animator>();
        animatorText = text.GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SignCo());
        }
    }
    public float animationTime = 0.6f;
    IEnumerator SignCo()
    {
        sign.gameObject.SetActive(true);
        text.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);
        animatorText.Play("TextFadeOut");
        animatorSign.Play("SignTextBoxFadeOut");

        yield return new WaitForSeconds(animationTime);

        sign.gameObject.SetActive(false);
        text.gameObject.SetActive(false);

    }
}
