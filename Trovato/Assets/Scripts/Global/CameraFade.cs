﻿using UnityEngine;
using System.Collections;

public class CameraFade : MonoBehaviour {

	public float FadeInTime = 1f;
	public float FadeOutTime = 1f;
	public Color FadeInColor = new Color(0.1F, 0.1F, 0.1F, 1);
	public Color FadeOutColor = new Color(0.1F, 0.1F, 0.1F, 1);

	public static bool FadeInIsStart = false;
	public static bool FadeOutIsStart = false;
	public static bool FadeInIsDone = false;
	public static bool FadeOutIsDone = false;

	private Texture2D t2d;
	private GUIStyle gs;


	private static float a = 0;

	void Awake (){
		//Global.Status.text = "淡入中";
		FadeInIsStart = false;
		FadeOutIsStart = false;
		FadeInIsDone = false;
		FadeOutIsDone = false;
		a = 0;

		t2d = new Texture2D (1, 1);
		t2d.SetPixel (0, 0, FadeInColor);
		t2d.Apply ();

		gs = new GUIStyle ();
		gs.normal.background = t2d;

		FadeIn();
	}

	void OnGUI (){
		GUI.depth = -1000;
		GUI.Label (new Rect (0, 0, Screen.width, Screen.height), t2d, gs);
	}

	void Update () {

		if(FadeInIsStart){
			if (a > 0) {
				a -= Time.deltaTime / FadeInTime;
				t2d.SetPixel (0, 0, new Color (FadeInColor.r, FadeInColor.g, FadeInColor.b, a));
				t2d.Apply ();
			}else{
				FadeInIsStart = false;
				FadeInIsDone = true;
				//Global.Status.text = "正常";
			}
		}

		if(FadeOutIsStart){
			if (a < 1) {
				a += Time.deltaTime / FadeOutTime;
				t2d.SetPixel (0, 0, new Color (FadeOutColor.r, FadeOutColor.g, FadeOutColor.b, a));
				t2d.Apply ();
			}else{
				FadeOutIsStart = false;
				FadeOutIsDone = true;
			}
		}

	}

	// 淡入
	public static void FadeIn(){
		a = 1;
		FadeInIsStart = true;
		FadeInIsDone = false;
	}

	// 淡出
	public static void FadeOut(){
		a = 0;
		FadeOutIsStart = true;
		FadeOutIsDone = false;
	}

}