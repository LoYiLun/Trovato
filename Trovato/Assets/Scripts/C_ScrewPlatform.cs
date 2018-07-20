using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ScrewPlatform : MonoBehaviour {

	Transform Rotation;
	float Speed = 0.03f;
	float Height;

	void Start () {
		Rotation = gameObject.transform;

	}
	

	void Update () {
		Height = gameObject.transform.position.y;
		print ("Height : " + Height);

		if (Global.RotateNum == 3 && Height < 3) {
			gameObject.transform.position += new Vector3(0, Speed, 0);
			//Rotation.Rotate (new Vector3 (0, 10, 0));
		} else if (Global.RotateNum == 10 && Height > -0.5f) {
			gameObject.transform.position -= new Vector3(0, Speed, 0);
			//Rotation.Rotate (new Vector3 (0, -10, 0));
		}


	}

}
