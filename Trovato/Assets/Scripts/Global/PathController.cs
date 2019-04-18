using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {

	private Ray ray;
	private Ray FourRay;
	private Ray FourRay2;
	public RaycastHit hitinfo;
	private RaycastHit Fourinfo;
	private RaycastHit Fourinfo2;
	public GameObject BeTouchedFloor;
	public GameObject NeighborFloor;
	public bool Obstacle;
	private Vector3[] Directions = new Vector3[4];

	private bool NotInOpenlist = true;
	private bool NotInCloselist = true;

	[System.Serializable]
	public struct Floor
	{
		public int index;
		public GameObject Object;
		public float G_cost;
		public float H_cost;
		public float F_cost;
		public GameObject Dad;
		public Vector3 ToDad;
	}

	private Floor Startfloor;
	private Floor Dadfloor;
	private Floor floor;
	public List<Floor> Openlist = new List<Floor>();
	public List<Floor> Closelist = new List<Floor>();
	public List<Floor> Pathlist = new List<Floor> ();
	private GameObject[] AllFloors = new GameObject[144];

	private float MinF;
	private Floor NextHost;
	private int floorindex;

	private bool SearchMode;
	public static bool FollowPath;

	//private bool PlayerMove;
	private int tempt;

	GameObject TemptFloorA;
	GameObject TemptFloorB;
	public GameObject FloorA;
	public GameObject FloorB;
	public float dis;
	public Vector3 WalkDir;
	public Quaternion FaceRotation;


	Vector3 fix = new Vector3(0, 1, 0);
	float AngleX;
	float AngleY;
	float AngleZ;

	Vector3 fixB;
	float AngleXB;
	float AngleYB;
	float AngleZB;

	Animation anim;
	bool ChangeGoal;
	GameObject Origin;

	public GameObject NeighborCollider;
	public LayerMask Floorlayer;

	private Ray Nray;
	private RaycastHit Ninfo;
	float StunTime;

	private float walkSpeed;
	private bool isWalkingOrder;

	/*
	public GameObject trueHead;
	public GameObject walkingHead;
	private GameObject nextTwoFloor;
	private GameObject headFloor;
	private GameObject targetFloor;
	private Quaternion headRotation;
	private bool setHeadFloor;*/

	void Start () {
		FourRay = new Ray(Vector3.zero, Vector3.zero);
		FourRay2 = new Ray(Vector3.zero, Vector3.zero);
		Directions [0] = Vector3.forward;
		Directions [1] = Vector3.right;
		Directions [2] = Vector3.back;
		Directions [3] = Vector3.left;
		anim = GameObject.Find ("Player_Body").GetComponent<Animation> ();
		BeTouchedFloor = null;
		NotInOpenlist = true;
		NotInCloselist = true;
		//PlayerMove = false;
		ChangeGoal = false;
		Origin = null;
		floorindex = 0;
		tempt = 0;
		dis = 0;
		MinF = 0;
		StunTime = 0;
	}
	void Stopanim(){
		anim.Rewind ();
		anim.Play ();
		anim.Sample ();
		anim.Stop ();
	}

	/*
	public void setHeadRotation(){
		if (FaceRotation.y == 0 && targetFloor.transform.position.x > walkingHead.transform.position.x) {
			headRotation = Quaternion.Euler (-90, 90, 90);
		}

		if (FaceRotation.y == 0 && targetFloor.transform.position.x < walkingHead.transform.position.x) {
			headRotation = Quaternion.Euler (-90, -90, 90);
		}

		if (FaceRotation.y == 90 && targetFloor.transform.position.z > walkingHead.transform.position.z) {
			headRotation = Quaternion.Euler (-90, 0, 90);
		}

		if (FaceRotation.y == 90 && targetFloor.transform.position.z < walkingHead.transform.position.z) {
			headRotation = Quaternion.Euler (-90, 180, 90);
		}

		if (FaceRotation.y == 180 && targetFloor.transform.position.x > walkingHead.transform.position.x) {
			headRotation = Quaternion.Euler (-90, 90, 90);
		}

		if (FaceRotation.y == 180 && targetFloor.transform.position.x < walkingHead.transform.position.x) {
			headRotation = Quaternion.Euler (-90, -90, 90);
		}

		if (FaceRotation.y == -90 && targetFloor.transform.position.z > walkingHead.transform.position.z) {
			headRotation = Quaternion.Euler (-90, 0, 90);
		}

		if (FaceRotation.y == -90 && targetFloor.transform.position.z < walkingHead.transform.position.z) {
			headRotation = Quaternion.Euler (-90, 180, 90);
		}
	}*/

	void FixedUpdate(){
		// 主角尋路系統
		if (FollowPath && Closelist.Count <= AllFloors.Length && !Global.IsPushing && !Global.IsPreRotating) {
			Global.PlayerMove = true;

			//dis = Vector3.Distance (Global.Player.transform.position, FloorB.transform.position + fix);
			if ((FloorA != null) && (FloorB != null)) {
				dis = Mathf.Abs (Global.Player.transform.position.x - FloorB.transform.position.x) +
					Mathf.Abs (Global.Player.transform.position.z - FloorB.transform.position.z);
				
				anim.Play ("Walk");
				if (FloorB != BeTouchedFloor) {
					walkSpeed = Mathf.Clamp (walkSpeed + 0.2f, 0.5f, 3);
					anim ["Walk"].speed = walkSpeed / 3;
				} else {
					walkSpeed = Mathf.Clamp (walkSpeed - 0.1f, 2f, 3);
					anim ["Walk"].speed = walkSpeed / 3;
				}
					
				Global.Player.GetComponent<PlayerController> ().LockRotation = false;
				Global.Player.transform.position += (FloorB.transform.position - FloorA.transform.position + new Vector3 (0, 0.45f, 0)) * walkSpeed * Time.deltaTime;
				//Global.Player.transform.position += (FloorB.transform.position - FloorA.transform.position + new Vector3 (0, 0.45f, 0)) * 3 * Time.deltaTime;



			//print("dis: " + dis);
			}else if((FloorA == null) && (FloorB == null)){
				// 防止原地走動
				Stopanim ();
				FollowPath = false;

			}



			if (dis <= 0.1f) {

				// 角色走到終點
				if (PlayerController.CurrentFloor == BeTouchedFloor) {
					PlayerController.CancelMoving (BeTouchedFloor.transform.position);
					foreach (GameObject color in AllFloors) {
						if(Global.Level != "Astar")
							color.GetComponent<Renderer> ().enabled = false;
						if(Global.Level == "Astar")
							color.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/Gray2") as Material;
					}
					//Global.Player.transform.position = PlayerController.CurrentFloor.transform.position + fix;
					Stopanim ();
					isWalkingOrder = false;
					walkSpeed = 0;
					anim ["Walk"].speed = 1;
					FollowPath = false;
					Global.PlayerMove = false;
				}
				Global.Player.transform.position = PlayerController.CurrentFloor.transform.position + fix;
				if (!ChangeGoal) {
					FloorA = FloorB;
					FloorB = Pathlist.Find ((x) => x.Dad != null && x.Dad == PlayerController.CurrentFloor).Object;
					if (FloorA != null)
						FloorA.GetComponent<Renderer> ().material = Resources.Load ("Materials/Dark") as Material;
				} else {
					ChangeGoal = false;
					FloorA = TemptFloorA;
					FloorB = TemptFloorB;
					if (FloorA != null)
						FloorA.GetComponent<Renderer> ().material = Resources.Load ("Materials/Dark") as Material;
				}
			} else if (dis >= 2) {
				PlayerController.CancelMoving (PlayerController.CurrentFloor.transform.position + fix);
				Stopanim ();
				FollowPath = false;
				FloorA = FloorB = null;
				Global.PlayerMove = false;
			}

			/*
				if (Vector3.Distance (Global.Player.transform.position, Pathlist.Find ((x) => x.Dad != null && x.Dad == NeighborFloor).Object.transform.position + new Vector3 (0, 0.5f, 0)) <= 0.1f) {
					Global.Player.transform.position = CurrentFloor.transform.position + new Vector3 (0, 0.5f, 0);
					NeighborFloor = PlayerController.CurrentFloor;
					if (PlayerController.CurrentFloor == BeTouchedFloor) {
						if (Global.IsPushing) {
							GameObject.Find ("Player_Body").GetComponent<Animation> ().Play ("Push_And_Stand");
						} else {
						
							//print ("Finish Walking!!");
							BeTouchedFloor.GetComponent<Renderer>().enabled = false;
							Global.PlayerMove = false;
							FollowPath = false;
						}
					}
				}
			*/
		}

		// 主角自轉系統：設定方向
		if (FollowPath && Closelist.Count <= AllFloors.Length && FloorA != null && FloorB != null) {
			WalkDir = FloorA.transform.position - FloorB.transform.position;
			if (WalkDir.x > 0 && Mathf.Abs(WalkDir.z) <= 0.2f)
				FaceRotation = Quaternion.Euler (0, -90, 0);
			if (WalkDir.x < 0 && Mathf.Abs(WalkDir.z) <= 0.2f)
				FaceRotation = Quaternion.Euler (0, 90, 0);
			if (WalkDir.z > 0 && Mathf.Abs(WalkDir.x) <= 0.2f)
				FaceRotation = Quaternion.Euler (0, 180, 0);
			if (WalkDir.z < 0 && Mathf.Abs(WalkDir.x) <= 0.2f)
				FaceRotation = Quaternion.Euler (0, 0, 0);
		}

		// 主角自轉系統：開始自轉
		if (Global.Player != null && !Global.IsPreRotating && !Global.IsPushing && !Global.Player.GetComponent<PlayerController>().LockRotation) {
			Global.Player.transform.rotation = Quaternion.Lerp (Global.Player.transform.rotation, FaceRotation, 0.2f);
			if (Quaternion.Angle (Global.Player.transform.rotation, FaceRotation) < 10) {
				Global.Player.transform.rotation = FaceRotation;
			}
		}
	}

	IEnumerator DelayTouch(){
		Global.StopTouch = true;
		yield return new WaitForSeconds (0.2f);
		if (GameObject.Find ("GlobalScripts").GetComponent<MissionSetting> () != null && !MissionSetting.BlockOn) {
			Global.StopTouch = false;
		}

		yield break;
	}

	void Update () {

		if ((FloorA == FloorB) && (FloorA != null) && (FloorB != null)) {
			StunTime += 0.01f;
			if (StunTime > 0.05f) {
				
				FollowPath = false;
				//FloorB = PlayerController.CurrentFloor;
				PlayerController.CancelMoving (PlayerController.CurrentFloor.transform.position + fix);
				FloorA = FloorB = null;
				Stopanim ();
				StunTime = 0;
			}
		} else {
			StunTime = 0;
		}

		//print (PlayerController.CurrentFloor.transform.rotation.eulerAngles);

		/*
		if (PlayerController.CurrentFloor != null) {
			AngleX = Mathf.Sin (PlayerController.CurrentFloor.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
			AngleY = Mathf.Cos (PlayerController.CurrentFloor.transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
			AngleZ = Mathf.Sin (PlayerController.CurrentFloor.transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
			fix = new Vector3 (AngleX, AngleY, AngleZ);
			//print ("fix: " + fix);
		}*/

		/*
		if (FloorB != null) {
			AngleXB = Mathf.Sin (FloorB.transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
			AngleYB = Mathf.Cos (FloorB.transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
			AngleZB = Mathf.Sin (FloorB.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
			fixB = new Vector3 (0, 0, AngleZB);
			print ("fixB: " + fixB);
		}*/
			
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		// FoolWalk Mode
		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hitinfo, 500, 1 << 10) && !Global.StopTouch && CameraController.IsCamRotating != true && !Global.IsRotating && !Global.IsPreRotating && !MissionSetting.CamIsMoving && !MissionSetting.CamIsMovingBack) 
		{
			// 切換成新點選的物件
			Global.BeTouchedObj = hitinfo.collider.gameObject;
			if(Global.Level != "Astar")
				Global.BeTouchedObj.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/touch2") as Material;
			if (Global.Player != null && Global.IsPushing) {
				Global.PlayerMove = true;
			}
		} 

		// SmartWalk Mode
		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hitinfo, 500, 1 << 10) && !Global.IsPreRotating && !Global.StopTouch && !CameraController.IsCamRotating) {
			// 如果不是第一次點地板
			if (BeTouchedFloor != null) {
				if(Global.Level != "Astar")
					BeTouchedFloor.GetComponent<Renderer> ().enabled = false;
				if(Global.Level == "Astar")
					BeTouchedFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/Gray2") as Material;
			}
			BeTouchedFloor = hitinfo.collider.gameObject;
			Reset ();

			if (FollowPath)
				ChangeGoal = true;
			if (BeTouchedFloor != PlayerController.CurrentFloor) {
				SearchMode = true;
				CheckNeighbor ();
			}
			StartCoroutine (DelayTouch ());
		}
	}
		

	public void Reset(){

		NotInOpenlist = true;
		NotInCloselist = true;
		//FollowPath = false;
		//PlayerMove = false;
		ChangeGoal = false;
		//TemptFloorA = null;
		//TemptFloorB = null;
		//FloorA = null;
		//FloorB = null;
		Origin = null;
		floorindex = 0;
		tempt = 0;
		dis = 0;
		MinF = 0;
		StunTime = 0;

		//---------------------


		//if(Global.Level == "Astar")
		//BeTouchedFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Blue") as Material;

		NeighborFloor = null;
		AllFloors = GameObject.FindGameObjectsWithTag("Floor");
		foreach(GameObject color in AllFloors){
			
			// 顯示全地板
			if(Global.Level == "Astar"){
			color.GetComponent<Renderer> ().enabled = true;
			color.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/Gray2") as Material;
			}
		}
		//Global.Player.transform.position = PlayerController.CurrentFloor.transform.position + fix;


		Pathlist.Clear ();
		Openlist.Clear();
		Closelist.Clear();

		// 初始化起點
		Startfloor.index = 0;
		Startfloor.Object = PlayerController.CurrentFloor;
		Startfloor.G_cost = 0;
		Startfloor.H_cost = 
			Mathf.Abs (PlayerController.CurrentFloor.transform.position.x - BeTouchedFloor.transform.position.x) +
			Mathf.Abs (PlayerController.CurrentFloor.transform.position.z - BeTouchedFloor.transform.position.z);
		Startfloor.F_cost = Startfloor.G_cost + Startfloor.H_cost;
		Startfloor.Dad = null;
		Startfloor.ToDad = Vector3.zero;
		// 起點加入Openlist
		Openlist.Add (Startfloor);
	}

	private void CheckNeighbor(){

		// 封路數量大於地板數量，表示無路可走
		if (Closelist.Count > AllFloors.Length) {
			SearchMode = false;
			Stopanim ();
			FollowPath = false;
			Global.PlayerMove = false;
			Global.Player.transform.position = PlayerController.CurrentFloor.transform.position + fix;

			if(Global.Level != "Astar")
			BeTouchedFloor.GetComponent<Renderer> ().enabled = false;

			print("<color=red>No way!!</color>");
		}

		if(SearchMode && !Global.IsPushing){

		for(int i=0 ; i<4 ; i++){
				/*Directions [0] = Startfloor.Object.transform.forward;
				Directions [1] = Startfloor.Object.transform.right;
				Directions [2] = Startfloor.Object.transform.forward * -1;
				Directions [3] = Startfloor.Object.transform.right * -1;*/
				FourRay.origin = Startfloor.Object.transform.position;
				FourRay.direction = Directions [i];
				FourRay2.origin = Startfloor.Object.transform.position + Directions[i] + new Vector3(0, 2f, 0);
				FourRay2.direction = Vector3.down;
				//FourRay.origin = Startfloor.Object.transform.position + Directions[i] + new Vector3(0,1,0);
				//FourRay.direction = Vector3.down;
				//Nray.origin = NeighborCollider.transform.position;
				//Nray.direction = Vector3.down;


				//NeighborCollider.transform.position = Startfloor.Object.transform.position + Directions [i] + new Vector3(0,3,0);

				// 訪問鄰居
				/*if(Physics.Raycast (Nray, out Ninfo, 5, 1 << 10)){
					if (Ninfo.collider.gameObject != null) {
						NeighborFloor = Ninfo.collider.gameObject;
						print ("n " + NeighborFloor.name);
						Obstacle = NeighborFloor.GetComponent<Floorinfos> ().Obstacle;
				}*/
					// 下括弧在下方



				if (Physics.Raycast (FourRay2, out Fourinfo2, 3, 1 << 10)) {
					if (Fourinfo2.collider.gameObject != null) {
						if (Fourinfo2.collider.gameObject.GetComponent<Floorinfos> ().UpFloor != null) {
							NeighborFloor = Fourinfo2.collider.gameObject.GetComponent<Floorinfos> ().UpFloor;
							Obstacle = NeighborFloor.GetComponent<Floorinfos> ().Obstacle;
						} else {
							NeighborFloor = Fourinfo2.collider.gameObject;
							Obstacle = NeighborFloor.GetComponent<Floorinfos> ().Obstacle;
						}


					}

					for(int j=0 ; j < 4 ; j++){
						FourRay.origin = Startfloor.Object.transform.position;
						FourRay.direction = Directions [i];
						if (Physics.Raycast (FourRay, out Fourinfo, 1, 1 << 21)) {
							NeighborFloor = null;
						}	
					}


				
					if(NeighborFloor != null && (!Obstacle || NeighborFloor == BeTouchedFloor)){
					// 鄰居是否在Openlist
					foreach (Floor floors in Openlist) {
						if (floors.Object == NeighborFloor) {
							NotInOpenlist = false;
							if (Startfloor.G_cost + 
								Mathf.Abs (NeighborFloor.transform.position.x - Startfloor.Object.transform.position.x) +
								Mathf.Abs (NeighborFloor.transform.position.z - Startfloor.Object.transform.position.z) < floors.G_cost){

									floorindex = Openlist.IndexOf (floors);
									//floor.index = floors.index;
									floor.Object = floors.Object;
									floor.G_cost = 
										Startfloor.G_cost +
										Mathf.Abs (NeighborFloor.transform.position.x - Startfloor.Object.transform.position.x) +
										Mathf.Abs (NeighborFloor.transform.position.z - Startfloor.Object.transform.position.z);
									floor.F_cost = floor.G_cost + floors.H_cost;
									floor.Dad = Startfloor.Object;
									floor.ToDad = Startfloor.Object.transform.position - floor.Object.transform.position;



							}
						}
					}
						if (!NotInOpenlist && floorindex >= 0) {
							Openlist.RemoveAt (floorindex);
							Openlist.Insert (floorindex, floor);
						}

					// 鄰居是否在Closelist
					foreach (Floor floors in Closelist) {
						if (floors.Object == NeighborFloor) {
							NotInCloselist = false;
								if (Startfloor.G_cost + 
									Mathf.Abs (NeighborFloor.transform.position.x - Startfloor.Object.transform.position.x) +
									Mathf.Abs (NeighborFloor.transform.position.z - Startfloor.Object.transform.position.z) < floors.G_cost){

									floorindex = Closelist.IndexOf (floors);
									//floor.index = floors.index;
									floor.Object = floors.Object;
									floor.G_cost = 
										Startfloor.G_cost +
										Mathf.Abs (NeighborFloor.transform.position.x - Startfloor.Object.transform.position.x) +
										Mathf.Abs (NeighborFloor.transform.position.z - Startfloor.Object.transform.position.z);
									floor.F_cost = floor.G_cost + floors.H_cost;
									floor.Dad = Startfloor.Object;
									floor.ToDad = Startfloor.Object.transform.position - floor.Object.transform.position;



								}
						}
					}
						if (!NotInCloselist && floorindex >= 0) {
							Closelist.RemoveAt (floorindex);
							Closelist.Insert (floorindex, floor);
						}

					// 給予基本資料
						if (NotInOpenlist && NotInCloselist) {

							//floor.index = Openlist.Count;
							floor.Object = NeighborFloor;

							floor.G_cost = 
							Mathf.Abs (NeighborFloor.transform.position.x - Startfloor.Object.transform.position.x) +
							Mathf.Abs (NeighborFloor.transform.position.z - Startfloor.Object.transform.position.z) +
							Startfloor.G_cost;
							
							floor.H_cost = 
							Mathf.Abs (NeighborFloor.transform.position.x - BeTouchedFloor.transform.position.x) +
							Mathf.Abs (NeighborFloor.transform.position.z - BeTouchedFloor.transform.position.z);
							floor.F_cost = floor.G_cost + floor.H_cost;
							floor.Dad = Startfloor.Object;
							floor.ToDad = Startfloor.Object.transform.position - floor.Object.transform.position;

							// 調查完畢後加入Openlist
							Openlist.Add (floor);

							if(Global.Level == "Astar")
							NeighborFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Global/Green") as Material;

						}
						floorindex = -1;
					NotInOpenlist = true;
					NotInCloselist = true;

				}
			}


		}

		// 結束調查鄰居
		if(Closelist.Count == 0)
			Origin = PlayerController.CurrentFloor;
		Openlist.Remove(Startfloor);
		Closelist.Add (Startfloor);

		// 起點
		Startfloor.Object.GetComponent<Renderer> ().material = Resources.Load ("Materials/Dark") as Material;

			if (Closelist.Contains(Startfloor)){
				MinF = 10000;
			} else {
				MinF = Startfloor.F_cost;
			}

		if(!isWalkingOrder)
			BeTouchedFloor.GetComponent<Renderer> ().enabled = true;
		if(Global.Level == "Astar")
			BeTouchedFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Yellow") as Material;


		foreach (Floor neighbor in Openlist) {
			if (neighbor.F_cost <= MinF) {
				MinF = neighbor.F_cost;
				NextHost = neighbor;
			}
			if (neighbor.H_cost == 0) {
					MinF = neighbor.F_cost;
					NextHost = neighbor;	
				//print ("Finish Searching!");
				SearchMode = false;
					PathSetting ();
			}
		}

			//Startfloor.index = NextHost.index;
			if(NextHost.Object == null)
				print("No Next");
			Startfloor.Object = NextHost.Object;
			Startfloor.G_cost = NextHost.G_cost;
			Startfloor.H_cost = NextHost.H_cost;
			Startfloor.F_cost = NextHost.F_cost;
			Startfloor.Dad = NextHost.Dad;
			Startfloor.ToDad = NextHost.ToDad;
			if(SearchMode)
			CheckNeighbor ();
		}
	}

	private void PathSetting(){
		tempt = Closelist.Count;
		Pathlist.Add (NextHost);
		//Dadfloor.index = NextHost.index;
		Dadfloor.Object = NextHost.Object;
		Dadfloor.G_cost = NextHost.G_cost;
		Dadfloor.H_cost = NextHost.H_cost;
		Dadfloor.F_cost = NextHost.F_cost;
		Dadfloor.ToDad = NextHost.ToDad;
		Dadfloor.Dad = NextHost.Dad;
		//Pathlist.Add (NextHost.Dad);
		for (int i = 0; i < tempt; i++) {


			foreach (Floor f in Closelist) {
				if (Dadfloor.Dad != null && Dadfloor.Dad == f.Object) {

					floorindex = Closelist.IndexOf (f);
					Dadfloor.index = Pathlist.Count;
					Dadfloor.Object = f.Object;
					Dadfloor.G_cost = f.G_cost;
					Dadfloor.H_cost = f.H_cost;
					Dadfloor.F_cost = f.F_cost;
					Dadfloor.ToDad = f.ToDad;
					Dadfloor.Dad = f.Dad;

				}
			}
			if (Closelist.Count >= floorindex && Dadfloor.Object != PlayerController.CurrentFloor) {
				Closelist.RemoveAt (floorindex);
				Pathlist.Add (Dadfloor);

				// 最短路徑
				if (Global.Level == "Astar") {
					Dadfloor.Object.GetComponent<Renderer> ().enabled = true;
					Dadfloor.Object.GetComponent<Renderer> ().material = Resources.Load ("Materials/Yellow") as Material;
				}
			}
		}
		NeighborFloor = PlayerController.CurrentFloor;
		if (!ChangeGoal) {
			FloorA = PlayerController.CurrentFloor;
			FloorB = Pathlist.Find ((x) => x.index == Pathlist.Count - 1).Object;
		} else if (!Pathlist.Contains(Pathlist.Find ((k) => k.Object == FloorB))) {
			TemptFloorA = FloorB;
			TemptFloorB = Origin;
		} else {
			TemptFloorA = FloorA;
			TemptFloorB = FloorB;
		}
		FollowPath = true;

	}

	public void WalkOrder(string FloorName){
		isWalkingOrder = true;

		BeTouchedFloor = GameObject.Find (FloorName);
		Reset ();

		if (FollowPath)
			ChangeGoal = true;
		if (BeTouchedFloor != PlayerController.CurrentFloor) {
			SearchMode = true;
			CheckNeighbor ();
		}
		StartCoroutine (DelayTouch ());
	}
}