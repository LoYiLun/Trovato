using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Btn_Function : MonoBehaviour {

	bool IsShowing = true;
	//bool IsHiding = false;
	GameObject[] Names;
	public Text Text_CamCtrl;

	void Start () {
		Names = GameObject.FindGameObjectsWithTag ("Name");
		ShowName ();
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
		

		/*
		if (IsHiding) {
			for(int j = 0 ; j < Global.Blocks.Length ; j++){
				Global.Blocks [j].SetActive (true);
				//blocks.SetActive (false);
				print(j);
			}
				IsHiding = false;

		} else {
			for(int j = 0 ; j < Global.Blocks.Length ; j++){	
				Global.Blocks [j].SetActive (false);
				//blocks.SetActive (true);
			}
				IsHiding = true;
			}
		*/
	}
}
