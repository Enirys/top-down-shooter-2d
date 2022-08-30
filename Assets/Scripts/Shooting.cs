using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private Transform playerPos;

	// Use this for initialization
	void Start ()
    {
        playerPos = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            Instantiate(shot, playerPos.position, Quaternion.identity);
        }
	}
}
