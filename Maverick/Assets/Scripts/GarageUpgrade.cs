using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageUpgrade : MonoBehaviour
{

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

    public void ViewIdleUpgrade()
    {
        
    }

    public void ViewBikeUpgrade()
    {
        myAnimator.SetBool("BikeHover", true);
    }

    public void StopBikeHover()
    {
        myAnimator.SetBool("BikeHover", false);
    }

    public void ViewArmorUpgrade()
    {
        myAnimator.SetBool("ArmorHover", true);
    }

    public void StopArmorHover()
    {
        myAnimator.SetBool("ArmorHover", false);
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
