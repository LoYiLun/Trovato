using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 MoveToTarget;
	private Vector3 MoveDir;

	// MoveL~MoveD為Player相對於目的地的距離
	private float MoveL;
	private float MoveR;
	private float MoveD;
	private float TargetL;
	private float TargetR;
	GameObject Player;
	Vector3 StartPos;
	Vector3 FixedHeight;

	private GameObject[] Obstacles;

	float MoveSpeed = 5f;
	float RotateSpeed = 0.25f;
	Quaternion RotateDir;

	GameObject Portal;
	GameObject Portal2;
	bool PortalPower;

	bool LockDirR = false;
	bool LockDirL = false;
	bool LockRotation;
	string MovingDir;

	Ray DownRay;
	RaycastHit hitinfo;
	public static GameObject CurrentFloor;

	float D;

	void Awake(){

	}

	void Start () {
		Player = Global.Player;
		PlayerSetting();
		FixedHeight = new Vector3 (0, 1f, 0);



		//Obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");
	}


	void FixedUpdate () {
		



			DownRay = new Ray (Global.Player.transform.position, Vector3.down);
			if (Physics.Raycast (DownRay, out hitinfo, 5, 1 << 10)) {
				CurrentFloor = hitinfo.collider.gameObject;

		}

		// 設定有無傳送門
		if (Global.Level == "1") {
		
		} else if(Global.Level == "2") {
			if (Vector3.Distance (GameObject.Find ("Wing1").transform.position, GameObject.Find ("BattleShip").transform.position) < 2.5f) {
				GameObject.Find ("iBlockDoor1").GetComponent<Collider> ().enabled = false;
				GameObject.Find ("iBlockDoor2").GetComponent<Collider> ().enabled = false;
			} else {
				GameObject.Find ("iBlockDoor1").GetComponent<Collider> ().enabled = true;
				GameObject.Find ("iBlockDoor2").GetComponent<Collider> ().enabled = true;
			}


		} else if(Global.Level == "3") {
			Portal = GameObject.Find ("Event_Portal(Clone)").transform.GetChild(0).gameObject;
			Portal2 = GameObject.Find ("Event_Portal2(Clone)").transform.GetChild(0).gameObject;

			if (Portal.transform.position.y > 6 && Portal2.transform.position.y > 4) {
				PortalPower = true;
				Portal.GetComponent<Renderer> ().material = Resources.Load ("Materials/Yellow", typeof(Material)) as Material;
				Portal2.GetComponent<Renderer> ().material = Resources.Load ("Materials/Yellow", typeof(Material)) as Material;
			} else {
				PortalPower = false;
				Portal.GetComponent<Renderer> ().material = Resources.Load ("Materials/Gray", typeof(Material)) as Material;
				Portal2.GetComponent<Renderer> ().material = Resources.Load ("Materials/Gray", typeof(Material)) as Material;
			}

			if (Vector3.Distance (GameObject.Find ("Platform").transform.position, GameObject.Find ("Platform2").transform.position) < 3) {
				GameObject.Find ("iBlockDoor1").GetComponent<Collider> ().enabled = false;
				GameObject.Find ("iBlockDoor2").GetComponent<Collider> ().enabled = false;
			} else {
				GameObject.Find ("iBlockDoor1").GetComponent<Collider> ().enabled = true;
				GameObject.Find ("iBlockDoor2").GetComponent<Collider> ().enabled = true;
			}

			// 傳送失敗時強制傳送
			if (Global.OnCubeNum == 2 && CurrentFloor.transform.parent != GameObject.Find ("Floor_Origin_V2").transform) {
				CancelMoving (Portal2.transform.position + new Vector3 (0, 0.2f, 0));
				Player.transform.rotation = RotateDir = Portal2.transform.rotation;
				Player.transform.Translate (0, 0, 1);
				CameraController.SetCamPos = true;
			}
		}

		// 計算至目標的距離
		Player = Global.Player;

		if (Global.BeTouchedObj != null) {
			MoveToTarget = Global.BeTouchedObj.transform.position;
			MoveL = -(MoveToTarget.z - Player.transform.position.z);
			MoveR = -(MoveToTarget.x - Player.transform.position.x);
			MoveD = -(MoveToTarget.y - Player.transform.position.y);
		}


		// Player陽春版自動尋路功能

		// 推箱子時角色不轉動方向
		if (LockRotation == false && Global.IsPushing != true) {
			transform.rotation = Quaternion.Lerp (transform.rotation, RotateDir, RotateSpeed);
			if (Quaternion.Angle (Player.transform.rotation, RotateDir) < 10) {
				transform.rotation = RotateDir;
			}
				
		}

		if (Global.IsRotating)
			LockRotation = true;

		if (Global.IsPushing == false) {
			LockDirR = LockDirL = false;
		}

		// 取消推箱子模式
		if(Input.GetMouseButtonUp(1) && Global.IsPushing && Global.PlayerMove == false && Global.BePushedObj != null){
			LockDirR = LockDirL = false;
			Global.BePushedObj.GetComponent<Renderer> ().material = Resources.Load ("Materials/White")as Material;
			Global.BePushedObj.transform.parent = GameObject.Find ("MoveableGroup").transform;
			Global.BePushedObj = null;
			PlayerController.CancelMoving (new Vector3(CurrentFloor.transform.position.x, transform.position.y, CurrentFloor.transform.position.z));
			Global.IsPushing = false;
		}

		if (Global.PlayerMove && Global.IsRotating == false) {

			LockRotation = false;
			if(Global.Wait && Global.IsPushing == false){
				Player.transform.position = new Vector3(CurrentFloor.transform.position.x, transform.position.y, CurrentFloor.transform.position.z);
				Global.Wait = false;
			}
			if (Mathf.Abs (MoveR) > 0.05f && LockDirR == false) {
				if (MoveR > 0) {
					Player.transform.position += new Vector3 (-MoveSpeed * Time.deltaTime, 0, 0);
					RotateDir = Quaternion.Euler (0, -90, 0);

				} else if (MoveR < 0) {
					Player.transform.position += new Vector3 (MoveSpeed * Time.deltaTime, 0, 0);
					RotateDir = Quaternion.Euler (0, 90, 0);

				}
			} else if (Mathf.Abs (MoveL) > 0.05f && LockDirL == false) {
				if (MoveL > 0) {
					Player.transform.position += new Vector3 (0, 0, -MoveSpeed * Time.deltaTime);
					RotateDir = Quaternion.Euler (0, 180, 0);

				} else if (MoveL < 0) {
					Player.transform.position += new Vector3 (0, 0, MoveSpeed * Time.deltaTime);
					RotateDir = Quaternion.Euler (0, 0, 0);

				}
			} else if(Mathf.Abs (MoveD) < 3f){
				if (Global.IsPushing) {
					CancelMoving (new Vector3(CurrentFloor.transform.position.x, transform.position.y, CurrentFloor.transform.position.z));
				} else {
					LockDirR = LockDirL = false;
					PlayerStop ();
				}
			}
		}



	}

	void PlayerSetting(){
		Player.transform.position += FixedHeight;
	}

	void PlayerStop(){
		CancelMoving (new Vector3(MoveToTarget.x, transform.position.y, MoveToTarget.z));
	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Mission") 
		{
			Global.MissionObj = other.gameObject;
		}

		if (other.gameObject.tag == "Moveable")
		{
			if (Global.BePushedObj == null) {
				CancelMoving (new Vector3(CurrentFloor.transform.position.x, transform.position.y, CurrentFloor.transform.position.z));
				Global.BePushedObj = other.gameObject;
				Global.BePushedObj.GetComponent<Renderer> ().material = Resources.Load ("Materials/Blue")as Material;
				Global.IsPushing = true;
				transform.rotation = RotateDir;
				Global.BePushedObj.transform.parent = Player.transform;
				if (RotateDir == Quaternion.Euler (0, 0, 0) || RotateDir == Quaternion.Euler (0, 180, 0)) {
					LockDirR = true;
					LockDirL = false;
				} else if (RotateDir == Quaternion.Euler (0, 90, 0) || RotateDir == Quaternion.Euler (0, -90, 0)) {
					LockDirR = false;
					LockDirL = true;
				}
			} else {
				CancelMoving (new Vector3(CurrentFloor.transform.position.x, transform.position.y, CurrentFloor.transform.position.z));

			}


		}




		// EnemyWall為敵人巡邏的折返牆
		if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "EnemyWall") 
		{
			CancelMoving (new Vector3(CurrentFloor.transform.position.x, transform.position.y, CurrentFloor.transform.position.z));
		}


	}

	void OnCollisionStay(Collision other){
		if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "EnemyWall") 
		{
			CancelMoving (new Vector3(CurrentFloor.transform.position.x, transform.position.y, CurrentFloor.transform.position.z));
		}

		if (other.gameObject.tag == "Moveable") {
			if (Global.BePushedObj != null) {
				CancelMoving (new Vector3 (CurrentFloor.transform.position.x, transform.position.y, CurrentFloor.transform.position.z));
			}
		}
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.name == "Portal" && PortalPower) 
		{
			Component[] colliders;
			colliders = GameObject.Find ("Platform2").GetComponentsInChildren<Collider> ();
			foreach (Collider c in colliders)
				c.enabled = false;

			CancelMoving (Portal2.transform.position + new Vector3 (0, 0.2f, 0));
			Global.Targetlight.Stop ();
			//Player.transform.position = Portal2.transform.position + new Vector3(0,0.2f,0);
			Player.transform.rotation = RotateDir = Portal2.transform.rotation;
			Player.transform.Translate (0, 0, 1);
			CameraController.SetCamPos = true;
			Global.OnCubeNum = 2;

		}

		if (other.gameObject.name == "Portal2" && PortalPower) 
		{
			Component[] colliders;
			colliders = GameObject.Find ("Platform2").GetComponentsInChildren<Collider> ();
			foreach (Collider c in colliders)
				c.enabled = true;

			CancelMoving (Portal.transform.position + new Vector3 (0, 0.2f, 0));
			Global.Targetlight.Stop ();
			//Player.transform.position = Portal.transform.position + new Vector3(0,0.2f,0);
			Player.transform.rotation = RotateDir = Portal.transform.rotation * Quaternion.Euler(0,90,0);
			Player.transform.Translate (0, 0, 2);
			CameraController.SetCamPos = true;

			Global.OnCubeNum = 1;
		}

		// 進入太空站前準備
		if (other.gameObject.name == "sBlock") {

			GameObject.Find("Station_Bigroom").GetComponent<Renderer> ().material = Resources.Load("Materials/Ghost") as Material;
			GameObject.Find("Station_Radar").GetComponent<Renderer> ().material = Resources.Load("Materials/Ghost") as Material;

			/*
			Component[] stationRenderer;
			stationRenderer = GameObject.Find ("Station").GetComponentsInChildren<Renderer> ();
			foreach (Renderer skin in stationRenderer) {
				skin.material = Resources.Load ("Materials/Ghost")as Material;
			}*/
		}

		if (other.gameObject.name == "Enemy") {
			Global.IsPushing = false;
			Global.Retry ();
		}
	}

	void OnTriggerExit(Collider other){

		if (other.gameObject.name == "sBlock") {
			GameObject.Find("Station_Bigroom").GetComponent<Renderer> ().material = Resources.Load("Materials/Level_02/Materials/SSS-2") as Material;
			GameObject.Find("Station_Radar").GetComponent<Renderer> ().material = Resources.Load("Materials/Level_02/Materials/SSS-1") as Material;

			/*
			Component[] stationRenderer;
			stationRenderer = GameObject.Find ("Station").GetComponentsInChildren<Renderer> ();
			foreach (Renderer skin in stationRenderer) {
				skin.material = Resources.Load ("Materials/Red")as Material;
			}*/
		}
	}


	public static void CancelMoving(Vector3 NewPosition){
		Global.Player.transform.position = NewPosition;
		Global.PlayerMove = false;
		if(Global.BeTouchedObj != null && Global.BeTouchedObj.tag == "Floor")
			Global.BeTouchedObj.GetComponent<Renderer> ().enabled = false;
		Global.Targetlight.Stop ();
	}


}
