using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public GameObject[] postes;
	public bool apertouDijuntor1;
	public bool apertouDijuntor2;
	public bool acabou = false;


	void Start () {
		postes [0].SetActive(false);
		//postes [1].SetActive(false);
		postes [2].SetActive(false);
		postes [13].SetActive(false);
		postes [14].SetActive(false);
		postes [15].SetActive(false);
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

		//if (acabou) {
		//	GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameController> ().LevelOver ();
		//}
		
	}
}
