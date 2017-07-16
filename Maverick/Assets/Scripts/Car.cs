using System.Collections;
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
    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
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
        if (other.tag == "Melee" && Input.GetMouseButton(0))
        {
            health -= 50;
            AudioSource.PlayClipAtPoint(melee, transform.position);
        }

        else if (other.tag == "Bullet")
        {
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

}
