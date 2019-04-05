using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour {

	public  Material FadeMat;
	private Material[] Omats;
	private Material[] mats;
	private bool FadeOut;
	private bool FadeIn;
	private float FadeSpeed = 0.025f;

	void Awake(){
		if(FadeMat == null)
			FadeMat = new Material(Shader.Find("Transparent/Z"));
		//FadeMat.color = new Color (0.75f, 0.75f, 0.75f, 1);
		FadeMat.color = new Color (1, 1, 1, 1);
		FadeMat.mainTexture = null;
		Omats = GetComponent<Renderer> ().materials;
		mats = GetComponent<Renderer> ().materials;
	}

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Z) || FadeOut) {
			FadeOut = true;
			FadeIn = false;
			mats [0] = FadeMat;
			mats [1] = FadeMat;
			mats [0].mainTexture = Omats [0].mainTexture;
			//mats [1].mainTexture = Omats [1].mainTexture;
			if (mats [0].color.a >= 0) {
				mats [0].color -= new Color (0, 0, 0, FadeSpeed);
				mats [1].color -= new Color (0, 0, 0, FadeSpeed);
			}
			GetComponent<Renderer> ().materials = mats;

		}

		if (Input.GetKeyDown(KeyCode.X) || FadeIn) {
			FadeOut = false;
			FadeIn = true;
			mats [0] = FadeMat;
			mats [1] = FadeMat;
			if (mats [0].color.a <= 1) {
				mats [0].color += new Color (0, 0, 0, FadeSpeed);
				mats [1].color += new Color (0, 0, 0, FadeSpeed);
			} else {
				mats [0] = Omats [0];
				mats [1] = Omats [1];
			}
			GetComponent<Renderer> ().materials = mats;
		}
	}

	public void PlayerFadeIn(){
		FadeIn = true;
		FadeOut = false;
	}

	public void PlayerFadeOut(){
		FadeIn = false;
		FadeOut = true;
	}

}
