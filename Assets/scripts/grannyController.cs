using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grannyController : MonoBehaviour {
	public GameObject granny;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = granny.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeAnim(string str) {
		Debug.Log("Animator Change");
		anim.SetTrigger(str);
	}
}
