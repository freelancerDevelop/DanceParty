using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour {

	public bool flashStatus = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void toggleFlash() {
		if(flashStatus) {
			CameraDevice.Instance.SetFlashTorchMode(false);
			flashStatus = false;
		}
		else {
			CameraDevice.Instance.SetFlashTorchMode(true);
			flashStatus = true;
		}
	}

	public void reset() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("GameV1");
	}
}
