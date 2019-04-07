using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCam : MonoBehaviour {

	public GameObject CamObj;
	Vector3 CamPos;

	void Start () {
		
	}
	

	void Update () {
		if (CameraController.CurrentCam != null) {
			//CamPos = CameraController.CurrentCam.transform.position * (-100);
			CamPos = gameObject.transform.position - CameraController.CurrentCam.transform.position;
			gameObject.transform.LookAt (CamPos, CameraController.CurrentCam.transform.up);
		}
	}
}
