using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject instructions;

	void Start ()
	{
		instructions.SetActive (false);
	}

	public void LoadLevel ()
	{
		SceneManager.LoadScene ("InitialCutscene");
	}

	public void How ()
	{
		instructions.SetActive (!instructions.activeInHierarchy);
	}

	public void Exit ()
	{
		Application.Quit ();
	}
}
