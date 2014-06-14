using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inputRecording : MonoBehaviour {
	private List<int> inputRecordingX;
	private List<int> inputRecordingY;
	private int playbackCounter;
	private bool playbackActive;
	private bool playbackReady;
	private bool playbackCompleted;
	private bool recordingActive;
	private Vector2 recordStart;
	// Use this for initialization
	void Start () {
		inputRecordingX = new List<int>();
		inputRecordingY = new List<int>();
		playbackCounter = 0;
		playbackActive = false;
		playbackReady = false;
		playbackCompleted = false;
	}
	private void recordInput(float inputX, float inputY, out float capturedX, out float capturedY) {
		Debug.Log("Delta time: " + Time.deltaTime);
		inputRecordingX.Add(Mathf.FloorToInt(inputX));
		inputRecordingY.Add(Mathf.FloorToInt(inputY));
		capturedX = inputX;
		capturedY = inputY;

	}
	public void startRecording() {
		recordingActive = true;
		clearTape();
	}
	public void continueRecording(float inputX, float inputY, out float capturedX, out float capturedY) {
		recordInput(inputX, inputY, out capturedX, out capturedY);
	}
	public void endRecording() {
		inputRecordingX.TrimExcess();
		inputRecordingY.TrimExcess();
		recordingActive = false;
	}
	private void playbackInput(out float inputX, out float inputY) {
		Debug.Log("Delta time: " + Time.deltaTime);
		if (playbackCounter + 1 < inputRecordingX.Count){
			inputX = inputRecordingX[playbackCounter];
			inputY = inputRecordingY[playbackCounter];
			playbackCounter++;
			Debug.Log("Playedback input: " + inputX);
		} else {
			inputX = (float)inputRecordingX[playbackCounter];
			inputY = (float)inputRecordingY[playbackCounter];
			endPlayback();
		}
	}
	public void startPlayback() {
		Debug.Log("Keyframe Count: " + inputRecordingX.Count);
		rewindTape();
		this.playbackReady = false;
		this.playbackActive = true;
		this.playbackCompleted = false;
	}
	public void continuePlayback(out float inputX, out float inputY) {
		playbackInput(out inputX, out inputY);
	}
	private void endPlayback(){
		this.playbackReady = false;
		this.playbackActive = false;
		this.playbackCompleted = true;
	}

	private void rewindTape() {
		Debug.Log ("Record Reset");
		playbackCounter = 0;
	}
	private void clearTape() {
		Debug.Log ("Record Cleared");
		inputRecordingX.Clear();
		inputRecordingY.Clear();
	}
	public int getPlaybackCounter(){
		return this.playbackCounter;
	}
	public int getInputRecordingCount() {
		return inputRecordingX.Count;
	}
	public bool isPlaybackActive() {
		return playbackActive;
	}
	public bool isPlaybackReady() {
		return playbackReady;
	}
	public bool isPlaybackCompleted() {
		return playbackCompleted;
	}
	public bool isRecordingActive() {
		return recordingActive;
	}
	public void setRecordStart(Vector2 position) {
		this.recordStart = position;
	}

	public Vector2 resetForPlayback(Vector2 currentPos) {
		if(Vector2.Distance(currentPos, recordStart) > 0.005f){
			this.playbackReady = false;
			Debug.Log("Target: " + this.recordStart);
			return Vector2.MoveTowards(currentPos, this.recordStart, 0.3f * Time.deltaTime);
		} else {
			this.playbackReady = true;
			this.playbackCompleted = false;
			return currentPos; 
		}
	}
}
