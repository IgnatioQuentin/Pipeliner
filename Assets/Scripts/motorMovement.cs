	using UnityEngine;
using System.Collections;

public class motorMovement : MonoBehaviour {
	public float moveForce;
	public float maxSpeed;
	public HingeJoint2D rearWheel;
	public HingeJoint2D frontWheel;
	private JointMotor2D rear;
	private JointMotor2D front;
	public Camera mainCamera;
	private GameCamera targeter;
	// Use this for initialization
	void Start () {

		targeter = mainCamera.GetComponent<GameCamera>();
		targeter.SetTarget(this.transform);
		//rearWheel.GetComponent<HingeJoint2D>();
		//frontWheel.GetComponent<HingeJoint2D>();
		rear = rearWheel.motor;
		front = frontWheel.motor;

	}
	void FixedUpdate() {
		float h = Input.GetAxis("Horizontal");
		//Debug.Log("Input: " + h);
		rear.motorSpeed *= 0.99f;
		front.motorSpeed *= 0.99f;
		rear.motorSpeed += h * moveForce;
		front.motorSpeed += h * moveForce;
		rearWheel.motor = rear;
		frontWheel.motor = front;
		/**/
		Ray2D myRay = new Ray2D(this.rigidbody2D.position, this.rigidbody2D.velocity);
		float rayDistance = Vector2.Distance(myRay.origin, myRay.direction);
		RaycastHit2D hitInfo = Physics2D.Raycast(myRay.origin, myRay.direction, rayDistance, 1 << LayerMask.NameToLayer("Terrain"));
		if(hitInfo) {
			Debug.Log("Hit!: " + hitInfo.collider);
		}
		Debug.DrawRay(myRay.origin, this.rigidbody2D.velocity, Color.red);
  	}
}