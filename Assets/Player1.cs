using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float horizontal;
    public Rigidbody2D body;
    public GameObject bullet;
    public float speed = 5, jumpStrength = 5, bulletSpeed = 8;
    Collider2D footCollision;
    bool groundCheck;
    public Transform foot;
    public int direction = -1;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);


        footCollision = Physics2D.OverlapCircle(foot.position, 0.05f);
        groundCheck = footCollision;
        if (Input.GetButtonDown("Vertical") && groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrength * 100));

        }
        if (horizontal != 0)
        {
            direction = (int)horizontal;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject temp = Instantiate(bullet, transform.position, foot.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0);
        }
    }
}


