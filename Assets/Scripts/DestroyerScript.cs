using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll)
	{
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController>().GameOver ();
	}
}
