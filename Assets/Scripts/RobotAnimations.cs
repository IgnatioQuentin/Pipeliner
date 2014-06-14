using UnityEngine;
using System.Collections;

public class RobotAnimations : MonoBehaviour {
	private Animator bodyAnim;
	private Animator headAnim;
	private CircleCollider2D circleCollider;
	private HorizontalMovement movementScript;
	private XYMovement headMovement;
	public GameObject head;
	public GameObject headParent;
	private float velocityX;
	private bool facingRight;
	private Vector3 scale;
	private bool attached = true;
	// Use this for initialization
	void Start () {
		bodyAnim = GetComponent<Animator> ();
			if (bodyAnim == null)
				Debug.Log ("Failed to get Animator component in Robot");
		headAnim = head.GetComponent<Animator> ();
			if (headAnim == null) 
				Debug.Log ("Failed to get Animator in component Head");
		circleCollider = GetComponent<CircleCollider2D>();
			if (circleCollider == null) 
				Debug.Log ("Failed to get CircleCollider2D in component Robot");
		movementScript = GetComponent<HorizontalMovement> ();
			if (movementScript == null)
				Debug.Log ("Failed to get HorizontalMovement in component Robot");
	
	}
	// Update is called once per frame
	void Update () {
		handleXMovement ();
		if (Input.GetKeyDown (KeyCode.Space) && attached) {
			movementScript = GetComponent<HorizontalMovement>();
			movementScript.enabled = false;
			headMovement = head.GetComponentInParent<XYMovement>();
			headMovement.enabled = true;
			this.enabled = false;
			rigidbody2D.fixedAngle = false;
			StartCoroutine(detach());
		}
	}




	//Custom Methods
	public IEnumerator detach() {
		attached = false;
		circleCollider.enabled = false;
		bodyAnim.SetBool ("packingUp", true);
		yield return new WaitForSeconds (1f);
		headAnim.SetBool ("detach", true);
		yield return new WaitForSeconds (1f);
		headParent.rigidbody2D.isKinematic = false;

	}

	void handleXMovement() {
		velocityX = rigidbody2D.velocity.x;
		bodyAnim.SetFloat ("speed", Mathf.Abs(rigidbody2D.velocity.x));
		
		if (Input.GetKeyDown(KeyCode.D) && facingRight) {
			flip();
		}
		if (Input.GetKeyDown(KeyCode.A) && !facingRight) {
			flip ();
		}

	}

	void flip() {
		facingRight = !facingRight;
		scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
