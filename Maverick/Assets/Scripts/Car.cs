using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour {
    public float speed;
    public Sprite[] colors;
    public float[] speeds;

    // Use this for initialization
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = colors[Random.Range(0, 3)];
        speed = speeds[Random.Range(0, 3)];
    }

    // Update is called once per frame
    void Update()
    {
        //speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, - speed);

        //delete if off screen
        if (transform.position.y < -2.5)
        {
            Destroy(gameObject);
        }
    }

}
