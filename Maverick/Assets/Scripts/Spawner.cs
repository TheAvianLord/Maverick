using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject car;
    public int chance;
    public GameObject[] cars;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        cars = GameObject.FindGameObjectsWithTag("Car");

        //create cars
        int num = Random.Range(0, chance+1);
        if ( num == chance)
        {
            GameObject createdObject = GameObject.Instantiate(car) as GameObject;
            createdObject.transform.position = new Vector3(transform.position.x, 6, 0);
        }

        //delete double spawning cars
        for (int i = 0; i < cars.Length; i++)
        {

            if (cars[i].transform.position.x == -0.5 || cars[i].transform.position.x == -1.1 || cars[i].transform.position.x == 0.5 || cars[i].transform.position.x == 1.1)
            {

            }

            else
            {
                //Destroy(cars[i]);
            }
        }


	}

}
