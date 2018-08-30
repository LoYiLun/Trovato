using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCam : MonoBehaviour {

	public GameObject CamObj;
	Vector3 CamPos;

	void Start () {
		
	}
	

	void Update () {
		//CamPos = CamObj.transform.position * (-100);
		CamPos = CameraController.CurrentCam.transform.position * (-100);
		this.transform.LookAt (CamPos);
	}
}
