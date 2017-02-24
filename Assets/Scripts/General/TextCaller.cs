using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCaller : MonoBehaviour {

	gameController GameController;
	TextBoxManager textBoxManager;

	public int startLine, endLine;
	public bool playerCanMove = true;

	bool firstTime = false;

	void Start () {
		GameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ();
		textBoxManager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<TextBoxManager> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (!firstTime) {
			textBoxManager.SelectText (textBoxManager.textFile);
			textBoxManager.ShowLines (startLine, endLine, playerCanMove);
			firstTime = true;
		}
	}
}
