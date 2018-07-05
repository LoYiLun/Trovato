using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour {

	private GameObject MissionObj;
	private int MissionNum = 0;

	void Start () {
		
	}
	

	void Update () {
		MissionObj = Global.MissionObj;


		if (MissionObj.name == "M1")
			MissionNum = 1;

		if (MissionNum == 1) {
			
		}
	}
}
