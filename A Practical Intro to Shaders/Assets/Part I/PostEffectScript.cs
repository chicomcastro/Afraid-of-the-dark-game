using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour {

	public Material mat;

	void OnRenderImage ( RenderTexture src, RenderTexture dest ) {
		// srs is the full rendered scene that you would normally send directly to the monitor.
		// We are intercepting this so we can do a bit more work before passing it on.

		// What do you want? We wanna to pass our pixel into a material before being finally rendered
		// There's a function to it!

		Graphics.Blit (src, dest, mat);
	}
}

// OBS: Our material have a shader that just invert collor at first instance. We can code a little bit more... :)
