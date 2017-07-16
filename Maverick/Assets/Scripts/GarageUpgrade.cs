using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GarageUpgrade : MonoBehaviour
{
    public int money;
    private Animator myAnimator;
    public bool notupgraded;


	// Use this for initialization
	void Start ()
    {
        myAnimator = GetComponent<Animator>();

        notupgraded = true;

        //up the difficulty
        EnemySpawner.chance -= 50;
        Spawner.chance -= 50;
        Player.levelPoints += 1;

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void PurchaseBikeUpgrade()
    {
        if (notupgraded)
        {
            Player.speed += (float)0.1;
            notupgraded = false;
            //transition?
            SceneManager.LoadScene("Angela");
        }
    }

    public void ViewBikeUpgrade()
    {
        myAnimator.SetBool("BikeHover", true);
    }

    public void StopBikeHover()
    {
        myAnimator.SetBool("BikeHover", false);
    }

    public void PurchaseArmorUpgrade()
    {
        if (notupgraded)
        {
            Player.maxHealth += 20;
            notupgraded = false;
            SceneManager.LoadScene("Angela");
        }
    }

    public void ViewArmorUpgrade()
    {
        myAnimator.SetBool("ArmorHover", true);
    }

    public void StopArmorHover()
    {
        myAnimator.SetBool("ArmorHover", false);
    }

    public void PurchaseWeaponUpgrade()
    {
        if (notupgraded)
        {
            Gun.fireRate += (float)0.2;
            Gun.maxBullets += 20;
            notupgraded = false;
            SceneManager.LoadScene("Angela");
        }
    }

    public void ViewWeaponUpgrade()
    {
        myAnimator.SetBool("WeaponHover", true);
    }

    public void StopWeaponHover()
    {
        myAnimator.SetBool("WeaponHover", false);
    }

}
