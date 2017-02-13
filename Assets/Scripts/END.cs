using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().acabou = true;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
