using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

	GameObject player;

	// About time
	float time, deltaTime = 0.5f;

	// About health
	public float HP;
	float maxLife = 100.0f;
	public bool shouldTakeDamage = false;
	public float damageCooldownTime, damage = 15.0f;

	// About UI
	public Slider healthBar;

	void Awake ()
	{
		Time.timeScale = 1;
	}

	void Start ()
	{
		// Setting the player gameobject
		player = GameObject.FindGameObjectWithTag ("Player");

		// Setting up initial reference of time
		time = Time.time;
	
		// Setting HP stuff
		HP = maxLife;

		// Initializing some variable
		healthBar.value = ReturnValue(HP);
		shouldTakeDamage = false;
		damageCooldownTime = Time.time;
	}

	void Update ()
	{
		// Setting HP at each frame
		healthBar.value = ReturnValue(HP);

		// Taking damage of the dark
		if (Time.time - damageCooldownTime >= deltaTime && shouldTakeDamage)
		{
			// Taking damage from player through DealDamage() function on GameController script
			DealDamage (damage);

			// Resenting time
			damageCooldownTime = Time.time;
		}

		// Checking if player if alive
		if (HP <= 0)
			GameOver ();
	}

	public void DealDamage (float damage)
	{
		HP -= damage;
	}

	float ReturnValue (float value)
	{
		return value / maxLife;
	}

	void GameOver ()
	{
		gameObject.GetComponent<fader> ().BeginFade (1);
		Time.timeScale = 1 - Time.timeScale;
	}
}
