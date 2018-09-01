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

	void Awake(){
		Player = GetPlayer;
		Level = GetLevel;
		Player.transform.parent = null;
		BeTouchedObj = Player;
		switch (Level) {
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
	}

	void Start () {

	}
	

	void Update () {
		Status = GetStatus;

		if (Player.activeSelf) 
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
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
