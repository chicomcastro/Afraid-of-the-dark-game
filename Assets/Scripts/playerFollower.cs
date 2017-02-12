using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour {

	GameObject cam, player;
	public GameObject endLimit;

	Vector3 initialPosition;

	float speed = 1.5f, dt;

	bool cameraShouldMove;

	void Start ()
	{
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");

		// Setting initial position of the camera
		initialPosition = cam.transform.position;

		// Initializing some variables
		cameraShouldMove = false;
	}

	void Update ()
	{
		// Setting time changing at each frame
		dt = Time.deltaTime;

		// Seeing what direction we should move the camera
		Vector3 relativePosition = player.transform.position - cam.transform.position;

		if (cameraShouldMove && cam.transform.position.x >= initialPosition.x)
		{
			// Moving the camera
			cam.transform.Translate (relativePosition.x * speed * dt, 0, 0);
		}

		// Proofreading cam position to avoid bugs on camera moving
		if (cam.transform.position.x < initialPosition.x)
			cam.transform.position = initialPosition;
		if (cam.transform.position.x >= endLimit.transform.position.x)
			cam.transform.position = new Vector3 (endLimit.transform.position.x, cam.transform.position.y, cam.transform.position.z);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player")
			cameraShouldMove = true;
	}

	void OnTriggerEntert2D (Collider2D other)
	{
		if (other.tag == "Player")
			cameraShouldMove = false;
	}
}
