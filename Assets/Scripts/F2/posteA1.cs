using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posteA1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerExit2D(Collider2D col)
	{
		gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
