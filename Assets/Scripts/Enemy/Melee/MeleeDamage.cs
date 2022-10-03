using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public Countdown countdown;

    public int timeDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) {
            GameObject player = collision.gameObject;
            countdown.removeTime(timeDamage);
            player.GetComponent<Rigidbody2D>().AddForce((player.transform.position - gameObject.transform.position) * 4000);
        }
    }
}
