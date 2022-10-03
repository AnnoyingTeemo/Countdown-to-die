using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 location;

    float xLocation;
    float yLocation;

    public float speed;

    private Rigidbody2D rgbdy2d;

    public GameObject camera;

    public LineRenderer line;

    public GameObject knife;

    private bool knifeOnCooldown = false;
    public float knifeCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rgbdy2d = gameObject.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) {
            camera.GetComponent<Countdown>().removeTime(20);
        }
        if (Input.GetMouseButton(2)) {
            line.positionCount = 2;
            CheckAttack();
        }
        if (Input.GetMouseButtonUp(2)) {
            line.positionCount = 0;
        }
        if (Input.GetMouseButtonDown(0) && !knifeOnCooldown) {
            ThrowKnife();
            StartCoroutine("BeginKnifeCooldown");
        }
    }

    void FixedUpdate()
    {
        rgbdy2d.velocity = new Vector2(0,0);

        if (Input.GetKey(KeyCode.W)) {
            rgbdy2d.AddForce(transform.up * speed);
        }
        if (Input.GetKey(KeyCode.S)) {
            rgbdy2d.AddForce(-transform.up * speed);
        }
        if (Input.GetKey(KeyCode.A)) {
            rgbdy2d.AddForce(-transform.right * speed);
        }
        if (Input.GetKey(KeyCode.D)) {
            rgbdy2d.AddForce(transform.right * speed);
        }
    }

    public void ThrowKnife() {
        Vector3 aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
        
        GameObject newKnife = Instantiate(knife, gameObject.transform.position, gameObject.transform.rotation);

        Quaternion rotation = Quaternion.LookRotation(aimPosition - transform.position, transform.TransformDirection(Vector3.up));

        newKnife.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(aimPosition.y - transform.position.y, aimPosition.x - transform.position.x) * Mathf.Rad2Deg - 90);

        Vector3 posInScreen = Camera.main.WorldToScreenPoint(transform.position);

        //You can calculate the direction from point A to point B using Vector3 dirAtoB = B - A;
        Vector3 dirToMouse = Input.mousePosition - posInScreen;

        //We normalize the direction (= make length of 1). This is to avoid the object moving with greater force when I click further away
        dirToMouse.Normalize();

        //Adding the force to the 2D Rigidbody, multiplied by forceAmount, which can be set in the Inspector
        newKnife.GetComponent<Rigidbody2D>().AddForce(dirToMouse * 500);
    }

    private void CheckAttack() {
        Vector2 aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;

        //obj.transform.position = aimPosition;

        Vector2 fromPosition = transform.position;
        Vector2 toPosition = aimPosition;
        Vector2 direction = toPosition - fromPosition;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 100);
        if (hit.collider != null) {
            //Debug.Log(hit.collider.gameObject.name);
            Debug.DrawRay(transform.position, (hit.point - fromPosition), Color.red);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.point);
        }
        else {
            Debug.DrawRay(transform.position, direction * 100, Color.red);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, direction * 100);
        }
    }

    private IEnumerator BeginKnifeCooldown() {
        knifeOnCooldown = true;

        yield return new WaitForSeconds(knifeCooldown);

        knifeOnCooldown = false;
    }
}
