using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

	public static bool SetCubeTeam;
	public static bool PlayerMove;
	public static bool IsRotating;
	public static int RotateNum;
	public static int OnCubeNum;
	public static GameObject BeTouchedObj;
	public static GameObject BeTouchedCube;
	public static GameObject BePointedObj;
	public static GameObject MissionObj;
	public int P_RotateNum;
	public GameObject Player;
	public static float PlayerX;
	public static float PlayerY;
	public static float PlayerZ;




	void Start () {
		BeTouchedObj = GameObject.Find ("Floor_Origin_V3");
		OnCubeNum = 1;
	}
	

	void Update () {
		PlayerX = Player.transform.position.x;
		PlayerY = Player.transform.position.y;
		PlayerZ = Player.transform.position.z;

	}

	public static void ClickRotate(){

		SetCubeTeam = true;

	}
}
