using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1Manager : MonoBehaviour {

	public GameObject _textManager;
	public GameObject player;
	public TextAsset lvlText;
	public GameObject _gamecontrol;
	private TextBoxManager textManager;
	private gameController gamecontrol;
	private playerMovement playerMov;
	public GameObject endOfLevel;

	public Texture2D endGameImage;

	public GameObject[] postes;
	public bool apertouDijuntor1;
	public bool apertouDijuntor2;

	public bool acabou = false;


	void Start () {
		postes [0].SetActive(false); // A 7
		postes [1].SetActive(false); // A 7
		postes [2].SetActive(true); // 6
		postes [3].SetActive(false); // 8
		postes [4].SetActive(false); // 8
		postes [5].SetActive(true); // 9
		postes [6].SetActive(false); // B 6
		postes [7].SetActive(false); // 4 6
		postes [8].SetActive(false); // D
		postes [9].SetActive(false); // D
		postes [10].SetActive(true); // Piscando
		postes [11].SetActive(true); // Piscando
		postes [12].SetActive(false); // 4 3

		gamecontrol = _gamecontrol.GetComponent<gameController>();
		textManager = _textManager.GetComponent<TextBoxManager>();
		playerMov = player.GetComponent<playerMovement>();
		playerMov.canMove = false;
		//Debug.Log(player.GetComponent<playerMovement>().canMove);
		StartCoroutine(esperaxseg(8));
	}
	// Update is called once per frame
	void Update () {

		if (apertouDijuntor1) {
			postes [0].SetActive(true);
			postes [1].SetActive(true);
			postes [2].SetActive(false);
			postes [7].SetActive (true);
			postes [8].SetActive(true);
			postes [9].SetActive(true);
		}
		if (apertouDijuntor2) {
			postes [3].SetActive(true);
			postes [4].SetActive(true);
			postes [2].SetActive(true);
		}

		if (acabou)
			CallEndOfLevel ();
	}

	IEnumerator esperaxseg(float x) {
		yield return new WaitForSeconds(x);
		textManager = _textManager.GetComponent<TextBoxManager>();
		textManager.SelectText(lvlText);
		textManager.ShowLines(0, 3, false);
	}

	IEnumerator esperayseg(float x) {
		yield return new WaitForSeconds(x);
		if (textManager.textBox) {
			textManager.textBox.SetActive(false);
		}
	}

	public void CallEndOfLevel() {
		textManager.SelectText(lvlText);
		textManager.ShowLines(4, 5, false);
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ().SetBool ("finish", true);
		gamecontrol.LevelOver(4);
	}
}
