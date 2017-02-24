using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

	GameObject player;

	// About time
	float deltaTime = 0.5f;
	float time;

	// About health
	public float HP;
	float maxLife = 100.0f;
	public bool shouldTakeDamage = false;
	public float damageCooldownTime, damage = 15.0f;
	public int nextSceneNumber, currentSceneNumber;

	bool terminou;

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

		// Setting HP stuff
		HP = maxLife;

		// Initializing some variable
		healthBar.value = ReturnValue(HP);
		shouldTakeDamage = false;
		terminou = false;
		damageCooldownTime = Time.time;

		time = Time.time;
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

		if (Input.GetKeyDown (KeyCode.Escape))
			SceneManager.LoadScene ("Menu");
	}

	public void DealDamage (float damage)
	{
		HP -= damage;
	}

	float ReturnValue (float value)
	{
		return value / maxLife;
	}

	public void GameOver ()
	{
		if (!terminou){
			time = Time.time;
			terminou = true;
		}
		gameObject.GetComponent<fader> ().BeginFade (1);
		Time.timeScale = 1 - Time.timeScale;
		if (Time.time - time > 2)
			SceneManager.LoadScene (currentSceneNumber);

	}

	public void LevelOver(int temp) {
        StartCoroutine(callFadeOut(temp));        
    }

    IEnumerator callFadeOut(float x) {
        player.GetComponent<playerMovement>().canMove = false;
        yield return new WaitForSeconds(x);
        gameObject.GetComponent<fader>().BeginFade(1);
		SceneManager.LoadScene (nextSceneNumber);
    }
}
