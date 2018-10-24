using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {

	private Ray ray;
	private Ray FourRay;
	private RaycastHit hitinfo;
	private RaycastHit Fourinfo;
	private GameObject BeTouchedFloor;
	private GameObject NeighborFloor;
	private bool Obstacle;
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
	private GameObject[] AllFloors = new GameObject[100];

	private float MinF;
	private Floor NextHost;
	private int floorindex;
	private int pathindex;

	private bool SearchMode;
	private bool Again;
	public static bool FollowPath;

	private bool PlayerMove;
	private int tempt;

	GameObject TemptFloorA;
	GameObject TemptFloorB;
	public GameObject FloorA;
	public GameObject FloorB;
	public float dis;
	public Vector3 WalkDir;
	public Quaternion FaceRotation;
	Vector3 fix = new Vector3(0, 1, 0);
	Animation anim;
	bool InFloorCenter;
	bool ChangeGoal;
	GameObject Origin;

	void Start () {
		FourRay = new Ray(Vector3.zero, Vector3.zero);
		Directions [0] = Vector3.forward;
		Directions [1] = Vector3.right;
		Directions [2] = Vector3.back;
		Directions [3] = Vector3.left;
		anim = GameObject.Find ("Player_Body").GetComponent<Animation> ();
	}
	void Stopanim(){
		anim.Rewind ();
		anim.Play ();
		anim.Sample ();
		anim.Stop ();
	}


	void FixedUpdate(){



		// 主角尋路系統
		if (FollowPath && Closelist.Count <= AllFloors.Length && !Global.IsPushing && !Global.IsPreRotating) {



				dis = Vector3.Distance (Global.Player.transform.position, FloorB.transform.position + fix);
				anim.Play ("Walk");
				Global.Player.GetComponent<PlayerController> ().LockRotation = false;
				Global.Player.transform.position += (FloorB.transform.position - FloorA.transform.position + new Vector3 (0, 0.45f, 0)) * 3 * Time.deltaTime;





			if (dis <= 0.1f) {
				if (PlayerController.CurrentFloor == BeTouchedFloor) {
					PlayerController.CancelMoving (BeTouchedFloor.transform.position);
					//Global.Player.transform.position = PlayerController.CurrentFloor.transform.position + fix;
					Stopanim ();	
					FollowPath = false;
					Global.PlayerMove = false;
				}

				Global.Player.transform.position = PlayerController.CurrentFloor.transform.position + fix;

				if (!ChangeGoal) {
					FloorA = FloorB;
					FloorB = Pathlist.Find ((x) => x.Dad != null && x.Dad == PlayerController.CurrentFloor).Object;
				} 
				else{
					FloorA = TemptFloorA;
					FloorB = TemptFloorB;
					ChangeGoal = false;
						
					}
				InFloorCenter = true;

				
			} else {
				InFloorCenter = false;
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

		// 主角自轉系統：開始自轉
		if (!Global.IsPreRotating && !Global.IsPushing && !Global.Player.GetComponent<PlayerController>().LockRotation) {
			Global.Player.transform.rotation = Quaternion.Lerp (Global.Player.transform.rotation, FaceRotation, 0.25f);
			if (Quaternion.Angle (Global.Player.transform.rotation, FaceRotation) < 10) {
				Global.Player.transform.rotation = FaceRotation;
			}

		}

		// 主角自轉系統：設定方向
		if (FollowPath && Closelist.Count <= AllFloors.Length && FloorA != null && FloorB != null) {

			WalkDir = FloorA.transform.position - FloorB.transform.position;
			if (WalkDir.x > 0 && WalkDir.z == 0)
				FaceRotation = Quaternion.Euler (0, -90, 0);
			if (WalkDir.x < 0 && WalkDir.z == 0)
				FaceRotation = Quaternion.Euler (0, 90, 0);
			if (WalkDir.z > 0 && WalkDir.x == 0)
				FaceRotation = Quaternion.Euler (0, 180, 0);
			if (WalkDir.z < 0 && WalkDir.x == 0)
				FaceRotation = Quaternion.Euler (0, 0, 0);
		}
	}

	public void Reset(){
		NeighborFloor = null;
		AllFloors = GameObject.FindGameObjectsWithTag("Floor");
		foreach(GameObject color in AllFloors){
			//color.GetComponent<Renderer> ().enabled = true;
			//color.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/Gray2") as Material;
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

	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hitinfo, 500, 1 << 10) && !Global.IsCamCtrl && !Global.IsPreRotating && !Global.StopTouch ) {
			Debug.DrawLine (Camera.main.transform.position, hitinfo.transform.position, Color.yellow, 0.1f, true);
			if (BeTouchedFloor != null) {
				//BeTouchedFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/Gray2") as Material;
			}


			Global.PlayerMove = true;
			BeTouchedFloor = hitinfo.collider.gameObject;

			Reset ();

			if (FollowPath) {
				ChangeGoal = true;
			}

			if (BeTouchedFloor != PlayerController.CurrentFloor) {
				SearchMode = true;
				CheckNeighbor ();
			}
		}


		/*
		if (Again) {
			CheckNeighbor ();
			if (Closelist.Count > 100) {
				Again = false;
				SearchMode = fa			lse;

				print("No way!!");
			}
			//Again = false;
		}*/




		
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
				//Dadfloor.Object.GetComponent<Renderer> ().material = Resources.Load ("Materials/Yellow") as Material;
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



	private void CheckNeighbor(){
		if (Closelist.Count > AllFloors.Length) {
			Again = false;
			SearchMode = false;
			Stopanim ();
			Global.PlayerMove = false;
			//Global.Player.transform.position = PlayerController.CurrentFloor.transform.position + fix;
			print("<color=orange>No way!!</color>");
		}

		if(SearchMode && !Global.IsPushing){

		for(int i=0 ; i<4 ; i++){
				FourRay.origin = Startfloor.Object.transform.position;
				FourRay.direction = Directions [i];

				// 訪問鄰居
				if (Physics.Raycast (FourRay, out Fourinfo, 1, 1 << 10)) {
					if (Fourinfo.collider.gameObject != null) {
						NeighborFloor = Fourinfo.collider.gameObject;
						Obstacle = NeighborFloor.GetComponent<Floorinfos> ().Obstacle;
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
							//NeighborFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Blue") as Material;

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
		//Startfloor.Object.GetComponent<Renderer> ().material = Resources.Load ("Materials/Dark") as Material;

			if (Closelist.Contains(Startfloor)){
				MinF = 10000;
			} else {
				MinF = Startfloor.F_cost;
			}
		BeTouchedFloor.GetComponent<Renderer> ().enabled = true;
		BeTouchedFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/Touch2") as Material;


		foreach (Floor neighbor in Openlist) {
			if (neighbor.F_cost <= MinF) {
				MinF = neighbor.F_cost;
				NextHost = neighbor;
			}
			if (neighbor.H_cost == 0) {
					MinF = neighbor.F_cost;
					NextHost = neighbor;	
				//print ("Finish Searching!");
				Again = false;
				SearchMode = false;
					PathSetting ();
			}
		}

			//Startfloor.index = NextHost.index;
			Startfloor.Object = NextHost.Object;
			Startfloor.G_cost = NextHost.G_cost;
			Startfloor.H_cost = NextHost.H_cost;
			Startfloor.F_cost = NextHost.F_cost;
			Startfloor.Dad = NextHost.Dad;
			Startfloor.ToDad = NextHost.ToDad;
			if(SearchMode)
			CheckNeighbor ();
			//if(SearchMode)
			//Again = true;
		}
	}
}