using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsInfo : MonoBehaviour {

	public int LevelNumber;
	private GameObject Ring;
	private GameObject BlackSide;
	private bool FadeOut;
	private string Name;

	void Awake(){
		BlackSide = GameObject.Find("Image_Black");
	}
	
	void OnMouseDown(){
		if(GameObject.Find("Group_Levels").activeSelf){
			if(GameObject.Find("UIScripts").GetComponent<ButtonEvents>().Panel_SelectMode.GetComponent<CanvasGroup>().alpha <= 0){
				Global.ResetVar ();
				Name = gameObject.name;
				BlackSide.GetComponent<Image>().enabled = true;
				FadeOut = true;
			}
		}


	}

	void Update(){
		if(FadeOut){
			BlackSide.GetComponent<Image>().color += new Color(0, 0, 0, 0.04f);
			if(BlackSide.GetComponent<Image>().color.a >= 1){
				if(gameObject.name == "Chapter01")
					SceneManager.LoadScene ("Level_01");
				if(gameObject.name == "Chapter02")
					SceneManager.LoadScene ("Level_02");
				if(gameObject.name == "Chapter03")
					SceneManager.LoadScene ("Level_03");
			}
		}
	}
}
