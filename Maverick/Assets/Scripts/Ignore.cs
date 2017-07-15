﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore : MonoBehaviour
{
    public GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
    public GameObject endWall = GameObject.FindWithTag("End");
    public GameObject frontWall = GameObject.FindWithTag("Front");
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        cars = GameObject.FindGameObjectsWithTag("Car");

        for (int i = 0; i < cars.Length; i++)
        {
            Physics2D.IgnoreCollision(endWall.GetComponent<Collider2D>(), cars[i].GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(frontWall.GetComponent<Collider2D>(), cars[i].GetComponent<Collider2D>());


        }


	}
}
