using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorinfos : MonoBehaviour {

	public bool Obstacle;
	private Ray Upray;
	private RaycastHit Upinfo;

	void Start () {
		
	}
	

	void Update () {
		Upray = new Ray (gameObject.transform.position, Vector3.up);
		if (Physics.Raycast (Upray, out Upinfo, 1, 1 << 20)) {
			//Debug.DrawLine (gameObject.transform.position, Upinfo.transform.position, Color.yellow, 0.1f, true);
			Obstacle = true;
		} else {
			Obstacle = false;
		}
	}
}
