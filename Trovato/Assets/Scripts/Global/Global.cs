using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Global : MonoBehaviour {

	// 目前的關卡
	public string GetLevel;
	public static string Level;

	// 目前的主角
	public GameObject GetPlayer;
	public static GameObject Player; 

	// Obj的是左鍵，Cube的是右鍵
	public static GameObject BeTouchedObj;
	public static GameObject BeTouchedCube;
	public static GameObject BePointedObj;
	public static bool SetCubeTeam;
	public static bool PlayerMove; // 主角是否能移動
	public static bool IsRotating; // 魔方正在轉動
	public static bool IsPreRotating;
	public static int RotateNum; // 轉動面編號
	public static int OnCubeNum; // 主角所在魔方編號

	// 主角座標位置
	public static float PlayerX;
	public static float PlayerY;
	public static float PlayerZ;

	// 滑鼠輸入開關
	public static bool StopTouch;

	// 鏡頭控制開關
	public static bool IsCamCtrl;

	// 目的地
	public static GameObject NextTarget;

	// 右鍵旋轉
	public static GameObject RotatePlane;
	public static GameObject RotateCube;
	public static GameObject RotateArrow;

	// 點擊目的地特效
	public GameObject GetTargetlight;
	public static ParticleSystem Targetlight;

	// 推箱子
	public static bool IsPushing;
	public static GameObject BePushedObj;

	// 走路前定位開關
	public static bool Wait;
	public static bool Oneshot;

	public static GameObject LevelEnd;
	public static int NextScene = 1;

	public static bool StartFinding;

	void Awake(){
		ResetVar();

		
		if(GetPlayer != null)
			Player = GetPlayer;
		Level = GetLevel;
		if (Player != null && GameObject.Find("PlayerHome"))
			Player.transform.SetParent (GameObject.Find("PlayerHome").transform);
		BeTouchedObj = null;
		switch (Level) {
		case"0":
			OnCubeNum = 1;
			break;

		case"1":
			OnCubeNum = 2;
			break;

		case"2":
		case"3":
		case"4":
			OnCubeNum = 1;
			break;
		}
		if(GetTargetlight != null)
			Targetlight = GetTargetlight.GetComponent<ParticleSystem> ();
	}

	void Start () {
		

	}
	

	void FixedUpdate () {

		if (LevelEnd != null && LevelEnd.activeSelf) {
			ToNextLevel (NextScene);
		}

		if (Input.GetKeyDown (KeyCode.R))
			Retry ();

		if (Player != null) 
		{
			PlayerX = Player.transform.position.x;
			PlayerY = Player.transform.position.y;
			PlayerZ = Player.transform.position.z;
		}
	}

	public static void ToNextLevel(int scene){
		ResetVar ();
		SceneManager.LoadScene (scene);
	}

	public static void ClickRotate(){
		SetCubeTeam = true;
	}

	public static void ResetVar(){
		IsRotating = false;
		IsCamCtrl = false;
		IsPushing = false;
		BeTouchedObj = null;
		BeTouchedCube = null;
		BePushedObj = null;
		PlayerMove = false;
		StopTouch = false;
		Wait = false;
		StartFinding = false;
		ImageFade.FadeIn = false;
		ImageFade.FadeOut = false;
		PlayerController.MoveSpeed = 4f;
		PlayerStatusImage.Status = null;
		CameraFade.FadeInIsStart = true;
		CameraFade.FadeOutIsStart = false;
		CameraFade.FadeInIsDone = false;
		CameraFade.FadeOutIsDone = false;
		PathController.FollowPath = false;
		GameObject.Find("GlobalScripts").GetComponent<PathController> ().BeTouchedFloor = null;
	}

	public static void Retry(){
		ResetVar ();
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
