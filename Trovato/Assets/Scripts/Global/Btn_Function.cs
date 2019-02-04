using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;


public class Btn_Function : MonoBehaviour {

	bool IsShowing;
	bool ShowBlock = true;
	bool OneShot = true;
	bool Switch_01;
	GameObject[] Names;
	GameObject[] blocks;
	public Text Text_CamCtrl;

	// 自爆模式
	public GameObject Explosion;
	public GameObject Fire;


	GameObject Paneling;
	GameObject Panel_TopLeft{
		get{return GameObject.Find ("Panel_TopLeft");}
	}
	GameObject Panel_TopRight{
		get{return GameObject.Find ("Panel_TopRight");}
	}
	GameObject Panel_Bottom{
		get{return GameObject.Find ("Panel_Bottom");}
	}


	void Start () {
		//Names = GameObject.FindGameObjectsWithTag ("Name");
		//ShowName ();

		if (Global.Level != "0") {
			if (Screen.width == 1280) {
				Panel_TopLeft.transform.position = new Vector3 (Panel_TopLeft.transform.position.x, Screen.height - 40, Panel_TopLeft.transform.position.z);
				Panel_TopRight.transform.position = new Vector3 (Panel_TopRight.transform.position.x, Screen.height - 40, Panel_TopRight.transform.position.z);
				Panel_Bottom.transform.position = new Vector3 (Panel_Bottom.transform.position.x, 40, Panel_Bottom.transform.position.z);
			}
		}
	}

	void Update(){

		if (Paneling != null && Paneling.transform.localScale.x < 1 && Paneling.GetComponent<CanvasGroup> ().interactable == true) {
			Paneling.GetComponent<CanvasGroup> ().alpha += 0.05f;
			Paneling.transform.localScale += new Vector3 (0.025f, 0.025f, 0.025f);
		}

		if (Global.Level != "0") {
			if (MissionSetting.FlowerChart != null && MissionSetting.FlowerChart.HasExecutingBlocks () || MissionSetting.CamIsMoving || MissionSetting.CamIsMovingBack || Global.IsPreRotating || Global.IsRotating || PathController.FollowPath || CameraController.IsCamRotating || Global.IsPushing) {
				Panel_TopLeft.GetComponent<CanvasGroup> ().alpha = 0.8f;
				//Panel_TopLeft.GetComponent<CanvasGroup> ().interactable = false;
				Panel_TopLeft.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				Panel_TopRight.GetComponent<CanvasGroup> ().alpha = 0.8f;
				//Panel_TopRight.GetComponent<CanvasGroup> ().interactable = false;
				Panel_TopRight.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				Panel_Bottom.GetComponent<CanvasGroup> ().alpha = 0.8f;
				//Panel_TopLeft.GetComponent<CanvasGroup> ().interactable = false;
				Panel_Bottom.GetComponent<CanvasGroup> ().blocksRaycasts = false;


			} else {
				Panel_TopLeft.GetComponent<CanvasGroup> ().alpha = 1;
				//Panel_TopLeft.GetComponent<CanvasGroup> ().interactable = true;
				Panel_TopLeft.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				Panel_TopRight.GetComponent<CanvasGroup> ().alpha = 1;
				//Panel_TopRight.GetComponent<CanvasGroup> ().interactable = true;
				Panel_TopRight.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				Panel_Bottom.GetComponent<CanvasGroup> ().alpha = 0.8f;
				//Panel_TopLeft.GetComponent<CanvasGroup> ().interactable = false;
				Panel_Bottom.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			}
		}
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

	public void SwitchPanel(string PanelName){
		if (MissionSetting.FlowerChart != null && MissionSetting.FlowerChart.HasExecutingBlocks ())
			return;

		if (Paneling != null && Paneling.name != PanelName) {
			Paneling.GetComponent<CanvasGroup> ().alpha = 0;
			Paneling.GetComponent<CanvasGroup> ().interactable = false;
			Paneling.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}

		Paneling = GameObject.Find (PanelName);
		//Paneling.GetComponent<CanvasGroup> ().alspha = 0;
		Paneling.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);
		Paneling.transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);


		if (Paneling.GetComponent<CanvasGroup> ().interactable) {
			Paneling.GetComponent<CanvasGroup> ().alpha = 0;
			Paneling.GetComponent<CanvasGroup> ().interactable = false;
			Paneling.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			Global.StopTouch = false;
		} else {
			Paneling.GetComponent<CanvasGroup> ().alpha = 0.5f;
			Paneling.GetComponent<CanvasGroup> ().interactable = true;
			Paneling.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			Global.StopTouch = true;
		}
	}



	public void TestMode(){
		GameObject Btn_Test = GameObject.Find ("Btn_Test");
		GameObject[] buttons = new GameObject[Btn_Test.transform.childCount];
		for(int i = 0 ; i < Btn_Test.transform.childCount ; i++){
			buttons [i] = Btn_Test.transform.GetChild (i).gameObject;
			buttons [i].SetActive (buttons[i].activeSelf ? false : true);
			//buttons [i].GetComponent<Button> ().enabled = false;
			//buttons [i].GetComponent<Image> ().enabled = false;
		}
	}

	public void MusicSetting(){
		
		GameObject Text_BGM = GameObject.Find ("Text_BGM");
		GameObject Slider_BGM = GameObject.Find("Slider_BGM");
		GameObject AudioObj = GameObject.Find("Audio Source");

		Text_BGM.GetComponent<Text> ().text = Slider_BGM.GetComponent<Slider> ().value.ToString();
		AudioObj.GetComponent<AudioSource> ().volume = Slider_BGM.GetComponent<Slider> ().value / 100;
	}

	public void RotateSwitch(GameObject _text){
		if (Switch_01) {
			_text.GetComponent<Text> ().text = "視角";
			Global.IsCamCtrl = true;
			Switch_01 = false;
		} else {
			_text.GetComponent<Text> ().text = "魔方";
			Global.IsCamCtrl = false;
			Switch_01 = true;
		}
	}

	public void CamReset(){
		CameraController.CurrentCam.transform.position = CameraController.CamOriginPos;
		CameraController.CurrentCam.transform.rotation = CameraController.CamOriginRot;
		CameraController.CurrentCam.transform.LookAt (GameObject.Find("CamScript").GetComponent<CameraController> ().ScreenHeart.transform);
	}


	// 選擇關卡
	public void ToMenu(){
		Global.ResetVar ();
		SceneManager.LoadScene ("Menu_VD");
		//SceneManager.LoadScene ("Menu");
		
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
