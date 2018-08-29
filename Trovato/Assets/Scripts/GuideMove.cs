using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideMove : MonoBehaviour {

	//Vector3 StartPos;
	Vector3 Path;
	float Distance;
	GameObject[] TemptGuideBall;
	public GameObject GuideBall;

	void Start () {
		//StartPos = gameObject.transform.position;
	}


	void FixedUpdate () {
		/*
		RaycastHit hit;
		Ray LandRay = new Ray (transform.position, Vector3.down);
		Debug.DrawRay (transform.position, Vector3.down * 3);

		if (Physics.Raycast (LandRay, out hit, 3, 1 << 10)) {
			
			}
		else if(gameObject.name != "GuideBall") {
			Destroy (gameObject);
		}




		Distance = Mathf.Abs(gameObject.transform.position.x - StartPos.x) + Mathf.Abs(gameObject.transform.position.z - StartPos.z);
		if (Distance >= 0.8f && gameObject.name != "GuideBall") {
			for (int i = 0; i < 4; i++) {
				TemptGuideBall[i] = Instantiate (GuideBall, gameObject.transform.position, Quaternion.identity);
				TemptGuideBall [i].transform.Rotate (0, i*90, 0);
			}
			Path = transform.position - StartPos;
			Destroy (gameObject);
		}
		gameObject.transform.Translate (0.1f, 0, 0);
		*/
	}


	void OnTriggerStay(Collider other){
		if (other.transform.tag == "Obstacle") {
			Destroy (gameObject);
		}
	}
}
