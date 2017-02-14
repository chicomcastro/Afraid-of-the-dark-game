using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criancasF3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if(GameObject.FindGameObjectWithTag ("Manager").GetComponent<F3levelManager> ().pegouBombinha)
			GameObject.FindGameObjectWithTag ("Manager").GetComponent<F3levelManager> ().acabou = true;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
