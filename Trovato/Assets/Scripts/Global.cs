using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour {

	public int P_RotateNum;
	public GameObject GetPlayer;
	public static GameObject Player; 
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


	void Start () {
		Player = GetPlayer;
		Player.transform.parent = null;
		BeTouchedObj = GameObject.Find ("Floor_Origin_V3");
		OnCubeNum = 1;
	}
	

	void Update () {

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
