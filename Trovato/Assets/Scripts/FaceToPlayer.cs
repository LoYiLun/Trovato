using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToPlayer : MonoBehaviour {

	Quaternion RotateDir;

	void Start () {
		RotateDir = transform.rotation;
	}
	

	void FixedUpdate () {
		transform.rotation = Quaternion.Lerp(transform.rotation, RotateDir, 0.1f);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject == Global.Player) {
			if (Global.Player.transform.position.x > transform.position.x) {
				RotateDir = Quaternion.Euler (0, 90, 0);
			}else if (Global.Player.transform.position.x < transform.position.x) {
				RotateDir = Quaternion.Euler (0, -90, 0);
			}else if (Global.Player.transform.position.z > transform.position.z) {
				RotateDir = Quaternion.Euler (0, 0, 0);
			}else if (Global.Player.transform.position.z < transform.position.z) {
				RotateDir = Quaternion.Euler (0, 180, 0);
			}
		}
	}
}
