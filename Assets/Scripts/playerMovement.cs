using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	
	float speed = 3.0f;
	float delta_time = 0.1f;
	int i = 1;
	float time;
	bool ismoving = false;
	bool startedMoving = false;
    public bool canMove = true;
	public Sprite[] animacao;
	SpriteRenderer spriteRenderer;
	void Start(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = animacao [0];
		time = Time.time;
	}
	void Update() {
    
		// Defining moving direction
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);

        // Moving
        if (canMove) {
            transform.position += move * speed * Time.deltaTime;
			if (move.magnitude != 0) {
				if (Time.time - time > delta_time) {
					spriteRenderer.sprite = animacao [i];
					if (i == 2)
						i = 0;
					i++;
					time = Time.time;
				} 
			}
			else
				spriteRenderer.sprite = animacao [0];

            InvertPlayerSprite(move);

        }
	}
		
	void InvertPlayerSprite (Vector3 move)
	{
		if (move.x > 0) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
		} else if (move.x < 0) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
		}
			
	}
}