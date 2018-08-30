using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Btn_Function : MonoBehaviour {

	bool IsShowing = true;
	GameObject[] Names;
	public Text Text_CamCtrl;
	bool ShowBlock = true;
	bool OneShot = true;
	GameObject[] blocks;


	void Start () {
		//Names = GameObject.FindGameObjectsWithTag ("Name");
		//ShowName ();

	}
	

	void Update () {
		
	}

	// 開關Player移動功能
	public void StopPlayerMove()
	{
		if (Global.StopTouch)
			Global.StopTouch = false;
		else
			Global.StopTouch = true;
	}

	// 開關物件名稱顯示
	public void ShowName()
	{
		Names = GameObject.FindGameObjectsWithTag ("Name");

		if (IsShowing) {
			for (int i = 0; i < Names.Length; i++) {
				Names[i].GetComponent<Canvas> ().enabled = false;
			}
			IsShowing = false;
		} 
		else 
		{
			for (int i = 0; i < Names.Length; i++) {
				Names[i].GetComponent<Canvas> ().enabled = true;
			}
			IsShowing = true;
		}
	}

	public void CamCtrl()
	{
		if (Global.IsCamCtrl) {
			Global.IsCamCtrl = false;
			Text_CamCtrl.text = "轉動視角Off";
		} else {
			Global.IsCamCtrl = true;
			Text_CamCtrl.text = "轉動視角On";
		}
	}

	public void HideRoadBlocks(){
		if (OneShot) {
			blocks = GameObject.FindGameObjectsWithTag ("RoadBlock");
			OneShot = false;
		}
		if (ShowBlock) {
			for (int i = 0; i < blocks.Length; i++) {
				blocks [i].SetActive (false);
			}
			ShowBlock = false;
		} else {
			for (int i = 0; i < blocks.Length; i++) {
				blocks [i].SetActive (true);
			}
			ShowBlock = true;
		}

	
	}

	public void Rebuild(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);

	}

	public void ToLevel_01(){
		SceneManager.LoadScene ("Level_01");
	}
	public void ToLevel_02(){
		SceneManager.LoadScene ("Level_02");
	}
	public void ToLevel_03(){
		SceneManager.LoadScene ("Level_03");
	}
}
