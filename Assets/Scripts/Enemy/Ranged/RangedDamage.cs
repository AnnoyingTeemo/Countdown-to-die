using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDamage : MonoBehaviour
{
    public int damage;
    public Countdown countdown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8) {
            if (collision.gameObject.layer == 6) {
                countdown.removeTime(damage);
            }

            Destroy(gameObject);
        }
    }
}
