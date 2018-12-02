using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorinfos : MonoBehaviour {

	public bool Obstacle;
	private Ray Upray;
	private RaycastHit Upinfo;
	private RaycastHit Upinfo2;
	public GameObject UpFloor;
	public GameObject DownFloor;

	void Start () {
		
	}
	

	void Update () {
		Upray = new Ray (gameObject.transform.position, Vector3.up);
		
		if (Physics.Raycast (Upray, out Upinfo, 2, 1 << 20) && Physics.Raycast (Upray, out Upinfo2, 5, 1 << 10)) {
			UpFloor = Upinfo2.collider.gameObject;
			gameObject.GetComponent<Collider> ().enabled = false;
			Obstacle = true;
			if(Global.Level != "Astar")
			gameObject.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/touch2") as Material;
		} else if (Physics.Raycast (Upray, out Upinfo, 2, 1 << 20)) {
			UpFloor = null;
			gameObject.GetComponent<Collider> ().enabled = true;
			Obstacle = true;
			if(Global.Level != "Astar")
			gameObject.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/touch2") as Material;
		} else if (Physics.Raycast (Upray, out Upinfo2, 5, 1 << 10)) {
			UpFloor = Upinfo2.collider.gameObject;
			gameObject.GetComponent<Collider> ().enabled = false;
			Obstacle = false;
			if(Global.Level != "Astar")
			gameObject.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/touch2") as Material;
		} else {
			UpFloor = null;
			gameObject.GetComponent<Collider> ().enabled = true;
			Obstacle = false;
			if(Global.Level != "Astar")
			gameObject.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/touch2") as Material;
		}


	}
}
