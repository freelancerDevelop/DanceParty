using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnerScript : MonoBehaviour {

	 public Text myScore;
	 public static spawnerScript instance;
	 private GameObject dancer;
	 private float theTime=120;
		public Text timer;

	public void Awake() {
		if(instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		spawnProcess();
	}
	
	// Update is called once per frame
	void Update () {
		theTime -= Time.deltaTime;
		timer.text = (int)theTime/60 + ":" + (int)theTime%60;
		int highScore = int.Parse(PlayerPrefs.GetString("HighScore"));
		if(theTime<=0) {
			theTime=0;
			CancelInvoke("spawn");
		}


		if (Input.GetKeyDown(KeyCode.Escape)) { 
			UnityEngine.SceneManagement.SceneManager.LoadScene("IntroScene");
			CancelInvoke("spawn");
		}
		
		int cur = (int.Parse(myScore.text));
			if(cur>highScore) {
				PlayerPrefs.SetString("HighScore",myScore.text);
			}
	}
	public void spawnProcess() {
		InvokeRepeating("spawn",2.5f,1.0f);
	}
	void spawn() {
		GameObject x = (GameObject)Instantiate(Resources.Load("pointButton"));
		x.transform.parent = transform;
		RectTransform position = x.GetComponent<RectTransform>();
		position.localPosition = new Vector3(20,-5,0);
		position.localScale = new Vector3(0.3f,0.3f,0.3f);
	}

	public void AddScore(int curScore) {
		// Debug.Log("Points:"+curScore.ToString());
		myScore.text = ((int.Parse(myScore.text)) + curScore).ToString();
		removeKids();
	}

	private void removeKids() {
		foreach(Transform child in transform) {
			Destroy(child.gameObject);
		}
	}

	public void makeMove(string danceMove) {
		dancer = GameObject.Find("UserDefinedTarget-1/sporty_granny");
		Animator anim = dancer.GetComponent<Animator>();
		anim.SetTrigger(danceMove);
	}
}
