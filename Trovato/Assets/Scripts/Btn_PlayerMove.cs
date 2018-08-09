using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_PlayerMove : MonoBehaviour {

	bool IsShowing = true;
	GameObject[] Names;

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
}
