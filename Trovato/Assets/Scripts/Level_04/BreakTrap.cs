using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakTrap : MonoBehaviour {

	public static int Breaks = 0;

	Ray ray;
	RaycastHit Trapinfo;
	Text HP_Text;
	float HP = 10;

	void Awake(){
		HP_Text = gameObject.transform.GetChild (0).GetChild (0).GetComponent<Text> ();
	}

	void Start () {
		
	}
	

	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButton (0) && Physics.Raycast (ray, out Trapinfo, 100, 1<<20)) {
			if (Trapinfo.collider.gameObject == gameObject && Vector3.Distance (Global.Player.transform.position, gameObject.transform.position) <= 1.1f) {
				GameObject.Find ("Player_Body").GetComponent<Animation> ().Play ("Push_And_Stand");
				HP -= 0.1f;
				HP_Text.text = Mathf.Floor (HP).ToString ();
			}





		}

		if (Breaks == 4) {
			HP = 0;
		}

		if (Breaks == 5) {
			Destroy (gameObject);
			Global.StopTouch = false;
		}

		if (HP <= 0) {
			HP -= 0.1f;
			gameObject.GetComponent<Renderer> ().enabled = false;
			gameObject.transform.GetChild (1).GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.transform.GetChild (2).GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.transform.GetChild (3).GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.transform.GetChild (4).GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.transform.GetChild (5).GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.transform.GetChild (6).GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.transform.GetChild (7).GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.transform.GetChild (8).GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.transform.GetChild (9).GetComponent<Rigidbody> ().isKinematic = false;
			Global.StopTouch = true;
			Global.Player.GetComponent<PlayerController> ().StopPlayerAnim ();

			if (HP <= -8) {
				Destroy (gameObject);
				Global.Player.GetComponent<PlayerController> ().StopPlayerAnim ();
				Global.StopTouch = false;
				Breaks++;
			}

			/*
				gameObject.transform.GetChild (1).GetComponent<Collider> ().enabled = false;
				gameObject.transform.GetChild (2).GetComponent<Collider> ().enabled = false;
				gameObject.transform.GetChild (3).GetComponent<Collider> ().enabled = false;
				gameObject.transform.GetChild (4).GetComponent<Collider> ().enabled = false;
				gameObject.transform.GetChild (5).GetComponent<Collider> ().enabled = false;
				gameObject.transform.GetChild (6).GetComponent<Collider> ().enabled = false;
				gameObject.transform.GetChild (7).GetComponent<Collider> ().enabled = false;
				gameObject.transform.GetChild (8).GetComponent<Collider> ().enabled = false;
				gameObject.transform.GetChild (9).GetComponent<Collider> ().enabled = false;*/
			HP_Text.enabled = false;
		}
	}
}
