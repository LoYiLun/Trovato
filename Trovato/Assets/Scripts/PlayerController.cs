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
	Vector3 NowPos;
	Vector3 FixedHeight;

	// 推箱子
	GameObject Box;
	float PushX;
	float PushY;
	float PushZ;
	//private float MoveSpeed = 0.05f;

	private GameObject[] Obstacles;

	//float MoveSpeed = 1f;

	GameObject Portal;
	GameObject Portal2;
	bool PortalPower;

	void Awake(){
		
	}

	void Start () {
		Player = Global.Player;
		PlayerSetting();
		FixedHeight = new Vector3 (0, 0.8f, 0);


		//Obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");
	}
	

	void FixedUpdate () {
		Portal = GameObject.Find ("Portal");
		Portal2 = GameObject.Find ("Portal2");

		if (Portal.transform.position.y > 6 && Portal2.transform.position.y > 4) {
			PortalPower = true;
			Portal.GetComponent<Renderer> ().material = Resources.Load ("Materials/Yellow", typeof(Material)) as Material;
			Portal2.GetComponent<Renderer> ().material = Resources.Load ("Materials/Yellow", typeof(Material)) as Material;
		} else {
			PortalPower = false;
			Portal.GetComponent<Renderer> ().material = Resources.Load ("Materials/Gray", typeof(Material)) as Material;
			Portal2.GetComponent<Renderer> ().material = Resources.Load ("Materials/Gray", typeof(Material)) as Material;
		}

		if (Global.PlayerMove) {
			//Player.transform.position = Vector3.MoveTowards (transform.position, Global.NextTarget.transform.position, MoveSpeed * Time.deltaTime);
		}

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
					Player.transform.rotation = Quaternion.Euler (0, -90, 0);
					PushX = -1;
					PushZ = 0;
				} else if (MoveR < 0) {
					Player.transform.position += new Vector3 (0.1f, 0, 0);
					Player.transform.rotation = Quaternion.Euler (0, 90, 0);
					PushX = 1;
					PushZ = 0;
				}
			} else if (Mathf.Abs (MoveL) > 0.11f) {
				if (MoveL > 0) {
					Player.transform.position += new Vector3 (0, 0, -0.1f);
					Player.transform.rotation = Quaternion.Euler (0, 180, 0);
					PushZ = -1;
					PushX = 0;
				} else if (MoveL < 0) {
					Player.transform.position += new Vector3 (0, 0, 0.1f);
					Player.transform.rotation = Quaternion.Euler (0, 0, 0);
					PushZ = 1;
					PushX = 0;
				}
			} else if(Mathf.Abs (MoveD) < 3f){
				PlayerStop();
			}


		}


		/* 隱藏鏡頭前的建築
		for (int i = 0; i < Obstacles.Length; i++) {
			float Distance;
			Distance = Mathf.Abs (Obstacles [i].transform.position.x - Player.transform.position.x) + Mathf.Abs (Obstacles [i].transform.position.z - Player.transform.position.z) + Mathf.Abs (Obstacles [i].transform.position.y - Player.transform.position.y);

			if (((Obstacles [i].transform.position.x > Player.transform.position.x) || (Obstacles [i].transform.position.z > Player.transform.position.z))
				&& Distance <2) {
				//Obstacles [i].GetComponent<Renderer> ().material.color = new Color{a = 0.2f};
				//Obstacles [i].GetComponent<Renderer> ().material = Resources.Load ("Materials/Ghost", typeof(Material)) as Material;
			} else {
				//Obstacles [i].GetComponent<Renderer> ().material.color = new Color{a = 1f};
				//Obstacles [i].GetComponent<Renderer> ().material = Resources.Load ("Materials/Dark", typeof(Material)) as Material;
			}
		}*/

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

		if (other.gameObject.name == "Portal" && PortalPower) 
		{

			Global.PlayerMove = false;
			//Player.transform.position = new Vector3(-15, 5.4f, 4.5f);
			Player.transform.position = Portal2.transform.position + new Vector3(0,0.2f,0);
			Player.transform.rotation = Portal2.transform.rotation;
			Player.transform.Translate (0, 0, 1);
			Global.OnCubeNum = 2;

		}

		if (other.gameObject.name == "Portal2" && PortalPower) 
		{

			Global.PlayerMove = false;
			Player.transform.position = Portal.transform.position + new Vector3(0,0.2f,0);
			Player.transform.rotation = Portal.transform.rotation;
			Player.transform.Rotate (0, 90, 0);
			Player.transform.Translate (0, 0, 2);
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
		PushY = 0;
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
