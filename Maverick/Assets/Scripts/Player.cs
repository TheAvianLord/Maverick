using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float x_mov;
    public float y_mov;
    public Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        x_mov = Input.GetAxis("Horizontal");
        y_mov = Input.GetAxis("Vertical");

        myAnimator.SetBool("forward", Input.GetKey(KeyCode.W));
        myAnimator.SetBool("right", Input.GetKey(KeyCode.D));
        myAnimator.SetBool("left", Input.GetKey(KeyCode.A));
        GetComponent<Rigidbody2D>().velocity = new Vector2(x_mov * speed, y_mov * speed);
    }

}
