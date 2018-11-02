using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFormate : MonoBehaviour {

	public GameObject CubeLeader;
	public GameObject CubeHome;
	public GameObject[] RotatePlanes;
	public int FormationCount;

	void Start () {
		
	}
	

	void Update () {
		if (Global.Level == "3" || Global.Level == "4") {
			if (CubeController_V2.RotateCube != null && CubeController_V2.RotateCube.transform.parent == GameObject.Find ("CubeHome_V3").transform) {
				CubeLeader = GameObject.Find ("CubeLeader_V3");
				CubeHome = GameObject.Find ("CubeHome_V3");
				FormationCount = 9;
			} else if (CubeController_V2.RotateCube != null && CubeController_V2.RotateCube.transform.parent == GameObject.Find ("CubeHome_V2").transform) {
				CubeLeader = GameObject.Find ("CubeLeader_V2");
				CubeHome = GameObject.Find ("CubeHome_V2");
				FormationCount = 4;
			}
		}
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Cube") {


			other.transform.parent = CubeLeader.transform;
			if(CubeLeader.transform.childCount == FormationCount)
				gameObject.transform.position = new Vector3 (100, 100, 100);

		}

	}
}
