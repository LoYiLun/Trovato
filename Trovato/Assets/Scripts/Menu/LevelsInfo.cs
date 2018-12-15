using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsInfo : MonoBehaviour {

	public int LevelNumber;
	public bool IsUnlock;
	GameObject Ring;

	void Awake(){
		Ring = GameObject.Find("Ring_of_Levels");
	}

	void Start () {

	}
	

	void Update () {
		if (LevelNumber > Global.LevelUnlockCount) {
			IsUnlock = false;
			gameObject.GetComponent<Renderer> ().material.color = Color.black;
		} else {
			IsUnlock = true;
			if(Ring.GetComponent<Level_Ring>().CurrentLevel == gameObject)
				gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			else
				gameObject.GetComponent<Renderer> ().material.color = Color.gray;
		}
	}
}
