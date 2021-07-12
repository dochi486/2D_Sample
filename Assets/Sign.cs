using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Image sign;
    public TextMeshProUGUI text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sign.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
        }
    }
}
