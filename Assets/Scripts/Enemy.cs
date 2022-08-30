using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    private GameManager gameManager;

    [SerializeField]
    private float moveSpeed = 8f;

    public GameObject deathEffect;
    public GameObject playerDamageEffect;

    private Rigidbody2D myRigidbody;

    [SerializeField]
    private int health;

    private Transform playerPos;

    private GameObject target;

    private Player player;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        gameManager = FindObjectOfType<GameManager>();

        target = GameObject.Find("Player");
        if(target != null)
        {
            playerPos = FindObjectOfType<Player>().transform;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.health--;
            GameObject newEffect = (GameObject)Instantiate(playerDamageEffect, transform.position, Quaternion.identity);
            Destroy(newEffect,2);
        }
        if(other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            health--;
            gameManager.score += gameManager.damagePoints;
            Death();
        }
    }

    private void Death()
    {
        if(health <= 0)
        {
            gameManager.score += gameManager.killPoints;
            GameObject newEffect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(newEffect, 2);
        }
    }
}
