using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int chance;
    public GameObject[] enemies;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
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
