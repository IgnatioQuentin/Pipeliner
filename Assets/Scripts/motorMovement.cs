using UnityEngine;
using System.Collections;

public class motorMovement : MonoBehaviour {
	public float moveForce;
	public float maxSpeed;
	public HingeJoint2D rearWheel;
	public HingeJoint2D frontWheel;
	private JointMotor2D rear;
	private JointMotor2D front;
	// Use this for initialization
	void Start () {
		//rearWheel.GetComponent<HingeJoint2D>();
		//frontWheel.GetComponent<HingeJoint2D>();
		rear = rearWheel.motor;
		front = frontWheel.motor;
	}
	void Update() {
		float h = Input.GetAxis("Horizontal");
		rear.motorSpeed += h * moveForce;
		front.motorSpeed += h * moveForce;
		rearWheel.motor = rear;
		frontWheel.motor = front;
	}
}