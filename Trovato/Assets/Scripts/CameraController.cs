using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Cam;
	public GameObject CamObj;
	public GameObject Player;
	Vector3 CamToScreenHeart;
	Vector3 LockPlayer;
	Vector3 PosBeforeMove;
	//GameObject Hit;
	//GameObject GhostBall;

	public static GameObject CurrentCam;
	public static bool SetCamPos;
	public GameObject ScreenHeart;

	float mx;
	float my;
	float Close;
	float Far;
	Vector3 Distance;
	float Distance2;

	void Awake(){
		CurrentCam = Cam;
		CamToScreenHeart = CurrentCam.transform.position - ScreenHeart.transform.position;

		//GhostBall = GameObject.Find ("GhostBall");


	}

	void Start () {
		CurrentCam.transform.LookAt (ScreenHeart.transform);
	}
	

	void FixedUpdate () {



		// 路障透明工程
		/*
		LockPlayer = Player.transform.position - CurrentCam.transform.position - FixedPos;
		Ray ray = new Ray (CurrentCam.transform.position, LockPlayer);
		RaycastHit hitinfo;
		if (Physics.Raycast (ray, out hitinfo, 500)) {
			Debug.DrawLine (Camera.main.transform.position, hitinfo.transform.position, Color.white, 0.1f, true);
			Hit = hitinfo.collider.gameObject;
			if (Hit.GetComponent<Renderer> () != null && Hit.tag == "Obstacle") {
				GhostBall.transform.position = Hit.transform.position;
				Hit.GetComponent<Renderer> ().material = Resources.Load ("Materials/Ghost") as Material;
			}
		}*/

		mx = Input.GetAxis ("Mouse X") ;
		my = Input.GetAxis ("Mouse Y") ;

		Distance = CurrentCam.transform.position - ScreenHeart.transform.position;
		Distance2 = Vector3.Distance (CurrentCam.transform.position, ScreenHeart.transform.position);

		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView < 25) {
			Camera.main.fieldOfView += 1;
		} else if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView > 10) {
			Camera.main.fieldOfView -= 1;
		}

		// 控制攝影機平移
		/*
		if (Input.GetMouseButtonDown (2) && Global.IsCamCtrl != true && Global.StopTouch != true)
			PosBeforeMove = CurrentCam.transform.position;

		if (Input.GetMouseButton (2) && Global.IsCamCtrl != true && Global.StopTouch != true) {
			if (mx > 0) {
				CurrentCam.transform.Translate (-10 * Time.deltaTime, 0, 0);
			}
			if (mx < 0) {
				CurrentCam.transform.Translate (10 * Time.deltaTime, 0, 0);
			}

			// 上下
			if (my > 0 && Distance.y > -45) {
				CurrentCam.transform.Translate (0, -10 * Time.deltaTime, 0);
			}
			if (my < 0 && Distance.y < 45) {
				CurrentCam.transform.Translate (0, 10 * Time.deltaTime, 0);
			}
		}

		if (Input.GetMouseButtonUp (2) && Global.IsCamCtrl != true && Global.StopTouch != true) {
			CurrentCam.transform.position = PosBeforeMove;
		}*/

		// 控制攝影機旋轉視角
		if ((Input.GetMouseButton (0) || Input.GetMouseButton (1)) && Global.IsCamCtrl && Global.StopTouch != true) {


			// 左右
			if (mx > 0) {
				Cam.transform.Translate (-120 * Time.deltaTime, 0, 0);
				Cam.transform.position -= Vector3.forward * Time.deltaTime;
				Cam.transform.LookAt (ScreenHeart.transform);
			}
			if (mx < 0) {
				Cam.transform.Translate (120 * Time.deltaTime, 0, 0);
				Cam.transform.position += Vector3.forward * Time.deltaTime;
				Cam.transform.LookAt (ScreenHeart.transform);
			}

			// 上下
			if (my > 0 && Distance.y > -45) {
				Cam.transform.Translate (0, -120 * Time.deltaTime, 0);
				Cam.transform.LookAt (ScreenHeart.transform);

			}
			if (my < 0 && Distance.y < 45) {
				Cam.transform.Translate (0, 120 * Time.deltaTime, 0);
				Cam.transform.LookAt (ScreenHeart.transform);
			}

		  // 紀錄攝影機旋轉完畢的新位置
		} else if( (Input.GetMouseButtonUp (0) || Input.GetMouseButtonUp (1)) && Global.IsCamCtrl && Global.StopTouch != true){
			CamToScreenHeart = CurrentCam.transform.position - ScreenHeart.transform.position;
		}

		// 抵銷攝影機旋轉的離心力
		if (Distance2 > 50) {
			Cam.transform.position = Vector3.Lerp (Cam.transform.position, ScreenHeart.transform.position, 0.01f);
		}

		if(SetCamPos == false)
		CamToScreenHeart = CurrentCam.transform.position - ScreenHeart.transform.position;

		// 主角移動至其他魔方時，設定攝影機位置
		if (SetCamPos == true) {
			ScreenHeart = GameObject.Find("ScreenHeart" + Global.OnCubeNum);
			CurrentCam.transform.position = Vector3.Lerp (CurrentCam.transform.position, ScreenHeart.transform.position + CamToScreenHeart, 0.15f);
			Global.StopTouch = true;
			if (Vector3.Distance(CurrentCam.transform.position, ScreenHeart.transform.position + CamToScreenHeart) < 0.1f) {
				CurrentCam.transform.position = ScreenHeart.transform.position + CamToScreenHeart;
				Global.StopTouch = false;
				SetCamPos = false;
			}
		}

	}

}
