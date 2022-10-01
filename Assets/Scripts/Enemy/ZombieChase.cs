using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChase : MonoBehaviour
{
    public MonoBehaviour destinationSetter;
    public MonoBehaviour patrol;

    // Start is called before the first frame update
    void Start()
    {
        destinationSetter.enabled = false;
        patrol.enabled = true;
    }

    private void Update()
    {
        bool playerFound = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 10);
        if (hit.collider != null) {
            if (hit.collider.gameObject.name == "Player") {
                playerFound = true;
                activateDestinationSetter();
                Debug.DrawRay(transform.position, transform.up * 10, Color.green);
            }
        }

        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, (transform.up + transform.right).normalized, 10);
        if (hit2.collider != null) {
            if (hit2.collider.gameObject.name == "Player") {
                playerFound = true;
                activateDestinationSetter();
                Debug.DrawRay(transform.position, (transform.up + transform.right).normalized * 10, Color.green);
            }
        }

        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, (transform.up - transform.right).normalized, 10);
        if (hit3.collider != null) {
            if (hit3.collider.gameObject.name == "Player") {
                playerFound = true;
                activateDestinationSetter();
                Debug.DrawRay(transform.position, (transform.up - transform.right).normalized * 10, Color.green);
            }
        }

        RaycastHit2D hit4 = Physics2D.Raycast(transform.position, (transform.up + transform.right / 2).normalized, 10);
        if (hit4.collider != null) {
            if (hit4.collider.gameObject.name == "Player") {
                playerFound = true;
                activateDestinationSetter();
                Debug.DrawRay(transform.position, (transform.up + transform.right / 2).normalized * 10, Color.green);
            }
        }

        RaycastHit2D hit5 = Physics2D.Raycast(transform.position, (transform.up - transform.right / 2).normalized, 10);
        if (hit5.collider != null) {
            if (hit5.collider.gameObject.name == "Player") {
                playerFound = true;
                activateDestinationSetter();
                Debug.DrawRay(transform.position, (transform.up - transform.right / 2).normalized * 10, Color.green);
            }
        }

        RaycastHit2D hit6 = Physics2D.Raycast(transform.position, (transform.up - transform.right / 4).normalized, 10);
        if (hit6.collider != null) {
            if (hit6.collider.gameObject.name == "Player") {
                playerFound = true;
                activateDestinationSetter();
                Debug.DrawRay(transform.position, (transform.up - transform.right / 4).normalized * 10, Color.green);
            }
        }

        RaycastHit2D hit7 = Physics2D.Raycast(transform.position, (transform.up + transform.right / 4).normalized, 10);
        if (hit7.collider != null) {
            if (hit7.collider.gameObject.name == "Player") {
                playerFound = true;
                activateDestinationSetter();
                Debug.DrawRay(transform.position, (transform.up + transform.right / 4).normalized * 10, Color.green);
            }
        }

        RaycastHit2D hit8 = Physics2D.Raycast(transform.position, (transform.up + transform.right - transform.right / 4).normalized, 10);
        if (hit8.collider != null) {
            if (hit8.collider.gameObject.name == "Player") {
                playerFound = true;
                activateDestinationSetter();
                Debug.DrawRay(transform.position, (transform.up + transform.right - transform.right / 4).normalized * 10, Color.green);
            }
        }

        RaycastHit2D hit9 = Physics2D.Raycast(transform.position, (transform.up - transform.right + transform.right / 4).normalized, 10);
        if (hit9.collider != null) {
            if (hit9.collider.gameObject.name == "Player") {
                playerFound = true;
                activateDestinationSetter();
                Debug.DrawRay(transform.position, (transform.up - transform.right + transform.right / 4).normalized * 10, Color.green);
            }
        }

        if (!playerFound) {
            activatePatrol();
        }
    }

    private void activateDestinationSetter() {
        destinationSetter.enabled = true;
        patrol.enabled = false;
    }

    private void activatePatrol() {
        destinationSetter.enabled = false;
        patrol.enabled = true;
    }
}
