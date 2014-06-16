using UnityEngine;
using System.Collections;

public class RoboHeadMovement : MonoBehaviour {
	public float speed;
	public int player;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update() {
		if (Input.GetKey (KeyCode.D) && player == 1)
			moveRight ();
		if (Input.GetKey (KeyCode.A) && player == 1)
			moveLeft ();
		if (Input.GetKey (KeyCode.W) && player == 1)
			moveUp ();
		if (Input.GetKey (KeyCode.S) && player == 1)
			moveDown ();
		if (Input.GetKey (KeyCode.LeftArrow) && player == 2)
			moveLeft ();
		if (Input.GetKey (KeyCode.RightArrow) && player == 2)
			moveRight ();
		if (Input.GetKey (KeyCode.UpArrow) && player == 2)
			moveUp ();
		if (Input.GetKey (KeyCode.DownArrow) && player == 2)
			moveDown ();
	}
	
	
	void moveUp() {
		Vector2 movement = Vector2.up;
		rigidbody2D.AddForce(movement * speed * Time.fixedDeltaTime);
	}

	void moveDown() {
		Vector2 movement = -Vector2.up;
		rigidbody2D.AddForce(movement * speed * Time.fixedDeltaTime);
		}

	void moveRight() {
		Vector2 movement = Vector2.right;
		rigidbody2D.AddForce(movement * speed * Time.fixedDeltaTime);
	}
	
	void moveLeft() {
		Vector2 movement = -Vector2.right;
		rigidbody2D.AddForce (movement * speed * Time.fixedDeltaTime);
	}
	

}
