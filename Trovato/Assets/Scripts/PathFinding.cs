using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {

	Vector3 StartPos;
	Vector3 Path;

	void Start () {
		StartPos = transform.position;
		transform.Translate (1, 0, 0);
		Path = transform.position - StartPos;
		SearchPath ();
	}
	

	void Update () {
		
	}

	void SearchPath(){

	}
}
