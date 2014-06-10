using UnityEngine;
using System.Collections;

public class XYMovement : MonoBehaviour {
	public float moveForce;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		
		if(h * rigidbody2D.velocity.x < maxSpeed) 			
			rigidbody2D.AddForce(Vector2.right * h * moveForce * (10f * Time.deltaTime)); 		 		
		//if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			//rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		if(v * rigidbody2D.velocity.y < maxSpeed)
			rigidbody2D.AddForce (Vector2.up * v * moveForce * (10f * Time.deltaTime));
		//if (Mathf.Abs (rigidbody2D.velocity.y) > maxSpeed)
			//	rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.y) * maxSpeed, rigidbody2D.velocity.x);

	}
}

