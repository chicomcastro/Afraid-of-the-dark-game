using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dijuntor1 : MonoBehaviour {


	public Sprite[] alavanca;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().apertouDijuntor1 = true;
		gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {


		
	}
}
