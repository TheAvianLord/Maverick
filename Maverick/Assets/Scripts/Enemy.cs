using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool alive;
    public float speed;
    public bool start;
    public int health = 150;
    public GameObject explosion;
    public Animator myAnimator;

    public GameObject player;
    public Player playerScript;


    public GameObject gun;
    public Gun gunScript;

    public AudioClip melee;
    public AudioClip gunHit;
    public AudioClip boom;
    public AudioClip crash;
    private AudioSource audioSource;


    // Use this for initialization
    void Start ()
    {
        alive = true;
        start = true;

        explosion.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        myAnimator = GetComponent<Animator>();

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();

        gun = GameObject.Find("Gun");
        gunScript = gun.GetComponent<Gun>();

        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (health <= 0)
        {
            if (alive == true)
            {
                alive = false;
                AudioSource.PlayClipAtPoint(boom, transform.position);
            }
        }

		if (start && transform.position.y < 0.5)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }

        if (transform.position.y >= 0.5)
        {
            start = false;
        }

        if (alive && !start)
        {
            transform.position = new Vector3((float)transform.position.x, Mathf.Abs(Mathf.Sin(Time.time)), 0);
        }

        else if (!alive)
        {

            gameObject.GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            explosion.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            StartCoroutine(wait());
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Melee" && Input.GetMouseButton(0))
        {
            health -= 50;
            AudioSource.PlayClipAtPoint(melee, transform.position);
            if (gunScript.bullets + 20 > Gun.maxBullets)
            {
                gunScript.bullets = Gun.maxBullets;
            }

            else
            {
                gunScript.bullets += 20;
            }
        }

        else if (other.tag == "Bullet")
        {
            health -= 20;
            AudioSource.PlayClipAtPoint(gunHit, transform.position);
        }

        else if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(crash, transform.position);
        }
    }

    IEnumerator wait()
    {
        speed = (float)3;
        yield return new WaitForSeconds(0.6f);
        explosion.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        playerScript.points += 1;
        Destroy(gameObject);


    }
}
