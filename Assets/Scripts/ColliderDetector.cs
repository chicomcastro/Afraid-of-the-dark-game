using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour {

	public bool interruptor1 = false, interruptor2 = false;

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (interruptor1)
			GameObject.FindGameObjectWithTag ("Manager").GetComponent<F1Manager> ().apertouDijuntor1 = true;
		if (interruptor2)
			GameObject.FindGameObjectWithTag ("Manager").GetComponent<F1Manager> ().apertouDijuntor2 = true;

		gameObject.SetActive (false);
	}
}
