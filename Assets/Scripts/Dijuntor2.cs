using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijuntor2 : MonoBehaviour {

	// Use this for initialization
	public GameObject[] alavanca;
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().apertouDijuntor2 = true;
		gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
