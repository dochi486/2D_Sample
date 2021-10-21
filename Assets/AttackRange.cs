using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Monster") == false)
    //        return;
    //    GetComponentInParent<Player>().OnHit(other);
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        int hp = Player.instance.hp;
        PlayerState State = Player.instance.State;
        if (collision.CompareTag("Monster"))
        {
            if (hp > 0)
            {
                hp--;
                State = PlayerState.TakeHit;
            }
            else if (hp <= 0)
                State = PlayerState.Die;
            else
                State = PlayerState.Idle;
        }
        else
        {
            print("안 맞았다");
        }

    }
}
