using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float x_mov;
    public float y_mov;
	
	// Update is called once per frame
	void Update ()
    {
        x_mov = Input.GetAxis("Horizontal");
        y_mov = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(x_mov * speed, y_mov * speed);
    }

}
