using UnityEngine;
using System.Collections;

public class GrabInTrigger : MonoBehaviour {
	public int player;
	private bool holding = false;
	private Animator anim;
	private HingeJoint2D joint;
	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
		if (anim == null)
			Debug.Log ("Couldn't get Animator from child");
		joint = GetComponentInParent<HingeJoint2D> ();
		if (joint == null) 
			Debug.Log ("Couldn't load SpringJoint2D");

	}

	void OnTriggerStay2D(Collider2D other) {
		//Player 1
		if (Input.GetKeyDown (KeyCode.E) && (other.tag == "MovableObject") && !holding && player == 1) {
				Rigidbody2D otherBody = other.GetComponent<Rigidbody2D> ();
				grab (otherBody);
		}
		if (Input.GetKeyDown (KeyCode.R) && holding && player == 1) 
				release ();
		//Player 2
		if (Input.GetKeyDown (KeyCode.Keypad8) && (other.tag == "MovableObject") && !holding && player == 2) {		
				Rigidbody2D otherBody = other.GetComponent<Rigidbody2D> ();	
				grab (otherBody);
		}
		if (Input.GetKeyDown (KeyCode.Keypad9) && holding && player == 2) 
				release ();
	}
		
	void grab(Rigidbody2D otherBody) {
			joint.enabled = true;
			joint.connectedBody = otherBody;
			// Case of grabbing robot body
			if (otherBody.mass == 10) {
				joint.connectedAnchor = new Vector2 (-0.03f, -0.12f);
			}
			// Case of grabbing small ball
			if (otherBody.mass == 1) {
				joint.connectedAnchor = new Vector2 (0.0f, 0.0f);
			}
			anim.SetBool("grabbing", true);
			holding = true;
		}

	void release() {
			joint.enabled = false;
			anim.SetBool("grabbing", false);
			holding = false;
		}

}
