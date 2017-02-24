using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour {

	GameObject cam, player, superiorLimit, inferiorLimit;

	float speed = 1.5f, dt;

	public bool cameraShouldMove;

	void Start ()
	{
		// Setting some game objects to be used
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
		superiorLimit = GameObject.FindGameObjectWithTag ("SL");
		inferiorLimit = GameObject.FindGameObjectWithTag ("IL");

		// Initializing some variables
		cameraShouldMove = false;
	}

	void Update ()
	{
		// Setting time changing at each frame
		dt = Time.deltaTime;

		// Seeing what direction we should move the camera
		Vector3 relativePosition = player.transform.position - cam.transform.position;

		if (cameraShouldMove)
		{
			// Moving the camera
			cam.transform.position = new Vector3 (
				Mathf.Clamp (cam.transform.position.x + relativePosition.x * speed * dt, superiorLimit.transform.position.x, inferiorLimit.transform.position.x),
				Mathf.Clamp (cam.transform.position.y + relativePosition.y * speed * dt, inferiorLimit.transform.position.y, superiorLimit.transform.position.y),
				cam.transform.position.z
			);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
			cam.GetComponent<Animator> ().enabled = false;
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player")
			cameraShouldMove = true;
	}
}
