using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public GameObject[] postes;
	public bool apertouDijuntor1;
	public bool apertouDijuntor2;
	public bool acabou = false;
	public Texture2D fadeinpic;

	public GameObject _textManager;
	public GameObject player;
	public TextAsset lvlText;
	public GameObject _gamecontrol;
	private TextBoxManager textManager;
	private gameController gamecontrol;
	private playerMovement playerMov;
	public GameObject endOfLevel;

	void Start () {
		postes [0].SetActive(false);
		//postes [1].SetActive(false);
		postes [2].SetActive(false);
		postes [13].SetActive(false);
		postes [14].SetActive(false);
		postes [15].SetActive(false);
		postes [16].SetActive(false);

		gamecontrol = _gamecontrol.GetComponent<gameController>();
		textManager = _textManager.GetComponent<TextBoxManager>();
		playerMov = player.GetComponent<playerMovement>();
		playerMov.canMove = false;
		//Debug.Log(player.GetComponent<playerMovement>().canMove);
		StartCoroutine(esperaxseg(2));

	}
	// Update is called once per frame
	void Update () {
		if (apertouDijuntor1) {
			postes [0].SetActive(true);
			postes [1].SetActive(true);
			postes [2].SetActive(true);
			postes [3].SetActive(false);
			postes [4].SetActive(false);
			postes [5].SetActive(false);
			postes [6].SetActive(false);
			postes [7].SetActive(false);
		}
		if (apertouDijuntor2) {
			postes [3].SetActive(true);
			postes [4].SetActive(true);
			postes [5].SetActive(true);
			postes [8].SetActive(false);
			postes [9].SetActive(false);
			postes [10].SetActive(false);
			postes [11].SetActive(false);
			postes [12].SetActive(false);
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ().shouldTakeDamage = true;
		}

		if (acabou) {
			textManager.SelectText(lvlText);
			textManager.ShowLines(2, 3, false);
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<fader> ().gameOverTexture = fadeinpic;
			gamecontrol.LevelOver(1);

		}
		
	}

	IEnumerator esperaxseg(float x) {
		yield return new WaitForSeconds(x);
		textManager = _textManager.GetComponent<TextBoxManager>();
		textManager.SelectText(lvlText);
		textManager.ShowLines(0, 2, false);
	}

	IEnumerator esperayseg(float x) {
		yield return new WaitForSeconds(x);
		if (textManager.textBox) {
			textManager.textBox.SetActive(false);
		}
	}
}
