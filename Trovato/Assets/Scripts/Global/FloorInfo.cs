using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorInfo : MonoBehaviour {

	public float H_Cost;
	public float G_Cost;
	public float F_Cost;
	public bool HasObstacle;

	Ray UpRay;
	RaycastHit hitinfo;
	public static GameObject CurrentFloor;

	void Start () {
		
	}
	

	void FixedUpdate () {


		UpRay = new Ray (gameObject.transform.position, Vector3.up);
		if (Physics.Raycast (UpRay, out hitinfo, 1)) {
			
			if (hitinfo.collider.tag == "Obstacle") {
				HasObstacle = true;
			} else {
				HasObstacle = false;
			}

		}
	}
}
