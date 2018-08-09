using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBuilder : MonoBehaviour {

	// CubeMode為魔方層數
	// FloorMode為一魔方格的邊長數
	public GameObject Floor;
	private GameObject FloorClone;
	private int Count = 0;
	private int FloorRange;
	public int CubeMode;
	public int FloorMode;


	void Start () {
		BuildFloor ();

	}
	

	void Update () {

	}

	public void BuildFloor(){
		FloorRange = CubeMode * FloorMode;
		for (int i = 0; i < FloorRange; i++) {
			for (int j = 0; j < FloorRange; j++) {
				FloorClone = Instantiate (Floor, Floor.transform.position + new Vector3 (-i, 0, -j), Quaternion.identity);
				Count++;
				FloorClone.name = ("Floor_" + Count);

			}
		}
	}

}
