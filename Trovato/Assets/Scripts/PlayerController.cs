using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject Player;
	private Vector3 MoveToTarget;
	private Vector3 MoveDir;
	private float MoveL;
	private float MoveR;
	private float TargetL;
	private float TargetR;
	//private float MoveSpeed = 0.05f;

	void Start () {
		//Player = GameObject.Find ("Player");
	}
	

	void Update () {
		MoveToTarget = Global.BeTouchedObj.transform.position;
		MoveL = -(MoveToTarget.z - Player.transform.position.z);
		MoveR = -(MoveToTarget.x - Player.transform.position.x);


		if (Global.PlayerMove) {
			if (Mathf.Abs (MoveR) > 0.11f) {
				if (MoveR > 0) {
					Player.transform.position += new Vector3 (-0.1f, 0, 0);
				} else if (MoveR < 0) {
					Player.transform.position += new Vector3 (0.1f, 0, 0);
				}
			} else if (Mathf.Abs (MoveL) > 0.11f) {
				if (MoveL > 0) {
					Player.transform.position += new Vector3 (0, 0, -0.1f);
				} else if (MoveL < 0) {
					Player.transform.position += new Vector3 (0, 0, 0.1f);
				}
			} else {
				Player.transform.position = MoveToTarget + new Vector3(0,1.5f,0);
				Global.PlayerMove = false;
			}


		}

	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Mission") {
			Global.MissionObj = other.gameObject;
		}
		if (other.gameObject.name == "Portal") {
			Global.PlayerMove = false;
			Player.transform.position = new Vector3(-16,6,16);
		}
	}

	/*
	void StartMove(){

		MoveDir = MoveToTarget - Player.transform.position;
		TargetL = MoveToTarget.z;
		TargetR = MoveToTarget.x;
		Player.transform.position = Vector3.MoveTowards (Player.transform.position, MoveToTarget+new Vector3(TargetR,1,0), MoveSpeed*Time.deltaTime);
	}*/

}
