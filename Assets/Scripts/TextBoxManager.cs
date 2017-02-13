using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public GameObject player;

    public bool isActive;
    public bool stopPlayerMov = true;

    private playerMovement playerBehaviour;

    // Use this for initialization
    void Start() {
        isActive = false;
        stopPlayerMov = true;
        textBox.SetActive(false);
        playerBehaviour = player.GetComponent<playerMovement>();

        /*if (textFile != null) {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0) {
            endAtLine = textLines.Length - 1;
        }*/

    }

    // Update is called once per frame
    void Update() {

        if (stopPlayerMov) {
            playerBehaviour.canMove = false;
        } else {
            playerBehaviour.canMove = true;
        }

        if (!isActive) return;

        if (currentLine == endAtLine) {
            textBox.SetActive(false);
            stopPlayerMov = false;
            isActive = false;
        } else {
            theText.text = textLines[currentLine];
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            currentLine++;
        }

       
    }

    public void ShowLines(int _initialLine, int _endLine, bool playerCanMove) {
        textBox.SetActive(true);
        currentLine = _initialLine;
        stopPlayerMov = !playerCanMove;
        theText.text = textLines[_initialLine];
        endAtLine = _endLine;
        isActive = true;
    }

    public void SelectText(TextAsset _theText) {
        textLines = new string[1];
        textLines = (_theText.text.Split('\n'));
    }
}
