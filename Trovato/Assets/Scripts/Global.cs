using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

	public static bool SetCubeTeam;
	public static bool PlayerMove;
	public static bool IsRotating;
	public static int RotateNum;
	public static GameObject BeTouchedObj;
	public static GameObject BeTouchedCube;
	public static GameObject MissionObj;
	public int P_RotateNum;





	void Start () {
		BeTouchedObj = GameObject.Find ("Floor_Origin");
	}
	

	void Update () {
		//RotateNum = P_RotateNum;
	}
}
