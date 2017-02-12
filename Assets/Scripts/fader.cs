using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fader : MonoBehaviour {

	public Texture2D gameOverTexture;

	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;

	private float alpha = 0f;
	private int fadeDir = -1; // -1 to fade out; +1 to fade in

	void OnGUI () {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), gameOverTexture);
	}

	public float BeginFade (int direction)
	{
		fadeDir = direction;
		return (fadeSpeed);
	}
}
