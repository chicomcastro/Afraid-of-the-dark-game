using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPF3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ().HP = 100;
		gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
