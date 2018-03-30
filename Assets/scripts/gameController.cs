using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

	public GameObject HSPanel;
	private Animator anim;
	public Text HSText;
	// Use this for initialization
	void Start () {
		anim = HSPanel.GetComponent<Animator>();
		gameOver();
		getHighScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("DanceGame");
	}

	public void quit() {
		Application.Quit();
	}

	public void showHighscore(){
		anim.SetTrigger("playHSAnim");
	}

	public void removeHighscore() {
		anim.SetTrigger("removeHSPanel");
	}

	public void gameOver() {
		PlayerPrefs.SetString("HighScore","12345");
	}

	private void getHighScore() {
		HSText.text = PlayerPrefs.GetString("HighScore");

	}
}
