using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    Vector2 move = Vector2.zero;
    public GameObject playerSprite;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            move.x = -1;
        if (Input.GetKey(KeyCode.D))
            move.x = 1;

        if (move.sqrMagnitude > 0)
            transform.Translate(speed * move * Time.deltaTime);

        if (move.x >= 0)
            playerSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
