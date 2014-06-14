using UnityEngine;
using System.Collections;

public class motorMovement : MonoBehaviour {
	public float moveForce;
	public float maxSpeed;
	private FlatbedController flatty;
	private inputRecording recordedInput;
	
	void Start () {
		flatty = GetComponentInChildren<FlatbedController>();
		recordedInput = gameObject.AddComponent<inputRecording>();
		recordedInput.setRecordStart(this.transform.position);
	}
	void Update() {
/*
		Ray2D myRay = new Ray2D(this.rigidbody2D.position, this.rigidbody2D.velocity);
		float rayDistance = Vector2.Distance(myRay.origin, myRay.direction);
		RaycastHit2D hitInfo = Physics2D.Raycast(myRay.origin, myRay.direction, rayDistance, 1 << LayerMask.NameToLayer("Terrain"));
		if(hitInfo) {
			Debug.Log("Hit!: " + hitInfo.collider);
		}
		Debug.DrawRay(myRay.origin, this.rigidbody2D.velocity, Color.red);
*/
	}
	public void handleInput(float inputX, float inputY){
//		Debug.Log("InputX: " + inputX + " InputY: " + inputY);
		//Debug.Log("Input executed: " + inputX);
		if(inputX * rigidbody2D.velocity.x < maxSpeed) 			
			this.rigidbody2D.AddForce(Vector2.right * inputX * moveForce * (10f * Time.fixedDeltaTime)); 		 		
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			this.rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		flatty.handleInput(inputY);
	}
	public void recordInput(float inputX, float inputY) {
		float capturedInputX = 0;	
		float capturedInputY = 0; 
		if(!recordedInput.isRecordingActive()) {
			this.recordedInput.setRecordStart(this.transform.position);
			this.recordedInput.startRecording();
		} else {
			this.recordedInput.continueRecording(inputX, inputY, out capturedInputX, out capturedInputY);
		}
		this.handleInput(capturedInputX, capturedInputY);
	}
	public bool playbackInput(bool looped) {
		float inputX = 0;
		float inputY = 0;
		if(recordedInput.isPlaybackCompleted() && looped){
			this.transform.position = recordedInput.resetForPlayback(this.transform.position);
		} else if(recordedInput.isPlaybackActive()) {
			recordedInput.continuePlayback(out inputX, out inputY);
			handleInput(inputX, inputY);
		} else if (recordedInput.isPlaybackReady()) {
			recordedInput.startPlayback();
		} else {
			this.transform.position = recordedInput.resetForPlayback(this.transform.position);
		}

		if(recordedInput.isPlaybackCompleted() && !looped) {
			return false;
		} else {
			return true;
		}
	}
	public void endRecording(){
		this.recordedInput.endRecording();
	}
	public int getPlaybackCounter() {
		return this.recordedInput.getPlaybackCounter();
	}
	public int getInputRecordingCount() {
		return this.recordedInput.getInputRecordingCount();
	}
}