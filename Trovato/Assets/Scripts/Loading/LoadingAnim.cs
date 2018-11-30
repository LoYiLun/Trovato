using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnim : MonoBehaviour {

	Text Text_Loading{
		get{ return GameObject.Find("Text_Loading").GetComponent<Text>();}
	}

	void Awake(){
		
	}

	void Start () {
		
	}
	

	void Update () {
		if(Time.timeSinceLevelLoad % 1.5f <= 0.5f){
			Text_Loading.text = "Loading.";
		}else if(Time.timeSinceLevelLoad % 1.5f <= 1){
			Text_Loading.text = "Loading..";
		}else if(Time.timeSinceLevelLoad % 1.5f <= 1.5f){
			Text_Loading.text = "Loading...";
		}
	}
}
