using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombinhaF3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		GameObject.FindGameObjectWithTag ("Manager").GetComponent<F3levelManager> ().pegouBombinha = true;
		gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
