using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
	
	void Awake()
	{
		GameObject aux = GameObject.Find ("BackgroundMusic");

		if (aux != this.gameObject)
			Destroy (aux);
		
		DontDestroyOnLoad (transform.gameObject);
	}
}