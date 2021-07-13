using UnityEngine;

public class Crank : MonoBehaviour
{

    public GameObject down;
    public GameObject up;

    public bool isTrapActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTrapActivated = true;
            down.gameObject.SetActive(true);
            up.gameObject.SetActive(false);
        }  
    }
}
