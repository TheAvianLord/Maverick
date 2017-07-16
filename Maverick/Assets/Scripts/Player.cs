using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float speed = (float)1.1;
    public float x_mov;
    public float y_mov;
    public bool abletohit;
    public Animator myAnimator;
    public bool invincible;
    public GameObject[] cars;
    public GameObject[] enemies;
    public GameObject[] bullets;
    public static int maxHealth = 500;
    public int health;
    public GameObject shadow;

    public int points;
    public static int levelPoints = 1;

    public bool finishedLevel = false;

    public GameObject explosion;


    void Start()
    {
        health = maxHealth;
        explosion.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        myAnimator = GetComponent<Animator>();
        abletohit = true;
}

    // Update is called once per frame
    void Update()
    {
        if (points >= levelPoints)
        {
            finishedLevel = true;
            health = maxHealth;
            shadow.GetComponent<Collider2D>().enabled = false;
            transform.position = new Vector3(0, transform.position.y + (float)0.02, 0);

            if (transform.position.y > 2.5)
            {
                SceneManager.LoadScene("GarageLevel");
            }
            

        }

        if (health <= 0)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            explosion.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            StartCoroutine(wait());
        }

        cars = GameObject.FindGameObjectsWithTag("Car");
        x_mov = Input.GetAxis("Horizontal");
        y_mov = Input.GetAxis("Vertical");

        myAnimator.SetBool("forward", Input.GetKey(KeyCode.W));
        myAnimator.SetBool("right", Input.GetKey(KeyCode.D));
        myAnimator.SetBool("left", Input.GetKey(KeyCode.A));

        if (abletohit)
        {
            myAnimator.SetBool("melee", Input.GetMouseButton(0));
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(x_mov * speed, y_mov * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Car" || other.tag == "EnemyBullet")
        {
            health -= 10;
            abletohit = false;
            StartCoroutine(waitThreeSeconds());
        }

    }

    IEnumerator wait()
    {
        speed = (float)3;
        yield return new WaitForSeconds(0.6f);
        explosion.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        Destroy(gameObject);
        yield return new WaitForSeconds(1f);
        EnemySpawner.chance = 200;
        Spawner.chance = 300;
        Player.levelPoints = 1;
        Gun.maxBullets = 50;
        Gun.fireRate = 0.5f;
        speed = (float)1.1;
        maxHealth = 500;

        SceneManager.LoadScene("GameOver");

    }

    IEnumerator waitThreeSeconds()
    {
        invincible = true;
        //flashing!
        //stop taking damage
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.25f);
        //disable collider
        gameObject.GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        invincible = false;
        //enable collider
        gameObject.GetComponent<Collider2D>().enabled = true;
        abletohit = true;
    }


}
