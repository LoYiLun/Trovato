using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Btn_Function : MonoBehaviour {

	bool IsShowing;
	bool ShowBlock = true;
	bool OneShot = true;
	GameObject[] Names;
	GameObject[] blocks;
	public Text Text_CamCtrl;

	// 自爆模式
	public GameObject Explosion;
	public GameObject Fire;


	void Start () {
		//Names = GameObject.FindGameObjectsWithTag ("Name");
		//ShowName ();
	}

	// 開關物件名稱顯示
	public void ShowName(){
		Names = GameObject.FindGameObjectsWithTag ("Name");

		if (IsShowing) {
			for (int i = 0; i < Names.Length; i++) {
                if(Names[i].GetComponent<Canvas>() != null)
			    	Names[i].GetComponent<Canvas> ().enabled = false;
			}
			IsShowing = false;
		} else {
			for (int i = 0; i < Names.Length; i++) {
                if (Names[i].GetComponent<Canvas>() != null)
                    Names[i].GetComponent<Canvas> ().enabled = true;
			}
			IsShowing = true;
		}
	}

	// 開關路障
	public void HideRoadBlocks(){
		if (OneShot) {
			blocks = GameObject.FindGameObjectsWithTag ("RoadBlock");
			OneShot = false;
		}
		if (ShowBlock) {
			for (int i = 0; i < blocks.Length; i++) {
				blocks [i].SetActive (false);
				//blocks [i].GetComponent<Collider> ().enabled = false;
				//blocks [i].GetComponent<Renderer> ().enabled = false;
			}
			ShowBlock = false;
		} else {
			for (int i = 0; i < blocks.Length; i++) {
				blocks [i].SetActive (true);
				//blocks [i].GetComponent<Collider> ().enabled = true;
				//blocks [i].GetComponent<Renderer> ().enabled = true;
			}
			ShowBlock = true;
		}
	}

	// 重新來過
	public void Rebuild(){
		Global.Retry ();
	}

	// 自爆模式
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
		Destroy (GameObject.Find("Btn_PlayerMove"));
		Destroy (GameObject.Find("Btn_Explode"));
	}


	// 選擇關卡
	public void ToMenu(){
		Global.ResetVar ();
		SceneManager.LoadScene ("Menu");
	}
	public void ToLevel_00(){
		Global.ResetVar ();
		SceneManager.LoadScene ("Level_00");
	}
	public void ToLevel_01(){
		Global.ResetVar ();
		SceneManager.LoadScene ("Level_01");
	}
	public void ToLevel_02(){
		Global.ResetVar ();
		SceneManager.LoadScene ("Level_02");
	}
	public void ToLevel_03(){
		Global.ResetVar ();
		SceneManager.LoadScene ("Level_03");
	}
	public void ToLevel_04(){
		Global.ResetVar ();
		SceneManager.LoadScene ("Level_04");
	}
}
