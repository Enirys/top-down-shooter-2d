using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public GameObject playerDeathEffect;
    
    private Rigidbody2D myRigidbody;

    //public bool playerIsDead = false;

    public int health = 20;

    [SerializeField]
    private float moveSpeed = 10f;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void FixedUpdate()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        HandleMovements(moveH, moveV);
    }

    private void HandleMovements(float moveH,float moveV)
    {
        Vector2 move = new Vector2(moveH, moveV).normalized;
        myRigidbody.velocity = move * moveSpeed;
    }

    public void SpawnDeathEffect()
    {
          GameObject newEffect = (GameObject)Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
          Destroy(newEffect, 2);
    }
}
