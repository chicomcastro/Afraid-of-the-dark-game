using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScriptTest1 : MonoBehaviour {

	// Stuff about material
	public Material backgroundMaterial;

	// Nothing until now
	Collider2D colliderObject;

	// About player movement
	float speed = 10.0f, dt;

	int[] _x = {-1, 1, 0, 0};
	int[] _y = {0, 0, 1, -1};

	KeyCode[] input = {KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S}; 


	// About Shaders variables
	float[] coord;


	// Some definitions
	const int ESQUERDA = 0, DIREITA = 1, CIMA = 2, BAIXO = 3;



	void Start () {
		// Nothing until now
		colliderObject = GetComponent<Collider2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		dt = Time.deltaTime;

		backgroundMaterial.SetFloat ("_XCoordinate", gameObject.transform.position.x/10);
		backgroundMaterial.SetFloat ("_YCoordinate", gameObject.transform.position.y/10);

		//colliderObject.offset = new Vector2 ();

		if (Input.GetKey (input[CIMA]) )
			MoverPara (CIMA);
		if (Input.GetKey (input[BAIXO]) )
			MoverPara (BAIXO);
		if (Input.GetKey (input[ESQUERDA]) )
			MoverPara (ESQUERDA);
		if (Input.GetKey (input[DIREITA]) )
			MoverPara (DIREITA);

	}

	void MoverPara(int direcao)
	{
		transform.position += new Vector3 (_x [direcao] * speed * dt, _y [direcao] * speed * dt, 0);
	}
}
