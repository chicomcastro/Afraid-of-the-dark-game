using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancing : MonoBehaviour {

	// Use this for initialization
	int i =0;
	float time;
	float delta_time = 0.3f;
	public Sprite[] animacao;
	SpriteRenderer spriteRenderer;
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - time > delta_time) {
			spriteRenderer.sprite = animacao [i];
			if (i == 1)
				i = -1;
			i++;
			time = Time.time;
		}
		
		
	}
}
