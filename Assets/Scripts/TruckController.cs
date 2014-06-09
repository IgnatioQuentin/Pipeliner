 using UnityEngine;
using System.Collections;

public class TruckController : MonoBehaviour {
	//Moving
	public float moveForce = 365f;			
	public float maxSpeed = 5f;			
	//Flipping
	private Transform flippedDetector;
	private bool flipped = false;
	private bool flipping = false;
	//Menu
	
	void Awake()
	{
		// Setting up references.
		flippedDetector = transform.Find("FlippedDetector");

	}

	void Start() {
	}
	
		
	void Update() {
			
				// The player is flipped if a linecast to the groundcheck position hits anything on the ground layer.
				flipped = Physics2D.Linecast (transform.position, flippedDetector.position, 1 << LayerMask.NameToLayer ("Terrain"));  

				// If flipped, flip him over + mutex for flipping
				if (flipped && !flipping) {
						flipping = true;
						StartCoroutine (flipOver ());
				}

				

		}
	
	void FixedUpdate () {
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		if(h * rigidbody2D.velocity.x < maxSpeed) 			
			rigidbody2D.AddForce(Vector2.right * h * moveForce); 		 		
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
	}

// Custom methods
	IEnumerator flipOver() {
		yield return new WaitForSeconds (1.0f);
		rigidbody2D.AddForce (new Vector2 (0f, 6000f));
		transform.Rotate (0, 0, 120.0f);
		flipping = false;
	}



}