using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public Countdown countdown;

    private Health health;

    public int timeDamage;

    private void Start()
    {
        health = gameObject.GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) {
            GameObject player = collision.gameObject;
            countdown.removeTime(timeDamage);
            health.timeValue += 2;
            health.Heal(2);
            player.GetComponent<Rigidbody2D>().AddForce((player.transform.position - gameObject.transform.position) * 4000);
        }
    }
}
