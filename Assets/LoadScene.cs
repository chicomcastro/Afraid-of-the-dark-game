using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	int nextSceneNumber = 2;

	void Start ()
	{
		LoadNewScene ();
	}

	public void LoadNewScene () {
		SceneManager.LoadScene (nextSceneNumber);
	}
}
