using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraController : MonoBehaviour {

	public GameObject Cam;
	public GameObject CamObj;
	public Vector3 CamToScreenHeart;

	public GameObject ScreenHeart;
	public static bool SetCamPos;
	public static bool IsCamRotating;
	public static GameObject CurrentCam;
	public static GameObject CamTarget;

	// 滑鼠座標
	private float mx;
	private float my;

	// 鏡頭距離
	private float Close;
	private float Far;
	private Vector3 Distance;
	private float Distance2;
	private float ViewTime = 9;

	public static float OriginView;
	public static float CamView;

	//bool LookAround;
	private bool LookAround{get{ return MissionSetting.FlowerChart != null ? MissionSetting.FlowerChart.GetBooleanVariable ("LookAround") : false ;}}
	private bool IsLookingAround;
	public static Vector3 CamOriginPos;
	public static Quaternion CamOriginRot;

	void Awake(){
		CurrentCam = Cam;
		CamOriginPos = CurrentCam.transform.position;
		CamOriginRot = CurrentCam.transform.rotation;


	}

	void Start () {
		CamToScreenHeart = CurrentCam.transform.position - ScreenHeart.transform.position;
		CamTarget = ScreenHeart;
		CurrentCam.transform.LookAt (CamTarget.transform);
		CamView = Camera.main.fieldOfView;
	}

	void Update () {

		// 關卡開場時的環視魔方
		//LookAround = Input.GetKeyDown (KeyCode.Z) ? !LookAround : LookAround;
		if (LookAround) {
			//Global.StopTouch = true;
			CurrentCam.transform.RotateAround (ScreenHeart.transform.position, Vector3.up, Mathf.Clamp(0.2f + Vector3.Distance (CurrentCam.transform.position, CamOriginPos)/50,0 ,1.25f));
			if (Vector3.Distance (CurrentCam.transform.position, CamOriginPos) > 0.5f && !IsLookingAround) {
				IsLookingAround = true;
			} else if (Vector3.Distance (CurrentCam.transform.position, CamOriginPos) <= 0.5f && IsLookingAround) {
				CurrentCam.transform.transform.position = CamOriginPos;
				CurrentCam.transform.LookAt (CamTarget.transform);
				IsLookingAround = false;
				MissionSetting.FlowerChart.SetBooleanVariable ("LookAround", false);
				//LookAround = false;
			}
		}

		mx = Input.GetAxis ("Mouse X") ;
		my = Input.GetAxis ("Mouse Y") ;

		Distance = CurrentCam.transform.position - ScreenHeart.transform.position;
		Distance2 = Vector3.Distance (CurrentCam.transform.position, ScreenHeart.transform.position);




			Camera.main.fieldOfView -= (Camera.main.fieldOfView - CamView) / ViewTime;

			if (Mathf.Abs (Camera.main.fieldOfView - CamView) <= 1f) {
				//Camera.main.fieldOfView = CamView;
			}

		if (!Global.StopTouch && !Global.IsPreRotating && !Global.IsRotating) {
			if (Input.GetAxis ("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView < 25) {
				CamView += 2f;
				CamView = Mathf.Clamp (CamView, 5, 25);
			} else if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView > 5) {
				CamView -= 2f;
				CamView = Mathf.Clamp (CamView, 5, 25);
			}
		}

		// 控制攝影機旋轉視角
		if ((Input.GetMouseButton (1)) && Global.IsCamCtrl && Global.StopTouch != true && !Global.IsRotating && !Global.IsPreRotating && !Global.PlayerMove && !MissionSetting.CamIsMoving && !MissionSetting.CamIsMovingBack ) {
			IsCamRotating = true;

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
		} else if(!Input.GetMouseButton(1) && Global.StopTouch != true && !Global.IsRotating && !Global.IsPreRotating){
			IsCamRotating = false;
			CamToScreenHeart = CurrentCam.transform.position - ScreenHeart.transform.position;
		}

		// 抵銷攝影機旋轉的離心力
		if ((Input.GetMouseButton (1)) && Distance2 > 50) {
			Cam.transform.position = Vector3.Lerp (Cam.transform.position, ScreenHeart.transform.position, 0.01f);
		}

		if(SetCamPos == false)
		CamToScreenHeart = CurrentCam.transform.position - ScreenHeart.transform.position;

		// 主角移動至其他魔方時，設定攝影機位置
		if (SetCamPos == true) {
			CamTarget = ScreenHeart = GameObject.Find("ScreenHeart" + Global.OnCubeNum);
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
