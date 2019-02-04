using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEffect : MonoBehaviour {

	public GameObject WalkDust;

	Ray DownRay;
	RaycastHit Downinfo;

	GameObject CurrentFloor;
	GameObject CurrentDust;

	void Start () {
	}

	void Update () {
		DownRay.origin = Global.Player.transform.position;
		DownRay.direction = Vector3.down;

		if (Physics.Raycast (DownRay, out Downinfo, 1, 1 << 10)) {
			if (CurrentFloor == null) {
				CurrentFloor = Downinfo.collider.gameObject;
				print (CurrentFloor.name);
			} else if(CurrentFloor != Downinfo.collider.gameObject) {
				CurrentFloor = Downinfo.collider.gameObject;
				print (CurrentFloor.name);
				//DestroyDust ();
				CreateDust (WalkDust, Global.Player);
			}
		}

		/*
		if (PathController.FollowPath) {
			Instantiate (WalkDust, Global.Player.transform.position, Quaternion.identity, Global.Player.transform);
		}*/
	}

	void CreateDust(GameObject _Dust, GameObject _Target){
		CurrentDust = Instantiate (_Dust);
		CurrentDust.transform.position = _Target.transform.position;
		CurrentDust.transform.rotation = _Target.transform.rotation;
	}

	void DestroyDust(){
		if (CurrentDust != null) {
			Destroy (CurrentDust);
		}
	}
}
