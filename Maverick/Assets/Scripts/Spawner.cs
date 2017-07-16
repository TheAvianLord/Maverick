using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject car;
    public static int chance = 300;
    public GameObject[] cars;

    public GameObject tutorialSystem;
    public TutorialInputs tutorialScript;

    public GameObject player;
    public Player playerScript;

    // Use this for initialization
    void Start ()
    {
        if (chance < 50)
        {
            chance = 50;
        }

        tutorialSystem = GameObject.Find("TutorialSystem");
        tutorialScript = tutorialSystem.GetComponent<TutorialInputs>();

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (tutorialScript.tutorialOver == true && playerScript.finishedLevel == false)
        {
            cars = GameObject.FindGameObjectsWithTag("Car");

            //create cars
            int num = Random.Range(0, chance + 1);
            if (num == chance)
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

}
