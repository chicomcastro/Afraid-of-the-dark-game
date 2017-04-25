using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScriptTest2 : MonoBehaviour {

	// Stuff about material
	public Material backgroundMaterial;


	// About Shaders variables
	int numberOfObjects;
	float[,] coord;


	void Start () {

		// For shader initializing
		numberOfObjects = 0;
	}

	// Update is called once per frame
	void Update () {

		// Add new graphic effects for renderize on shader
		if (Input.GetKey (KeyCode.Mouse0)) {
			//numberOfObjects++;
			Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			backgroundMaterial.SetFloat ("_XCoordinate", vec.x);
			backgroundMaterial.SetFloat ("_YCoordinate", vec.y);
			Debug.Log (Camera.main.ScreenToWorldPoint(Input.mousePosition));
			}

		// Sync with shader
		//Sync();
	}

	void Sync ()
	{
		backgroundMaterial.SetInt ("numberOfObjects", numberOfObjects);
		//backgroundMaterial.SetFloatArray ("_coordinates", coord);
	}
}
