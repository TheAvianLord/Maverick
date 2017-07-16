using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public GameObject player;

	// Use this for initialization
	void Start ()
    {

        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
	}
}
