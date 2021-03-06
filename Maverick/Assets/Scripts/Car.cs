﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public float speed;
    public Sprite[] colors;
    public Sprite[] damageds;
    public Sprite[] demolisheds;
    public float[] speeds;
    public int health = 100;
    public int color_num;
    public SpriteRenderer spriteRenderer;
    public GameObject explosion;

    public Animator myAnimator;

    public AudioClip melee;
    public AudioClip gunHit;
    public AudioClip boom;



    public GameObject player;
    public Player playerScript;

    private bool carDead = false;

    // Use this for initialization
    void Start()
    {
        explosion.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        color_num = Random.Range(0, 3);
        spriteRenderer.sprite = colors[color_num];
        speed = speeds[Random.Range(0, 3)];


        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        //speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        //delete if off screen
        if (transform.position.y < -2.5)
        {
            Destroy(gameObject);
        }

        //change sprite based on health
        if (health <= 50 && health > 0)
        {
            spriteRenderer.sprite = damageds[color_num];
        }

        if (health <= 0)
        {
            if (carDead == false)
            {
                carDead = true;
                AudioSource.PlayClipAtPoint(boom, transform.position);
            }
            gameObject.GetComponent<Collider2D>().enabled = false;
            spriteRenderer.sprite = demolisheds[color_num];
            explosion.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            StartCoroutine(wait());

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Melee" && Input.GetMouseButton(0) && playerScript.abletohit)
        {
            StartCoroutine(flash());
            health -= 100;
            AudioSource.PlayClipAtPoint(melee, transform.position);
        }

        else if (other.tag == "Bullet")
        {
            StartCoroutine(flash());
            health -= 20;
            AudioSource.PlayClipAtPoint(gunHit, transform.position);
        }

        else if (other.tag == "EnemyBullet")
        {
            StartCoroutine(flash());
            health -= 20;
            AudioSource.PlayClipAtPoint(gunHit, transform.position);
        }


    }

    IEnumerator wait()
    {
        speed = (float)2.5;
        yield return new WaitForSeconds(0.6f);
        explosion.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    IEnumerator flash()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        //disable collider
        //gameObject.GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        //enable collider
        //gameObject.GetComponent<Collider2D>().enabled = true;
    }

}
