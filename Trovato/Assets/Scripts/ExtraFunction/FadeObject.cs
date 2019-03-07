using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour {

	public Material Z;
	Material[] Omats;
	Material[] mats;
	bool FadeOut;
	bool FadeIn;
	float FadeSpeed = 0.025f;

	void Awake(){
		Z = new Material(Shader.Find("Transparent/Z"));
		Z.color = new Color (0.75f, 0.75f, 0.75f, 1);
		Z.mainTexture = null;
		Omats = GetComponent<Renderer> ().materials;
		mats = GetComponent<Renderer> ().materials;
	}

	void Start () {
		
	}

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Z) || FadeOut) {
			FadeOut = true;
			FadeIn = false;
			mats [0] = Z;
			mats [1] = Z;
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
			mats [0] = Z;
			mats [1] = Z;
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

}
