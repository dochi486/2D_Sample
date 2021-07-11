using UnityEngine;

public class Crank : MonoBehaviour
{

    public GameObject down;
    public GameObject up;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //콜리젼으로 up, down 껐다 키고 싶은데

        //if (collision == gameObject.CompareTag("Player"))
        //{
        //    down.SetActive(true);
        //    Debug.Log(collision.transform.name);
        //    up.SetActive(false);
        //}
    }
}
