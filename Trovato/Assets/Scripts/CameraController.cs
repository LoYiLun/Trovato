using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Cam;
	public GameObject Cam2;
	public GameObject CamObj;
	public GameObject CamObj2;
	public GameObject Player;
	private Vector3 CamToPlayer;

	public static GameObject CurrentCam;

	void Awake(){
		CamToPlayer = Cam.transform.position - Player.transform.position;
		CamObj2.SetActive (false);
		CurrentCam = Cam;
	}

	void Start () {

	}
	

	void Update () {
		Cam.transform.position = CamToPlayer + Player.transform.position;
		//Cam.transform.LookAt (GameObject.Find ("ScreenHeart").transform);
	}

	public void BirdCam(){
		CamObj.SetActive (false);
		CamObj2.SetActive (true);
		CurrentCam = Cam2;
	}

	public void StalkerCam(){
		CamObj.SetActive (true);
		CamObj2.SetActive (false);
		CurrentCam = Cam;
	}

}
