using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageUpgrade : MonoBehaviour
{
    public int money;
    private Animator myAnimator;

	// Use this for initialization
	void Start ()
    {
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void PurchaseBikeUpgrade()
    {
        if (money >= 200)
        {
            StaticVariables.BikeStats += 1;
            money -= 200;
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
        if (money >= 200)
        {
            StaticVariables.ArmorStats += 1;
            money -= 200;
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
        if (money >= 200)
        {
            StaticVariables.WeaponStats += 1;
            money -= 200;
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
