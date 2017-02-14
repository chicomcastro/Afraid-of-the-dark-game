using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ender : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.tag == "Player")
			GameObject.FindGameObjectWithTag ("Manager").GetComponent<F4Manager> ().acabou = true;
	}
}
