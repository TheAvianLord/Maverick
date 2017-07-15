using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject car;
    public int chance;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("it starts");
	}
	
	// Update is called once per frame
	void Update ()
    {
        int num = Random.Range(0, chance+1);
        if ( num == chance)
        {
            GameObject createdObject = GameObject.Instantiate(car) as GameObject;
            createdObject.transform.position = new Vector3(transform.position.x, 3, 0);
        }
	}
}
