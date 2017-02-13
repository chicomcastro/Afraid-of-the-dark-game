using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3levelManager : MonoBehaviour {

	// Use this for initialization
	public bool ligouDijuntor = false;
	public GameObject[] postes;
	public bool pegouBombinha = false;
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
		postes [3].SetActive (false);
		postes [4].SetActive (false);
		postes [5].SetActive (false);
		postes [6].SetActive (false);
		postes [7].SetActive (false);
		postes [8].SetActive (false);
		postes [9].SetActive (false);

		gamecontrol = _gamecontrol.GetComponent<gameController>();
		textManager = _textManager.GetComponent<TextBoxManager>();
		playerMov = player.GetComponent<playerMovement>();
		playerMov.canMove = false;
		//Debug.Log(player.GetComponent<playerMovement>().canMove);
		StartCoroutine(esperaxseg(2));
	}
	
	// Update is called once per frame
	void Update () {

		if (ligouDijuntor) {
			postes[0].SetActive(true);
			postes[1].SetActive(true);
			postes[2].SetActive(true);
		}
		if (acabou) {
			textManager.SelectText(lvlText);
			textManager.ShowLines(5, 7, false);
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<fader> ().gameOverTexture = fadeinpic;
			gamecontrol.LevelOver(5);
		}
		
	}

	IEnumerator esperaxseg(float x) {
		yield return new WaitForSeconds(x);
		textManager = _textManager.GetComponent<TextBoxManager>();
		textManager.SelectText(lvlText);
		textManager.ShowLines(0, 4, false);
	}

	IEnumerator esperayseg(float x) {
		yield return new WaitForSeconds(x);
		if (textManager.textBox) {
			textManager.textBox.SetActive(false);
		}
	}
}
