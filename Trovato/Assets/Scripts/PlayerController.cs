using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 MoveToTarget;
	private Vector3 MoveDir;
	private float MoveL;
	private float MoveR;
	private float MoveD;
	private float TargetL;
	private float TargetR;
	GameObject Box;
	GameObject Player;
	float PushX;
	float PushY;
	float PushZ;
	Vector3 NowPos;
	Vector3 FixedHeight;

	//private float MoveSpeed = 0.05f;

	void Start () {
		Player = Global.Player;
		FixedHeight = new Vector3 (0, 1.3f, 0);
	}
	

	void FixedUpdate () {
		Player = Global.Player;
		MoveToTarget = Global.BeTouchedObj.transform.position;
		MoveL = -(MoveToTarget.z - Player.transform.position.z);
		MoveR = -(MoveToTarget.x - Player.transform.position.x);
		MoveD = -(MoveToTarget.y - Player.transform.position.y);


		if (Global.PlayerMove && Global.IsRotating == false) {
			if (Mathf.Abs (MoveR) > 0.11f) {
				if (MoveR > 0) {
					Player.transform.position += new Vector3 (-0.1f, 0, 0);
					PushX = -1;
					PushZ = 0;
				} else if (MoveR < 0) {
					Player.transform.position += new Vector3 (0.1f, 0, 0);
					PushX = 1;
					PushZ = 0;
				}
			} else if (Mathf.Abs (MoveL) > 0.11f) {
				if (MoveL > 0) {
					Player.transform.position += new Vector3 (0, 0, -0.1f);
					PushZ = -1;
					PushX = 0;
				} else if (MoveL < 0) {
					Player.transform.position += new Vector3 (0, 0, 0.1f);
					PushZ = 1;
					PushX = 0;
				}
			} else if(Mathf.Abs (MoveD) < 3f){
				PlayerStop();
			}


		}

	}

	void PlayerStop(){
		Player.transform.position = MoveToTarget + FixedHeight;
		Global.PlayerMove = false;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Mission") {
			Global.MissionObj = other.gameObject;
		}
		if (other.gameObject.tag == "Moveable"){
			Box = other.gameObject;
			PushMoveableObj ();
		}
		if (other.gameObject.name == "Portal") {
			Global.PlayerMove = false;
			Player.transform.position = new Vector3(-9,6,7);
			Global.OnCubeNum = 2;

		}
		if (other.gameObject.name == "Portal2") {
			Global.PlayerMove = false;
			Player.transform.position = new Vector3(4, 5.5f, 4);
			Global.OnCubeNum = 1;
		}
		if (other.gameObject.layer == 10) {
			print ("Floor: " + other.gameObject.name);
			NowPos = other.gameObject.transform.position;
		}
		if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "EnemyWall") {
			Global.PlayerMove = false;
			Player.transform.position = NowPos + FixedHeight;
		}



	}

	void PushMoveableObj(){
		Box.transform.position += new Vector3 (PushX, PushY, PushZ);
		PushX = 0;
		PushZ = 0;
	}


	/*
	void StartMove(){

		MoveDir = MoveToTarget - Player.transform.position;
		TargetL = MoveToTarget.z;
		TargetR = MoveToTarget.x;
		Player.transform.position = Vector3.MoveTowards (Player.transform.position, MoveToTarget+new Vector3(TargetR,1,0), MoveSpeed*Time.deltaTime);
	}*/

}
