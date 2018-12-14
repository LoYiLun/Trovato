using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyRotate : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
		if (gameObject.transform.position.y == 0) {
			gameObject.transform.RotateAround (GameObject.Find ("ScreenHeart").transform.position, Vector3.up, 100);
		}

		else if (gameObject.transform.position.y >= -5) {
			gameObject.transform.RotateAround (GameObject.Find ("ScreenHeart").transform.position, Vector3.up, -100);
		}

		else if (gameObject.transform.position.y < -5 && gameObject.transform.position.y > -9) {
			gameObject.transform.RotateAround (GameObject.Find ("ScreenHeart").transform.position, Vector3.up, 100);
		}

		else if (gameObject.transform.position.y <= -9) {
			gameObject.transform.RotateAround (GameObject.Find ("ScreenHeart").transform.position, Vector3.up, -100);
		}
	}
}
