using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

	public static bool SetCubeTeam;
	public static int RotateNum;
	public int P_RotateNum;




	void Start () {
		
	}
	

	void Update () {
		RotateNum = P_RotateNum;
	}
}
