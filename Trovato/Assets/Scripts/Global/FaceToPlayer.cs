using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToPlayer : MonoBehaviour {

	private Quaternion RotateDir;
	private bool StartRotate;

	// Look at Player.
	public GameObject Head;
	private Vector3 SightDirection;
	private Ray SightRay;
	private RaycastHit SightInfo;
	private GameObject Target;
	private bool ResetHead;

	int count;

	void Awake(){

	}

	void Start () {
		RotateDir = transform.rotation;
	}

	void Update(){


		if (Head != null) {
			/*
			SightRay.origin = gameObject.transform.position;
			SightRay.direction = gameObject.transform.forward + new Vector3(Mathf.PingPong(count*3, 90)-45, -1, 0);
			count++;*/

		}



		if (Input.GetKeyDown (KeyCode.E) && Vector3.Distance(Global.Player.transform.position, transform.position) < 1.2f && PathController.FollowPath == false) {
			if (Global.Player.transform.position.x > transform.position.x && Mathf.Abs (Global.Player.transform.position.z - transform.position.z) <= 0.2f) {
				RotateDir = Quaternion.Euler (0, 90, 0);
				GameObject.Find ("GlobalScripts").GetComponent<PathController> ().FaceRotation = Quaternion.Euler (0, -90, 0);
			} 
			if (Global.Player.transform.position.x < transform.position.x && Mathf.Abs (Global.Player.transform.position.z - transform.position.z) <= 0.2f) {
				RotateDir = Quaternion.Euler (0, -90, 0);
				GameObject.Find ("GlobalScripts").GetComponent<PathController> ().FaceRotation = Quaternion.Euler (0, 90, 0);
			} 
			if (Global.Player.transform.position.z > transform.position.z && Mathf.Abs (Global.Player.transform.position.x - transform.position.x) <= 0.2f) {
				RotateDir = Quaternion.Euler (0, 0, 0);
				GameObject.Find ("GlobalScripts").GetComponent<PathController> ().FaceRotation = Quaternion.Euler (0, 180, 0);
			} 
			if (Global.Player.transform.position.z < transform.position.z && Mathf.Abs (Global.Player.transform.position.x - transform.position.x) <= 0.2f) {
				RotateDir = Quaternion.Euler (0, 180, 0);
				GameObject.Find ("GlobalScripts").GetComponent<PathController> ().FaceRotation = Quaternion.Euler (0, 0, 0);
			}

			StartRotate = true;
		}

		if (StartRotate) {
			transform.rotation = Quaternion.Lerp (transform.rotation, RotateDir, 0.15f);
			if (Quaternion.Angle (transform.rotation, RotateDir) < 5) {
				transform.rotation = RotateDir;
				StartRotate = false;
			}
		}
	}

	void FixedUpdate () {

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
