using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 10;
    public float offset = -90f;

    public Vector3 shootDirection;
    

    // Use this for initialization
    void Start ()
    {
        //rotate it, doesnt work yet

        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
	
	// Update is called once per frame
	void Update ()
    {
        //should start moving in direction, doesnt work yet
        GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);

        if (transform.position.y < -2.0 || transform.position.y > 2.0 || transform.position.x > 1.6 || transform.position.x < -1.6)
        {
            Destroy(gameObject);
        }

    }
}
