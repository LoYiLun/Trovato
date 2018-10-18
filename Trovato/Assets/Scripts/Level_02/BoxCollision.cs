using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour {

	Ray DownRay;
	RaycastHit hitinfo;
	GameObject Cube;

	void Start () {
		
	}


	void FixedUpdate () {
		// Find Cube
			DownRay = new Ray (transform.position, Vector3.down);
		if (Physics.Raycast (DownRay, out hitinfo, 5, 1<<11) && transform.parent != Global.Player.transform && Global.IsRotating != true) {
			Cube = hitinfo.collider.gameObject;
			transform.parent = Cube.transform;
		}
	}

	void OnCollisionEnter(Collision other){
		if ((other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Moveable") && gameObject.transform.parent == Global.Player.transform) {
			PlayerController.CancelMoving (new Vector3(PlayerController.CurrentFloor.transform.position.x, Global.Player.transform.position.y, PlayerController.CurrentFloor.transform.position.z));
			GameObject.Find ("Player_Body").GetComponent<Animation> ().Play("Push_And_Stand");

			// 箱子推進焚化爐
			if (other.gameObject.name == "IncinerationPlant4" || other.gameObject.name == "IncinerationPlant5" || other.gameObject.name == "IncinerationPlant6") {
				Level02PlayerEvent.box++;
				GameObject.Find ("Player_Body").GetComponent<Animation> ().Play("Push_To_Stand");
				PlayerController.MoveSpeed = 4;
				gameObject.GetComponent<Renderer> ().enabled = false;
				gameObject.GetComponent<Collider> ().enabled = false;
				Global.BePushedObj = null;
				Global.IsPushing = false;
			}
		}
	}

	// 箱子碰撞障礙物或可移物
	void OnCollisionStay(Collision other){
		if ((other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Moveable") && gameObject.transform.parent == Global.Player.transform) {
			PlayerController.CancelMoving (new Vector3(PlayerController.CurrentFloor.transform.position.x, Global.Player.transform.position.y, PlayerController.CurrentFloor.transform.position.z));
		}
	}

	// 箱子碰撞隱形牆
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "GhostWall" && gameObject.transform.parent == Global.Player.transform) {
			PlayerController.CancelMoving (new Vector3(PlayerController.CurrentFloor.transform.position.x, Global.Player.transform.position.y, PlayerController.CurrentFloor.transform.position.z));
			
		}
	}

}
