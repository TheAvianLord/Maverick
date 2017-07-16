using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public static int chance = 200;
    public GameObject[] enemies;

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
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length <= 0)
            {
                int num = Random.Range(0, chance + 1);
                if (num == chance)
                {
                    GameObject createdObject = GameObject.Instantiate(enemy) as GameObject;
                    int lor = Random.Range(0, 2);
                    if (lor == 0)
                    {
                        createdObject.transform.position = new Vector3((float)-0.8, -6, 0);
                    }

                    else
                    {
                        createdObject.transform.position = new Vector3((float)0.8, -6, 0);
                    }

                }
            }
        }
       
    }
}
