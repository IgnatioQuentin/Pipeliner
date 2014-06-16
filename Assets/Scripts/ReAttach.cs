using UnityEngine;
using System.Collections;

public class ReAttach : MonoBehaviour {
	public int player;
	private RobotAnimations mainScript;
	public GameObject body;
	public GameObject chassis;
	private CircleCollider2D chassisCircleCollider;
	private CircleCollider2D bodyCircleCollider;
	private CircleCollider2D headCircleCollider;
	private Animator bodyAnim;
	private Animator headAnim;

	public RobotAnimations robotAnimations;
	public HorizontalMovement horizontalMovement;
	void Start() {
		mainScript = GetComponentInParent<RobotAnimations> ();
			if (mainScript == null) 
				Debug.Log ("Couldn't load RobotAnimations in component Robot");
		bodyAnim = body.GetComponent<Animator> ();
			if (bodyAnim == null)
				Debug.Log ("Couldn't load BodyAnimator");
		headAnim = GetComponentInChildren<Animator> ();
			if (headAnim == null)
				Debug.Log ("Couldn't load HeadAnimator");
		bodyCircleCollider = body.GetComponent<CircleCollider2D> ();
			if (bodyCircleCollider == null) 
				Debug.Log ("Couldn't load CircleCollider from body");
		headCircleCollider = GetComponent<CircleCollider2D> ();
			if (headCircleCollider == null)
				Debug.Log ("Couldn't load CircleCollider from head");
		chassisCircleCollider = chassis.GetComponent<CircleCollider2D> ();
			if (chassisCircleCollider == null)
				Debug.Log ("Couldn't load CircleCollider from chassis");		
	}


	
	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKeyDown (KeyCode.Space) 
		    	&& other.name == ("Red Bot")
		    		&& player == 1) {
			StartCoroutine(reAttach ());
		}
		if (Input.GetKeyDown (KeyCode.KeypadPlus)
				&& other.name == ("Blue Bot")
					&& player == 2) {
			StartCoroutine (reAttach ());
				}
	}

	// Custom Methods

	public IEnumerator reAttach() {
		// Turn dat body UP
		Quaternion rot = body.transform.rotation;
		rot = Quaternion.Euler (0f, 0f, 0f);
		body.transform.rotation = rot;
		Quaternion headRot = transform.rotation;
		headRot = Quaternion.Euler (0f, 0f, 0f);
		transform.rotation = headRot;
		// Activate old scripts
		robotAnimations.enabled = true;
		horizontalMovement.enabled = true;
		// Activate old colliders
		body.GetComponent<CircleCollider2D>().enabled = true;
		chassis.GetComponent<BoxCollider2D>().enabled = false;
		// Deactivate current colliders
		headCircleCollider.enabled = false;
		chassisCircleCollider.enabled = false;
		// Deactivate current scripts
		this.GetComponent<RoboHeadMovement>().enabled = false;
		chassis.GetComponent<GrabInTrigger>().enabled = false;
		// Activate fixed angle on body
		body.rigidbody2D.fixedAngle = true;
		//Animate
		bodyAnim.SetBool ("packingUp", false);
		headAnim.SetBool("detach", false);
		rigidbody2D.isKinematic = true;
		transform.localPosition = new Vector3 (1.819692f, -0.7440035f);
		// Final wrapping up
		body.tag = ("Player");
		yield return new WaitForSeconds (1f);
		mainScript.attached = true;
		enabled = false;
		}
}
