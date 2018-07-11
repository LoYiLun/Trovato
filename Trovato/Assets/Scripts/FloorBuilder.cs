using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBuilder : MonoBehaviour {

	public GameObject Floor;
	private GameObject FloorClone;
	private int Count = 0;
	private int FloorRange;
	public int CubeMode;
	public int FloorMode;

	void Start () {

		Floor = GameObject.Find ("Floor_Origin");
			for (int i = 0; i < 9; i++) {
				for (int j = 0; j < 9; j++) {
					FloorClone = Instantiate (Floor, Floor.transform.position + new Vector3 (-i, 0, -j), Quaternion.identity);
					Count++;
					FloorClone.name = ("Floor_" + Count);
				}
			}
		//Floor.SetActive (false);

		BuildFloor ();


	
	}
	

	void Update () {


	}

	public void BuildFloor(){
		//Floor = GameObject.Find ("Floor_Origin");
		FloorRange = CubeMode * FloorMode;
		for (int i = 0; i < FloorRange; i++) {
			for (int j = 0; j < FloorRange; j++) {
				FloorClone = Instantiate (Floor, Floor.transform.position + new Vector3 (-i, 0, -j), Quaternion.identity);
				Count++;
				FloorClone.name = ("Floor_" + Count);

			}
		}
		//Floor.SetActive (false);
	}

}
