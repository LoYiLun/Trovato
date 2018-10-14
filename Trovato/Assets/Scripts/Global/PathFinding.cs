using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {


	public static List<GameObject> Openlist = new List<GameObject>();
	public static List<GameObject> Closelist = new List<GameObject>();

	GameObject[] FloorGroup;
	Vector3[] Directions = new Vector3[4];

	Ray Ray;
	RaycastHit hitinfo;

	GameObject NeighborFloor;

	float Mini_F = 100;
	GameObject ChosenFloor;
	GameObject NextChosenFloor;

	public bool HasObstacle;
	Ray UpRay;
	RaycastHit Uphitinfo;

	bool FinishFinding;

	void Start () {
		Directions [0] = Vector3.forward;
		Directions [1] = Vector3.right;
		Directions [2] = Vector3.back;
		Directions [3] = Vector3.left;


	}
	

	void Update () {
		FloorGroup = this.gameObject.GetComponent<FloorBuilder> ().FloorGroup;

		if (Global.StartFinding && PlayerController.CurrentFloor != null && Global.BeTouchedObj != null) {
			Find (PlayerController.CurrentFloor.transform.position, Global.BeTouchedObj.transform.position);
			Global.StartFinding = false;
		}


	}

	void Find(Vector3 StartPos, Vector3 GoalPos){



			
			ChosenFloor = PlayerController.CurrentFloor;
			Openlist.Add (ChosenFloor);

			for (int i = 0; i < 4; i++) {

				// 調查相鄰地板
				Ray = new Ray (ChosenFloor.transform.position, Directions [i]);
				if (Physics.Raycast (Ray, out hitinfo, 1, 1 << 10) && !Openlist.Contains (hitinfo.collider.gameObject) && !Closelist.Contains (hitinfo.collider.gameObject)) {
					NeighborFloor = hitinfo.collider.gameObject;
				} else {
					continue;
				}

				// 調查有無障礙物
				UpRay = new Ray (Global.BeTouchedObj.transform.position, Vector3.up);
			if (Physics.Raycast (UpRay, out Uphitinfo, 1) && Uphitinfo.collider.gameObject.tag == "Obstacle") {
				Global.StartFinding = false;
				break;
			}

				UpRay = new Ray (NeighborFloor.transform.position, Vector3.up);
				if (Physics.Raycast (UpRay, out Uphitinfo, 1) && Uphitinfo.collider.gameObject.tag == "Obstacle")
					NeighborFloor.GetComponent<FloorInfo> ().HasObstacle = true;
				else
					NeighborFloor.GetComponent<FloorInfo> ().HasObstacle = false;
			

				// 計算三個值
				if (NeighborFloor.GetComponent<FloorInfo> ().HasObstacle == false) {
					Openlist.Add (NeighborFloor);
					NeighborFloor.GetComponent<FloorInfo> ().G_Cost = Mathf.Abs (StartPos.x - NeighborFloor.transform.position.x) + Mathf.Abs (StartPos.z - NeighborFloor.transform.position.z);
					NeighborFloor.GetComponent<FloorInfo> ().H_Cost = Mathf.Abs (GoalPos.x - NeighborFloor.transform.position.x) + Mathf.Abs (GoalPos.z - NeighborFloor.transform.position.z);
					NeighborFloor.GetComponent<FloorInfo> ().F_Cost = NeighborFloor.GetComponent<FloorInfo> ().G_Cost + NeighborFloor.GetComponent<FloorInfo> ().H_Cost;
					//NeighborFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Global/Yellow")as Material;
					//NeighborFloor.GetComponent<Renderer> ().enabled = true;
					if (NeighborFloor != null)
						print (NeighborFloor.name + "_F: " + NeighborFloor.GetComponent<FloorInfo> ().F_Cost);

					// 如果找到F更小的地板則替換
				foreach (GameObject floor in Openlist) {
					if (floor.GetComponent<FloorInfo> ().F_Cost <= Mini_F) {
						Mini_F = NeighborFloor.GetComponent<FloorInfo> ().F_Cost;
						NextChosenFloor = NeighborFloor;
					}
				}

				}

			
			}
			if (NextChosenFloor != null)
				//print (NextChosenFloor.name + " is next: " + Mini_F);
			Openlist.Remove (ChosenFloor);
			Closelist.Add (ChosenFloor);
			ChosenFloor = NextChosenFloor;
			NextChosenFloor = null;

			if (ChosenFloor != null) {
				//print (ChosenFloor.name);
			if (ChosenFloor.transform.position == GoalPos || ChosenFloor.transform.position == StartPos) {
					//FinishFinding = true;
				Global.StartFinding = false;
				}
			} else {
				//print ("No ChosenFloor.");
				foreach (GameObject floor in Openlist) {
					if (floor.GetComponent<FloorInfo> ().F_Cost <= Mini_F) {
						Mini_F = NeighborFloor.GetComponent<FloorInfo> ().F_Cost;
						NextChosenFloor = NeighborFloor;
					}
				}
			}
		}


}


