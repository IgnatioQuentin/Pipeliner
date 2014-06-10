﻿ using UnityEngine;
using System.Collections;

public class TruckController : MonoBehaviour {
	//Moving
	public float moveForce = 365f;			
	public float maxSpeed = 5f;			
	//Flipping
	
	//Menu
	
	void Awake()
	{
		// Setting up references.



	}

	void Start() {
	}
	
		
	void Update() {


		}
	
	void FixedUpdate () {
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		if(h * rigidbody2D.velocity.x < maxSpeed) 			
			rigidbody2D.AddForce(Vector2.right * h * moveForce * (10f * Time.deltaTime)); 		 		
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
	}




}