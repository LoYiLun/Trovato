using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorinfos : MonoBehaviour {

	public bool Obstacle;
	private Ray Upray;
	private RaycastHit Upinfo;
	private RaycastHit Upinfo2;
	private Ray Downray;
	private RaycastHit Downinfo;
	public GameObject UpFloor;
	public GameObject DownFloor;

	void Start () {
		
	}
	

	void Update () {
		Upray = new Ray (gameObject.transform.position, Vector3.up);
		Downray = new Ray (gameObject.transform.position, Vector3.down);
		/*if (Physics.Raycast (Upray, out Upinfo, 1, 1 << 10)) {
			//Debug.DrawLine (gameObject.transform.position, Upinfo.transform.position, Color.yellow, 0.1f, true);
			//GameObject.Find("GlobalScripts").GetComponent<PathController>().NeighborFloor = Upinfo.collider.gameObject;
			//GameObject.Find ("GlobalScripts").GetComponent<PathController> ().Obstacle = Upinfo.collider.gameObject.GetComponent<Floorinfos> ().Obstacle;

		}*/

		/*if (Physics.Raycast (Upray, out Upinfo, 2, 1 << 20) && Physics.Raycast (Downray, out Downinfo, 5, 1 << 10)) {
			DownFloor = Downinfo.collider.gameObject;
			//gameObject.GetComponent<Collider> ().enabled = false;
			Obstacle = true;

		} else if (Physics.Raycast (Upray, out Upinfo, 2, 1 << 20)) {
			//UpFloor = null;
			//gameObject.GetComponent<Collider> ().enabled = true;
			DownFloor = null;
			Obstacle = true;
		} else if (Physics.Raycast (Downray, out Downinfo, 5, 1 << 10)) {
			//UpFloor = Upinfo2.collider.gameObject;
			//gameObject.GetComponent<Collider> ().enabled = false;
			DownFloor = Downinfo.collider.gameObject;
			Obstacle = false;
		} else {
			//UpFloor = null;
			DownFloor = null;
			//gameObject.GetComponent<Collider> ().enabled = true;
			Obstacle = false;
		}*/

		
		if (Physics.Raycast (Upray, out Upinfo, 2, 1 << 20) && Physics.Raycast (Upray, out Upinfo2, 5, 1 << 10)) {
			UpFloor = Upinfo2.collider.gameObject;
			gameObject.GetComponent<Collider> ().enabled = false;
			Obstacle = true;

		} else if (Physics.Raycast (Upray, out Upinfo, 2, 1 << 20)) {
			UpFloor = null;
			gameObject.GetComponent<Collider> ().enabled = true;
			Obstacle = true;
		} else if (Physics.Raycast (Upray, out Upinfo2, 5, 1 << 10)) {
			UpFloor = Upinfo2.collider.gameObject;
			gameObject.GetComponent<Collider> ().enabled = false;
			Obstacle = false;
		} else {
			UpFloor = null;
			gameObject.GetComponent<Collider> ().enabled = true;
			Obstacle = false;
		}


	}
}
