using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Animator myAnimator;
    public GameObject player;
    public Player playerScript;
    public GameObject bullet;
    public bool alwaysOn = false;
    public bool hasCount = false;
    public int bullets;
    public static int maxBullets = 50;

    public static float fireRate = 0.25f;
    public float nextFire = 0.0f;

    public AudioClip gunShot;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();

        bullets = maxBullets;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnimator = GetComponent<Animator>();
        if (playerScript.abletohit == true)
        {

            myAnimator.SetBool("shooting", Input.GetMouseButton(1));

            if ((Input.GetMouseButton(1) || alwaysOn) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                fire();

                
            }
        }
    }

    void fire()
    {
        if(hasCount)
        {
            bullets -= 1;
        }

        if (bullets > 0)
        {
            AudioSource.PlayClipAtPoint(gunShot, new Vector3(5, 1, 2));
            GameObject createdObject = GameObject.Instantiate(bullet) as GameObject;
            createdObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
       
    }
}