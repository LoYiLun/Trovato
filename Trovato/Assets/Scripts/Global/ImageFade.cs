using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour {

	public Image Tips_Box;
	public static bool FadeIn;
	public static bool FadeOut;
	float a;
	float b;
	bool max;

	void Start () {
		Tips_Box = GameObject.Find ("Tips_Box").GetComponent<Image> ();
		a = 0;
		b = 1;
		Global.StopTouch = true;
	}

	void FixedUpdate () {

		if ((Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) && FadeOut == false) {
			if (Tips_Box.color.a == 1f) {
				FadeOut = true;
			}
		}

		if (Tips_Box.color.a == 1f) {
			max = true;
		}

		if (Tips_Box.color.a < 0.1f && max) {
			Global.StopTouch = false;
		} else {
			Global.StopTouch = true;
		}


		/*
		if (FadeIn) {
			if (a < 1) {
				a += Time.deltaTime * 0.8f;
				Tips_Box.color = new Color (255, 255, 255, a);
			} else {
				

				StartCoroutine (fadeout ());
				if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) {
					FadeOut = true;
					StopCoroutine (fadeout ());
				}
			}
		}*/

		if (FadeOut) {
			if (b > 0) {
				b -= Time.deltaTime * 0.5f;
				Tips_Box.color = new Color (255, 255, 255, b);
			} else {
				Global.StopTouch = false;
				Tips_Box.enabled = false;
			}
		}
	}

	/*
	IEnumerator fadeout(){


		for (float i=0; i < 0.5f; i += Time.deltaTime) {
			yield return new WaitForSeconds (0.1f);


		}
		FadeOut = true;
		yield break;

	}*/
}
