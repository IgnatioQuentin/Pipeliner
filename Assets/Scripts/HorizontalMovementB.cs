using UnityEngine;
using System.Collections;

public class HorizontalMovementB : MonoBehaviour {
	public GameObject player;
	public float moveForce;
	public float maxSpeed;
	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate() {
		if (player.name == "Red Bot") {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			player.rigidbody2D.velocity = movement * maxSpeed;
		}
		
		if (player.name == "Blue Bot") {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			player.rigidbody2D.velocity = movement * maxSpeed;
			
		}
	}
}

