﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	
	float speed = 2.0f;

	void Update() {
		
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

		transform.position += move * speed * Time.deltaTime;
	}
}