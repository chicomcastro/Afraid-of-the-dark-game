using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevel : MonoBehaviour {

    public GameObject _textManager;
    public GameObject player;
    public TextAsset lvlText;
    public GameObject _gamecontrol;
    private TextBoxManager textManager;
    private gameController gamecontrol;
    private playerMovement playerMov;
    private bool didntTookDamageYet = true;
    public GameObject endOfLevel;

	public Texture2D startGameImage;
	public Texture2D endGameImage;
	private Texture2D aux;

	void Awake()
	{
		aux = GameObject.FindGameObjectWithTag ("GameController").GetComponent<fader> ().gameOverTexture;
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<fader> ().gameOverTexture = startGameImage;
		_gamecontrol.GetComponent<fader> ().BeginFade (-1);
	}

    // Use this for initialization
    void Start() {
        gamecontrol = _gamecontrol.GetComponent<gameController>();
        textManager = _textManager.GetComponent<TextBoxManager>();
        playerMov = player.GetComponent<playerMovement>();
        playerMov.canMove = false;
        //Debug.Log(player.GetComponent<playerMovement>().canMove);
        StartCoroutine(esperaxseg(2));
		_gamecontrol.GetComponent<fader> ().gameOverTexture = aux;
    }

    // Update is called once per frame
    void Update() {
        if (didntTookDamageYet && gamecontrol.HP < 100.0f) {
            textManager.ShowLines(1, 2, true);
            didntTookDamageYet = false;
            StartCoroutine(esperayseg(2));        
        } 
		if((Mathf.Abs(player.transform.position.x - endOfLevel.transform.position.x) < 1.0f)) {
            CallEndOfLevel();
        }
    }

    IEnumerator esperaxseg(float x) {
        yield return new WaitForSeconds(x);
        textManager = _textManager.GetComponent<TextBoxManager>();
        textManager.SelectText(lvlText);
        textManager.ShowLines(0, 1, false);
    }

    IEnumerator esperayseg(float x) {
        yield return new WaitForSeconds(x);
        if (textManager.textBox) {
            textManager.textBox.SetActive(false);
        }
    }

    void CallEndOfLevel() {
        textManager.SelectText(lvlText);
		textManager.ShowLines(2, 3, false);
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ().SetBool ("finish", true);
		gamecontrol.LevelOver(4);
    }
}