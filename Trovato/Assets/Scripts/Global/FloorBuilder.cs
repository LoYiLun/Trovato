using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBuilder : MonoBehaviour {

	int Count = 0;
	int FloorRange;
	GameObject FloorClone;
	public int CubeMode;
	public int FloorMode;
	public int FloorID;
	public GameObject Floor;
	public GameObject[] FloorGroup = new GameObject[81];


	bool FinishBuilding;

	void Start () {
		BuildFloor ();
	}
	

	void FixedUpdate () {
		

		if (FinishBuilding) {
			if (Global.OnCubeNum == FloorID || Global.OnCubeNum == 0) {
				for(int i = 0 ; i < FloorRange * FloorRange; i++) {
					FloorGroup [i].transform.parent = Floor.transform;
					FloorGroup[i].GetComponent<Collider> ().enabled = true;
				}
			} else {
				for(int i = 0 ; i < FloorRange * FloorRange; i++) {
					FloorGroup [i].transform.parent = Floor.transform;
					FloorGroup[i].GetComponent<Collider> ().enabled = false;
				}
			}
		}
	}

	void BuildFloor(){
		FloorRange = CubeMode * FloorMode;
		for (int i = 0; i < FloorRange; i++) {
			for (int j = 0; j < FloorRange; j++) {
				FloorClone= Instantiate (Floor, Floor.transform.position + new Vector3 (-i, 0, -j), Quaternion.identity);
				FloorGroup [Count] = FloorClone;
				Count++;
				FloorClone.name = ("V" + CubeMode + "Floor_" + Count);


			}
		}
		FinishBuilding = true;

	}

}
