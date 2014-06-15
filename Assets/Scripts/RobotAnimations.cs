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
	private bool facingRight;
	private Vector3 scale;
	public bool attached = true;
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
		// Activate head scripts
		headParent.GetComponent<GrabInTrigger> ().enabled = true;
		headParent.GetComponent<ReAttach> ().enabled = true;
		// Activate head colliders
		headParent.GetComponent<CircleCollider2D> ().enabled = true;
		head.GetComponent<BoxCollider2D> ().enabled = true;
		// Deactivate cirlceCollider
		circleCollider.enabled = false;
		bodyAnim.SetBool ("packingUp", true);
		yield return new WaitForSeconds (1f);
		attached = false;
		headAnim.SetBool ("detach", true);
		yield return new WaitForSeconds (1f);
		head.GetComponent<CircleCollider2D> ().enabled = true;
		headParent.rigidbody2D.isKinematic = false;
		gameObject.layer = LayerMask.NameToLayer ("MovableObject");
		gameObject.tag = "MovableObject";

	}

	void handleXMovement() {
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

	public bool isAttached() {
		return attached;
	}
	
}
