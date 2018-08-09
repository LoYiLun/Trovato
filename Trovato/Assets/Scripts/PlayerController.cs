using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 MoveToTarget;
	private Vector3 MoveDir;

	// MoveL~MoveD為Player對於目的地的距離
	private float MoveL;
	private float MoveR;
	private float MoveD;
	private float TargetL;
	private float TargetR;
	GameObject Player;
	GameObject Portal;
	GameObject Portal2;
	Vector3 NowPos;
	Vector3 FixedHeight;

	// 推箱子
	GameObject Box;
	float PushX;
	float PushY;
	float PushZ;
	//private float MoveSpeed = 0.05f;

	void Start () {
		Player = Global.Player;
		PlayerSetting();
		FixedHeight = new Vector3 (0, 0.8f, 0);
		Portal = GameObject.Find ("Portal");
		Portal2 = GameObject.Find ("Portal2");
	}
	

	void FixedUpdate () {
		Player = Global.Player;
		MoveToTarget = Global.BeTouchedObj.transform.position;
		MoveL = -(MoveToTarget.z - Player.transform.position.z);
		MoveR = -(MoveToTarget.x - Player.transform.position.x);
		MoveD = -(MoveToTarget.y - Player.transform.position.y);

		// Player自動尋路功能
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

	void PlayerSetting(){
		Player.transform.position += FixedHeight;
	}

	void PlayerStop(){
		Player.transform.position = MoveToTarget + FixedHeight;
		if (Global.BeTouchedObj.tag == "Floor") 
		{
			Global.BeTouchedObj.GetComponent<Renderer> ().enabled = false;
		}
		Global.PlayerMove = false;
		Global.Status.text = "正常";
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Mission") 
		{
			Global.MissionObj = other.gameObject;
		}

		if (other.gameObject.tag == "Moveable")
		{
			Box = other.gameObject;
			PushMoveableObj ();
		}

		if (other.gameObject.name == "Portal") 
		{
			Global.PlayerMove = false;
			Player.transform.position = Portal2.transform.position + new Vector3(1, 0.2f, 0);
			//Player.transform.position = new Vector3(-9,6,7);
			Global.OnCubeNum = 2;

		}

		if (other.gameObject.name == "Portal2") 
		{
			Global.PlayerMove = false;
			Player.transform.position = Portal.transform.position + new Vector3(1, 0.2f, 0);
			//Player.transform.position = new Vector3(4, 5.5f, 4);
			Global.OnCubeNum = 1;
		}

		if (other.gameObject.layer == 10) 
		{
			NowPos = other.gameObject.transform.position;
		}

		// EnemyWall為敵人巡邏的折返牆
		if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "EnemyWall") 
		{
			Global.PlayerMove = false;
			if(Global.BeTouchedObj.tag == "Floor")
				Global.BeTouchedObj.GetComponent<Renderer> ().enabled = false;
			Player.transform.position = NowPos + new Vector3(0, 0.9f, 0);
			Global.Status.text = "正常";
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
