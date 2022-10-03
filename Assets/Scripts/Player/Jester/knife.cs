using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6) {
            if (collision.gameObject.layer == 8) {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
