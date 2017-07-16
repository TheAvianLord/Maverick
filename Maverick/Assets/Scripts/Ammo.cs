using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{

    public Slider ammoSlider;
    public Text theText;

    public GameObject gun;
    public Gun gunScript;
    // Use this for initialization
    void Start ()
    {
        gun = GameObject.Find("Gun");
        gunScript = gun.GetComponent<Gun>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
        ammoSlider.maxValue = Gun.maxBullets;
        ammoSlider.value = gunScript.bullets;
        theText.text = gunScript.bullets + "/" + Gun.maxBullets;


    }
}
