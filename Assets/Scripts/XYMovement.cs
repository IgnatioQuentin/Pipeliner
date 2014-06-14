using UnityEngine;
using System.Collections;

public class XYMovement : MonoBehaviour {
	public float moveForce;
	public float maxSpeed;
	private inputRecording recordedInput;
	// Use this for initialization
	void Start () {
		recordedInput = gameObject.AddComponent<inputRecording>();
		recordedInput.setRecordStart(this.transform.position);
	}
	
	// Update is called once per frame
	/*
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
	*/
	void Update() {

	}
	public void handleInput(float h, float v) {
		
		if(h * rigidbody2D.velocity.x < maxSpeed) 			
			rigidbody2D.AddForce(Vector2.right * h * moveForce * (10f * Time.fixedDeltaTime)); 		 		
		//if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
		//rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
		if(v * rigidbody2D.velocity.y < maxSpeed)
			rigidbody2D.AddForce (Vector2.up * v * moveForce * (10f * Time.fixedDeltaTime));
		//if (Mathf.Abs (rigidbody2D.velocity.y) > maxSpeed)
		//	rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.y) * maxSpeed, rigidbody2D.velocity.x);
		
	}
	public void recordInput(float inputX, float inputY) {
		float capturedInputX = 0;	
		float capturedInputY = 0; 
		if(!recordedInput.isRecordingActive()) {
			this.recordedInput.setRecordStart(this.transform.position);
		} else {
			this.recordedInput.continueRecording(inputX, inputY, out capturedInputX, out capturedInputY);
		}
		this.handleInput(capturedInputX, capturedInputY);
	}
	public bool playbackInput(bool looped) {
		if(recordedInput.getInputRecordingCount() == 0)
			return false;
		float inputX = 0;
		float inputY = 0;
		if(recordedInput.isPlaybackCompleted() && looped){
			this.transform.position = recordedInput.resetForPlayback(this.transform.position);
		} else if(recordedInput.isPlaybackActive()) {
			recordedInput.continuePlayback(out inputX, out inputY);
		} else if (recordedInput.isPlaybackReady()) {
			recordedInput.startPlayback();
		} else {
			Debug.Log("Old: " + this.transform.position);
			this.transform.position = recordedInput.resetForPlayback(this.transform.position);
			Debug.Log("New: " + this.transform.position);
		}
		handleInput(inputX, inputY);
		if(recordedInput.isPlaybackCompleted()) {
			return false;
		} else {
			return true;
		}
	}

	public int getKeyFrameCounter(){
		return this.recordedInput.getPlaybackCounter();
	}
}


