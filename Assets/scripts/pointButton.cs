using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointButton : MonoBehaviour {

	private int point = 500;
	private int[] points = {500,1000,1500,2000,2500,3000,3500,4000,4500,5000};
	private string[] moves = {"m1","m2","m3","m4"};
	private Text pointText;
	private float speed;
	private Image color;
	private string move;
	// Use this for initialization
	void Start () {
		pointText = GetComponentInChildren<Text>();
		point = points[Random.Range(0,10)];
		speed = Random.Range(6,12);
		pointText.text = point.ToString();
		color = GetComponent<Image>();
		Color newColor = new Color(Random.value,Random.value,Random.value,1.0f);
		color.color = newColor;
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(onTaskClicked);
		move = moves[Random.Range(0,4)];

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed*-1,0f,0f);
	}
	
	void onTaskClicked() {
		spawnerScript.instance.makeMove(move);
		spawnerScript.instance.AddScore(point);
		
	}
	
}
