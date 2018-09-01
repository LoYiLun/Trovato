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
	public GameObject ScreenHeart;

	float mx;
	float my;
	float Close;
	float Far;
	float RotateX;
	Vector3 Distance;
	float Distance2;

	void Awake(){
		CamToPlayer = Cam.transform.position - Player.transform.position;
		CamObj2.SetActive (false);
		CurrentCam = Cam;



	}

	void Start () {
		
	}
	

	void FixedUpdate () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		mx = Input.GetAxis ("Mouse X") ;
		my = Input.GetAxis ("Mouse Y") ;
		RotateX = CurrentCam.transform.rotation.x;

		Distance = CurrentCam.transform.position - ScreenHeart.transform.position;
		Distance2 = Vector3.Distance (CurrentCam.transform.position, ScreenHeart.transform.position);

		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView < 25) {
			Camera.main.fieldOfView += 1;
		} else if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView > 15) {
			Camera.main.fieldOfView -= 1;
		}

		if ((Input.GetMouseButton (0) || Input.GetMouseButton (1)) && Global.IsCamCtrl) 
		{


			// 左右
			if(mx > 0){
				Cam.transform.Translate (-80*Time.deltaTime, 0, 0);
				Cam.transform.position -= Vector3.forward * Time.deltaTime;
				Cam.transform.LookAt(ScreenHeart.transform);
			}
			if (mx < 0) {
				Cam.transform.Translate (80*Time.deltaTime, 0, 0);
				Cam.transform.position += Vector3.forward * Time.deltaTime;
				Cam.transform.LookAt(ScreenHeart.transform);
			}

			if (my > 0 && Distance.y > -45) 
			{
				Cam.transform.Translate (0, -80*Time.deltaTime, 0);
				Cam.transform.LookAt(ScreenHeart.transform);

			}
			if (my < 0 && Distance.y < 45) 
			{
				Cam.transform.Translate (0, 80*Time.deltaTime, 0);
				Cam.transform.LookAt(ScreenHeart.transform);
			}
		}

		if (Input.GetMouseButtonUp (0) || Input.GetMouseButtonUp (1) && Global.IsCamCtrl) {
			if (Distance2 > 50) {
				Cam.transform.position = Vector3.MoveTowards (Cam.transform.position, ScreenHeart.transform.position, Distance2-50+1);
			}
		}

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
