using UnityEngine;

public class Crank : MonoBehaviour
{

    public GameObject down;
    public GameObject up;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == gameObject.CompareTag("Player"))
        {
            down.SetActive(true);
            Debug.Log(collision.transform.name);
            up.SetActive(false);
        }
    }
}
