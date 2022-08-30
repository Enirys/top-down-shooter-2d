using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameManager gameManager;

    [SerializeField]
    private GameObject[] enemy;

    [SerializeField]
    private Transform[] spawnPoints;
    
    private float timeBtwSpawns;
    [SerializeField]
    private float startTimeBtwSpawns;


	// Use this for initialization
	void Start ()
    {
        timeBtwSpawns = startTimeBtwSpawns;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gameManager.spawnAllowed)
        {
            if (timeBtwSpawns <= 0)
            {
                int randPos = Random.Range(0, spawnPoints.Length);
                int randEnemy = Random.Range(0, enemy.Length);
                Instantiate(enemy[randEnemy], spawnPoints[randPos].position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
	}
}
