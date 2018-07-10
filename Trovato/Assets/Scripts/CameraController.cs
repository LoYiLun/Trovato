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

	// Use this for initialization
	void Start () {
		CamToPlayer = Cam.transform.position - Player.transform.position;
		CamObj2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		Cam.transform.position = CamToPlayer + Player.transform.position;
	}

	public void BirdCam(){
		CamObj.SetActive (false);
		CamObj2.SetActive (true);
	}

	public void StalkerCam(){
		CamObj.SetActive (true);
		CamObj2.SetActive (false);
	}

}
