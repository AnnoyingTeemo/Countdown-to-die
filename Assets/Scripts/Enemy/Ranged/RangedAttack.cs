using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private Chase chase;
    public Countdown countdown;

    public GameObject attackObject;
    public int attackSpeed;
    public GameObject player;
    public float attackCooldown;

    private bool attackOnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        chase = gameObject.GetComponent<Chase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chase.inChase && !attackOnCooldown) {
            Vector3 aimPosition = player.transform.position;

            GameObject newAttack = Instantiate(attackObject, gameObject.transform.position, gameObject.transform.rotation);

            newAttack.GetComponent<RangedDamage>().countdown = countdown;

            Quaternion rotation = Quaternion.LookRotation(aimPosition - transform.position, transform.TransformDirection(Vector3.up));

            newAttack.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(aimPosition.y - transform.position.y, aimPosition.x - transform.position.x) * Mathf.Rad2Deg - 90);

            newAttack.GetComponent<Rigidbody2D>().AddForce((player.transform.position - gameObject.transform.position) * attackSpeed);

            StartCoroutine("BeginKnifeCooldown");
        }
    }

    private IEnumerator BeginKnifeCooldown()
    {
        attackOnCooldown = true;

        yield return new WaitForSeconds(attackCooldown);

        attackOnCooldown = false;
    }
}
