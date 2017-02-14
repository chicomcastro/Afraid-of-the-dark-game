using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damager : MonoBehaviour {

	// When in the dark, the player should take damage
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ().shouldTakeDamage = true;

			GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ().damageCooldownTime = Time.time;
		}
	}

	// When entering a light spot, the player is safe
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ().shouldTakeDamage = false;

			GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ().damageCooldownTime = Time.time;
		}
	}

	// Under a light spot, the player is safe
	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ().shouldTakeDamage = false;

			GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ().damageCooldownTime = Time.time;
		}
	}
}
