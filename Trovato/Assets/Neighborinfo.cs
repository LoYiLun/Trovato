using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighborinfo : MonoBehaviour {

	public GameObject Neighbor;
	public LayerMask Floorlayer;
	private Ray ray;
	private RaycastHit hitinfo;

	void Start () {
		
	}
	

	void Update () {
		/*
		ray.origin = gameObject.transform.position;
		ray.direction = Vector3.down;
		if (Physics.Raycast (ray, out hitinfo, 10, 1 << 10)) {
			Debug.DrawLine (gameObject.transform.position, hitinfo.transform.position, Color.yellow, 0.1f, true);
			if (hitinfo.collider.gameObject != null) {
				Neighbor = hitinfo.collider.gameObject;
				print ("hit: " + Neighbor);
			}
		}*/
	}
	/*
	void OnCollisionEnter(Collision neighbor){
		if (neighbor.gameObject.tag == "Floor") {
			print("10");
			Neighbor = neighbor.gameObject;
		}
	}

	void OnCollisionStay(Collision neighbor){
		if (neighbor.gameObject.tag == "Floor") {
			print("10");
			Neighbor = neighbor.gameObject;
		}
	}*/
}
