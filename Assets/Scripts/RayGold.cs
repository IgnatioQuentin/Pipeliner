using UnityEngine;
using System.Collections;

public class RayGold : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.rigidbody2D.AddForce(-Vector2.up * 9.81f);
		float distance = Vector2.Distance(this.rigidbody2D.position, this.rigidbody2D.velocity);
		//Debug.DrawRay(this.rigidbody2D.position, this.rigidbody2D.velocity, Color.red);
	}
}
