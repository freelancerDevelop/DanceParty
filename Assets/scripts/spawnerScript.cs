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
	 public Text moveText;
	 private string[] moves = {"TWERK","HIP HOP","SILLY","PARTY"};
	 private int num;
	 public GameObject gameOver;
	 private bool progress;

	public void Awake() {
		if(instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		progress=true;
		spawnProcess();
	}
	
	// Update is called once per frame
	void Update () {
		if(progress) {
			theTime -= Time.deltaTime;
			timer.text = (int)theTime/60 + ":" + (int)theTime%60;
		}
		
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
		float freq = 1.0f - (100-theTime)/100;
		InvokeRepeating("spawn",2.5f,freq);
	}
	void spawn() {
		// GameObject x = (GameObject)Instantiate(Resources.Load("pointButton"));
		// x.transform.parent = transform;
		// RectTransform position = x.GetComponent<RectTransform>();
		// position.localPosition = new Vector3(20,-5,0);
		// position.localScale = new Vector3(0.3f,0.3f,0.3f);
		num = Random.Range(0,4);
		moveText.text = moves[num];
	}

	public void AddScore(int curScore) {
		// Debug.Log("Points:"+curScore.ToString());
		myScore.text = ((int.Parse(myScore.text)) + curScore).ToString();
		// removeKids();
	}

	// private void removeKids() {
	// 	foreach(Transform child in transform) {
	// 		Destroy(child.gameObject);
	// 	}
	// }

	public void makeMove(string danceMove) {
		dancer = GameObject.Find("UserDefinedTarget-1/sporty_granny");
		Animator anim = dancer.GetComponent<Animator>();
		anim.SetTrigger(danceMove);
	}

	public void Twerk() {
		if(num==0 && progress) {
			AddScore(100);
			makeMove("m4");
		}
		else {
			gameOver.SetActive(true);
			CancelInvoke("spawn");
			progress = false;
		}
	}
	public void HipHop() {
		if(num==1 && progress) {
			AddScore(100);
			makeMove("m2");
		}
		else {
			gameOver.SetActive(true);
			CancelInvoke("spawn");
			progress = false;
		}
	}
	public void Silly() {
		if(num==2 && progress) {
			AddScore(100);
			makeMove("m1");
		}
		else {
			gameOver.SetActive(true);
			CancelInvoke("spawn");
			progress = false;
		}
	}
	public void Party() {
		if(num==3 && progress) {
			AddScore(100);
			makeMove("m3");
		}
		else {
			gameOver.SetActive(true);
			CancelInvoke("spawn");
			progress = false;
		}
	}
}
