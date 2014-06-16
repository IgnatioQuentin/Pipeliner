using UnityEngine;
using System.Collections;

public class HorizontalMovement : MonoBehaviour {
	public int player;
	public float speed;
	public float gravity;
	// Use this for initialization
	void Start () {
	
	}


	void Update() {
				if (Input.GetKey (KeyCode.D) && player == 1) 
						moveRight ();
				if (Input.GetKey (KeyCode.A) && player == 1)
						moveLeft ();
				if (Input.GetKey (KeyCode.LeftArrow) && player == 2)
		   				moveLeft ();
		  		if (Input.GetKey (KeyCode.RightArrow) && player == 2)
		    			moveRight ();
		}

		

	void moveRight() {
		Vector2 movement = Vector2.right;
		rigidbody2D.velocity = movement * speed * Time.fixedDeltaTime;
	}

	void moveLeft() {
		Vector2 movement = -Vector2.right;
		rigidbody2D.velocity = movement * speed * Time.fixedDeltaTime;
	}
}
