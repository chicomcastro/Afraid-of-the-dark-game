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

    public playerMovement player;

    public bool isActive;
    public bool stopPlayerMov;

    // Use this for initialization
    void Start() {

        player = FindObjectOfType<playerMovement>();

        if (textFile != null) {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0) {
            endAtLine = textLines.Length - 1;
        }

    }

    // Update is called once per frame
    void Update() {

        if (stopPlayerMov) {
            player.canMove = false; //Implementar
        }

        if (!isActive) return;

        theText.text = textLines[currentLine];

        if (Input.GetKeyDown("space")) {
            currentLine++;
        }

        if(currentLine == endAtLine) {
            textBox.SetActive(false);
            stopPlayerMov = false;
        }
    }

    void ShowLines(int _initialLine, int _endLine, bool playerCanMove) {
        textBox.SetActive(true);
        stopPlayerMov = !playerCanMove;
        theText.text = textLines[_initialLine];
        endAtLine = _endLine;
    }
}
