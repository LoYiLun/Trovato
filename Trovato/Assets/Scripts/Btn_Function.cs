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
	public GameObject Explosion;
	public GameObject Fire;


	void Start () {
		//Names = GameObject.FindGameObjectsWithTag ("Name");
		//ShowName ();

	}
	

	void Update () {
		
	}

	// 開關Player移動功能
	public void StopPlayerMove()
	{
		if (Global.StopTouch) {
			Global.StopTouch = false;
			Global.Status.text = "正常";
		}else {
			Global.StopTouch = true;
			Global.Status.text = "禁止移動";
		}
	}

	// 開關物件名稱顯示
	public void ShowName()
	{
		Names = GameObject.FindGameObjectsWithTag ("Name");

		if (IsShowing) {
			for (int i = 0; i < Names.Length; i++) {
                if(Names[i].GetComponent<Canvas>() != null)
			    	Names[i].GetComponent<Canvas> ().enabled = false;
			}
			IsShowing = false;
		} 
		else 
		{
			for (int i = 0; i < Names.Length; i++) {
                if (Names[i].GetComponent<Canvas>() != null)
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
		Global.Retry ();

	}

	public void Explode(){
		GameObject[] Cubes;
		GameObject[] Floors;
		GameObject[] RotatePlanes;
		GameObject[] GhostWalls;
		Cubes = GameObject.FindGameObjectsWithTag ("Cube");
		Floors = GameObject.FindGameObjectsWithTag ("Floor");
		RotatePlanes = GameObject.FindGameObjectsWithTag ("RotatePlane");
		GhostWalls = GameObject.FindGameObjectsWithTag ("GhostWall");
		Explosion.GetComponent<Collider> ().enabled = true;
		foreach (GameObject cube in Cubes) {
			cube.AddComponent<Rigidbody> ();
		}
		foreach (GameObject floor in Floors) {
			floor.AddComponent<Rigidbody> ();
		}
		foreach (GameObject plane in RotatePlanes) {
			plane.AddComponent<Rigidbody> ();
		}
		foreach (GameObject wall in GhostWalls) {
			wall.AddComponent<Rigidbody> ();
		}
		Fire.SetActive (true);
		Global.Player.GetComponent<Collider> ().enabled = false;
		Global.StopTouch = true;
		Global.Status.text = "爆破完畢";
		Destroy (GameObject.Find("Btn_PlayerMove"));
		Destroy (GameObject.Find("Btn_Explode"));


	}


	public void ToLevel_01(){
		Global.IsPushing = false;
		SceneManager.LoadScene ("Level_01");
	}
	public void ToLevel_02(){
		Global.IsPushing = false;
		SceneManager.LoadScene ("Level_02");
	}
	public void ToLevel_03(){
		Global.IsPushing = false;
		SceneManager.LoadScene ("Level_03");
	}
}
