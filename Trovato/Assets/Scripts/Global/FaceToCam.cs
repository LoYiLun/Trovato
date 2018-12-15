﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCam : MonoBehaviour {

	public GameObject CamObj;
	Vector3 CamPos;

	void Start () {
		
	}
	

	void Update () {
		if (CameraController.CurrentCam != null) {
			CamPos = CameraController.CurrentCam.transform.position * (-100);
			this.transform.LookAt (CamPos, GameObject.Find("Camera").transform.up);
		}
	}
}
