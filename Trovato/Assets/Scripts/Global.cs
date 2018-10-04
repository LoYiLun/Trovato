using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Global : MonoBehaviour {

	public string GetLevel;
	public static string Level;

	public int P_RotateNum;
	public GameObject GetPlayer;
	public static GameObject Player; 

	// Obj的是左鍵，Cube的是右鍵
	public static GameObject BeTouchedObj;
	public static GameObject BeTouchedCube;
	public static GameObject BePointedObj;
	public static GameObject MissionObj;
	public static bool SetCubeTeam;
	public static bool PlayerMove;
	public static bool IsRotating;
	public static int RotateNum;
	public static int OnCubeNum;
	public static float PlayerX;
	public static float PlayerY;
	public static float PlayerZ;

	public static bool PlayerMoveBtn;
	public static bool StopTouch;
	public static bool IsCamCtrl;

	public static Material YellowSkin;
	public Text GetStatus;
	public static Text Status;

	public static GameObject NextTarget;

	public static GameObject RotatePlane;
	public static GameObject RotateCube;
	public static GameObject RotateArrow;

	public GameObject GetTargetlight;
	public static ParticleSystem Targetlight;
	public static bool IsPushing;
	public static GameObject BePushedObj;
	public static bool Wait;

	public static bool Oneshot;

	void Awake(){
		if(GetPlayer != null)
			Player = GetPlayer;
		Level = GetLevel;
		if(Player != null)
			Player.transform.parent = null;
		BeTouchedObj = null;
		switch (Level) {
		case"0":
			OnCubeNum = 0;
			break;

		case"1":
			OnCubeNum = 2;
			break;

		case"2":
		case"3":
			OnCubeNum = 1;
			break;
		}
		YellowSkin =  Resources.Load ("Materials/Yellow", typeof(Material)) as Material;
		Status = GetStatus;
		if(GetTargetlight != null)
			Targetlight = GetTargetlight.GetComponent<ParticleSystem> ();
	}

	void Start () {
		
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.R))
			Retry ();

		Status = GetStatus;

		if (Player != null) 
		{
			PlayerX = Player.transform.position.x;
			PlayerY = Player.transform.position.y;
			PlayerZ = Player.transform.position.z;
		}
	}

	public static void ClickRotate(){
		SetCubeTeam = true;
	}

	public static void Retry(){
		IsRotating = false;
		IsCamCtrl = false;
		IsPushing = false;
		BeTouchedObj = null;
		BeTouchedCube = null;
		BePushedObj = null;
		PlayerMove = false;
		StopTouch = false;
		Wait = false;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
