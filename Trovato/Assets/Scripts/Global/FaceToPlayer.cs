﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToPlayer : MonoBehaviour {

	Quaternion RotateDir;
	bool StartRotate;

	void Start () {
		RotateDir = transform.rotation;
	}
	

	void FixedUpdate () {
		if (StartRotate) {
			transform.rotation = Quaternion.Lerp (transform.rotation, RotateDir, 0.15f);
			if (Quaternion.Angle (transform.rotation, RotateDir) < 5) {
				transform.rotation = RotateDir;
				StartRotate = false;
			}
		}
	}

	void OnCollisionEnter(Collision other){

		/*
		if (other.gameObject == Global.Player) {
			transform.LookAt (other.transform.position);
			}
*/
			
		if (Global.Player.transform.position.x > transform.position.x && Mathf.Abs(Global.Player.transform.position.z - transform.position.z) <= 0.2f) {
				RotateDir = Quaternion.Euler (0, 90, 0);
			} 
		if (Global.Player.transform.position.x < transform.position.x && Mathf.Abs(Global.Player.transform.position.z - transform.position.z) <= 0.2f) {
				RotateDir = Quaternion.Euler (0, -90, 0);
			} 
		if (Global.Player.transform.position.z > transform.position.z && Mathf.Abs(Global.Player.transform.position.x - transform.position.x) <= 0.2f) {
				RotateDir = Quaternion.Euler (0, 0, 0);
			} 
		if (Global.Player.transform.position.z < transform.position.z && Mathf.Abs(Global.Player.transform.position.x - transform.position.x) <= 0.2f) {
				RotateDir = Quaternion.Euler (0, 180, 0);
			}

			StartRotate = true;

	}
}
