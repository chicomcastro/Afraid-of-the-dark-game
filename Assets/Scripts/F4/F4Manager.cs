using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4Manager : MonoBehaviour {

	public GameObject _textManager;
	public GameObject player;
	public TextAsset lvlText;
	public GameObject _gamecontrol;
	private TextBoxManager textManager;
	private gameController gamecontrol;
	private playerMovement playerMov;
	public GameObject endOfLevel;
	public GameObject lightObject;

	public Texture2D endGameImage;

	float time;
	int counter = 0;
	bool[] controlling = new bool[] {false, false, false, false};
	bool pisca = false, stop = false;

	public GameObject destroyer;
	float speed = 1.0f;

	public bool acabou = false;

	void Start() {

		time = Time.time;

		gamecontrol = _gamecontrol.GetComponent<gameController>();
		textManager = _textManager.GetComponent<TextBoxManager>();
		playerMov = player.GetComponent<playerMovement>();
		playerMov.canMove = false;
	}

	void Update() {

		float dT = Time.deltaTime;

		if (Time.time - time > 1.0f && !controlling[0]) {
			StartCoroutine(esperaxseg(1, 0, 2));
			player.GetComponent<SpriteRenderer> ().flipX = true;

			controlling [0] = true;

			time = Time.time;
		}



		if (Time.time - time > 8.0f && controlling[0] && !controlling[1]) {

			StartCoroutine(esperaxseg(1, 3, 7));
			player.GetComponent<SpriteRenderer> ().flipX = false;

			controlling [1] = true;

			time = Time.time;
		}


		if (Time.time - time > 15.0f && !controlling[2]) {
			controlling [2] = true;
			pisca = true;
		}

		if (pisca && Time.time - time > 0.25f && !stop) {
			lightObject.SetActive (!lightObject.activeInHierarchy);
			counter++;
		}

		if (counter == 100)
			stop = true;


		if (Time.time - time > 3.0f && controlling[2] && !controlling[3]) {
			StartCoroutine(esperaxseg(1, 8, 9));

			controlling [3] = true;
		}


		if (controlling [3] && player.GetComponent<playerMovement> ().canMove)
			destroyer.transform.position += new Vector3 (speed * dT, 0, 0);


		if (acabou)
			CallEndOfLevel();
	}

	IEnumerator esperaxseg(float x, int inic, int fim) {
		yield return new WaitForSeconds(x);
		textManager = _textManager.GetComponent<TextBoxManager>();
		textManager.SelectText(lvlText);
		textManager.ShowLines(inic, fim, false);
	}

	void CallEndOfLevel() {
		textManager.SelectText(lvlText);
		textManager.ShowLines(10, 12, false);
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<fader> ().gameOverTexture = endGameImage;
		gamecontrol.LevelOver(4);
	}
}
