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

    public float fireRate = 0.5f;
    public float nextFire = 0.0f;


    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
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
        GameObject createdObject = GameObject.Instantiate(bullet) as GameObject;
        createdObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}