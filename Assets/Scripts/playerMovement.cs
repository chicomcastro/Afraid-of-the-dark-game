using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	
	float speed = 2.0f;

	void Update() {

		// Defining moving direction
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);

		// Moving
		transform.position += move * speed * Time.deltaTime;

		InvertPlayerSprite (move);
	}

	void InvertPlayerSprite (Vector3 move)
	{
		if (move.x > 0) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
		} else if (move.x < 0) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
		}
			
	}
}