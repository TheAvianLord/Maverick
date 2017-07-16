using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour {
    public float speed;
    public Sprite[] colors;
    public Sprite[] damageds;
    public Sprite[] demolisheds;
    public float[] speeds;
    public int health;
    public int color_num;
    public SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color_num = Random.Range(0, 3);
        spriteRenderer.sprite = colors[color_num];
        speed = speeds[Random.Range(0, 3)];
        health = 100;
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

        //change sprite based on health
        if (health <= 50)
        {
            spriteRenderer.sprite = damageds[color_num];
        }

        if (health <= 0)
        {
            spriteRenderer.sprite = demolisheds[color_num];
            speed = 3;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Melee" && Input.GetMouseButton(0))
        {
            health -= 100;
        }

        else if (other.tag == "Bullet")
        {
            health -= 10;
        }
    }

}
