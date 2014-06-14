using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	private int score;
	private bool choppaActive;
	//
	private bool isRecording;
	private bool isPlayingBack;
	private bool loopPlayback;

	private GameObject flatty;
	private GameObject choppa;

	private motorMovement flattyController;
	private XYMovement choppaController;
	private GameCamera lookingGlass;
	// Use this for initialization
	void Start () {
		score = 0;
		choppaActive = false;

		isRecording = false;
		isPlayingBack = false;
		loopPlayback = false;

		flatty = GameObject.Find("FlatbedTruck");
		choppa = GameObject.Find("Choppa");

		flattyController = flatty.GetComponent<motorMovement>();
		choppaController = choppa.GetComponent<XYMovement>();
		lookingGlass = GameObject.Find("Main Camera").GetComponent<GameCamera>();

		lookingGlass.SetTarget(flatty.transform);
	}
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.Escape))
			Application.Quit();

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		// Toggle Active Vehicle
		if(Input.GetKeyDown (KeyCode.Tab)) {
			toggleActiveVehicle();
		}
		if(Input.GetKeyDown (KeyCode.R)) {
			toggleRecording ();
		}
		if(Input.GetKeyDown (KeyCode.P)) {
			togglePlayback(Input.GetKey(KeyCode.LeftShift));
		}
		if(isPlayingBack) {
			if(!flattyController.playbackInput(loopPlayback) /*&&
			   !choppaController.playbackInput(loopPlayback)*/) {
				togglePlayback(false);
			}
			if(!choppaController.playbackInput(false)){
				choppaController.handleInput(h, v);
			}
		//Debug.Log("Playback active");
		} else if (isRecording) {
			if (choppaActive) {
				choppaController.recordInput(h, v);
			} else {
				flattyController.recordInput(h, v);
			}
		} else { 
			//Debug.Log("Input active");
			if (choppaActive) {
				choppaController.handleInput (h, v);
			} else {
				flattyController.handleInput (h, v);
			}
		}
	}
	public void scoreOne() {
		score++;
	}
	public int getScore() {
		return this.score;
	}
	public bool getPlayback() {
		return this.isPlayingBack;
	}
	public bool getRecording() {
		return this.isRecording;
	}
	private void toggleActiveVehicle(){
		if(choppaActive){
			choppaActive = false;
			lookingGlass.SetTarget(flatty.transform);
		} else {
			choppaActive = true;
			lookingGlass.SetTarget(choppa.transform);
		}
	}
	private void toggleRecording() {
		if(isRecording){
			flattyController.endRecording();
			this.isRecording = false;
		} else {
			this.isRecording = true;
		}
	}
	private void togglePlayback(bool loopPlayback) {
		if(this.isPlayingBack) {
			this.isPlayingBack = false;
			this.loopPlayback = false;
		} else {
			this.isPlayingBack = true;
			this.loopPlayback = loopPlayback;
		}
	}
}
