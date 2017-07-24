﻿using UnityEngine;
using System.Collections;
//using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	public float moveSpeed = 10f;
	public float jumpHeight = 10;
	public Rigidbody myRigidbody;
    public float jumpsensitivity = 1.2f;
    public float levelWidth = 15;

	void awake() {
		myRigidbody = GetComponent<Rigidbody> ();
	}

    // Use this for initialization
    void Start(){
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
            move(moveSpeed);

        if (Input.GetKeyUp(KeyCode.D))
            myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y,0);
        
        if (Input.GetKey(KeyCode.A))
            move(-moveSpeed);

        if (Input.GetKeyUp(KeyCode.A))
            myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0);
        
        if (Input.GetKeyDown(KeyCode.W))
            jump(jumpHeight);

        if (transform.position.x > levelWidth)
            transform.position = new Vector3(-levelWidth, myRigidbody.position.y, 0);
        else if (transform.position.x < -levelWidth)
            transform.position = new Vector3(levelWidth, myRigidbody.position.y, 0);

    }

	void move (float speed) {
        myRigidbody.velocity = transform.right * speed + new Vector3 (0,myRigidbody.velocity.y,0);
    }

    void jump(float height)
    {
        if (Physics.Raycast(transform.position, Vector3.down, jumpsensitivity, 1 << 8))
        {
            myRigidbody.velocity = transform.up * height * 2;
        }
    }
	/*void FixedUpdate () {
		
	}*/

}
