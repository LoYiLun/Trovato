using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControllerV2 : MonoBehaviour {

	public GameObject cam;
	public GameObject camObj;
	public GameObject screenHeart;
	public GameObject rotateGoal;

	public static GameObject currentHeart;
	public static GameObject currentCam;
	public static float camView;
	//public static bool IsCamRotating;

	private Vector3 camToScreenHeartOrigin;
	private Vector3 camToScreenHeart;
	private Vector3 camOriginPos;
	private Quaternion camOriginRot;
	private int viewTime = 9;
	private float mouseX, mouseY;
	private float distance;
	private float rotateSpeed = 0.4f;
	private bool isCamRotating;
	private bool isFollowing;

	private bool isLookingAround;
	private bool lookAround{get{ return MissionSetting.FlowerChart != null ? MissionSetting.FlowerChart.GetBooleanVariable ("LookAround") : false ;}}

	void Awake () {
		currentCam = cam;
		currentHeart = screenHeart;
		camToScreenHeartOrigin = camObj.transform.position - screenHeart.transform.position;
		camView = Camera.main.fieldOfView;
		rotateGoal.transform.position = cam.transform.position;
		cam.transform.rotation = Quaternion.LookRotation (camObj.transform.position - camToScreenHeartOrigin - cam.transform.position, screenHeart.transform.up);
		camOriginPos = cam.transform.position;
		camOriginRot = cam.transform.rotation;
	}
	

	void Update () {

		mouseX = Input.GetAxis ("Mouse X") ;
		mouseY = Input.GetAxis ("Mouse Y") ;
		camToScreenHeart = camObj.transform.position - screenHeart.transform.position;
		distance = Vector3.Distance (cam.transform.position, screenHeart.transform.position);

		if (lookAround) {
			//Global.StopTouch = true;
			cam.transform.RotateAround (screenHeart.transform.position, Vector3.up, Mathf.Clamp(0.2f + Vector3.Distance (cam.transform.position, camOriginPos)/50,0 ,1.25f));
			if (Vector3.Distance (cam.transform.position, camOriginPos) > 0.5f && !isLookingAround) {
				isLookingAround = true;
			} else if (Vector3.Distance (cam.transform.position, camOriginPos) <= 0.5f && isLookingAround) {
				cam.transform.transform.position = camOriginPos;
				cam.transform.LookAt (screenHeart.transform);
				isLookingAround = false;
				MissionSetting.FlowerChart.SetBooleanVariable ("LookAround", false);
				//LookAround = false;
			}
		}

		if (!Global.IsPreRotating && !Global.IsRotating && !MissionSetting.CamIsMoving && !MissionSetting.CamIsMovingBack) {
			follow (25);
			checkRightClick ();
			if (Vector3.Distance (cam.transform.position, rotateGoal.transform.position) > 0.1f) {
				cam.transform.position = Vector3.Lerp (cam.transform.position, rotateGoal.transform.position, rotateSpeed);
				cam.transform.rotation = Quaternion.LookRotation (camObj.transform.position - camToScreenHeartOrigin - cam.transform.position, screenHeart.transform.up);
			}
		}
		if(camView != Camera.main.fieldOfView)
			Camera.main.fieldOfView -= (Camera.main.fieldOfView - camView) / viewTime;
		if (Input.GetAxis ("Mouse ScrollWheel") != 0)
			zoom ();

	}

	public void checkRightClick(){
		if (Input.GetMouseButtonDown (1))
			rotateSpeed /= 1.2f;
		if (Input.GetMouseButton (1) && Global.IsCamCtrl && !Global.IsPreRotating && !Global.IsRotating)
			rotate ();
		else if (Input.GetMouseButtonUp (1))
			rotateSpeed *= 1.2f;
	}

	public void follow(int time){
		camObj.transform.position += ((screenHeart.transform.position + camToScreenHeartOrigin) - camObj.transform.position) / time;
	}

	public void rotate(){


		// 左右
		if (mouseX > 0) {
			rotateGoal.transform.Translate (-120 * Time.deltaTime, 0, 0);
			rotateGoal.transform.position -= Vector3.forward * Time.deltaTime;
			rotateGoal.transform.rotation = Quaternion.LookRotation (camObj.transform.position - camToScreenHeartOrigin - rotateGoal.transform.position, screenHeart.transform.up);
		}
		if (mouseX < 0) {
			rotateGoal.transform.Translate (120 * Time.deltaTime, 0, 0);
			rotateGoal.transform.position += Vector3.forward * Time.deltaTime;
			rotateGoal.transform.rotation = Quaternion.LookRotation (camObj.transform.position - camToScreenHeartOrigin - rotateGoal.transform.position, screenHeart.transform.up);
		}

		// 上下
		if (mouseY > 0 && (rotateGoal.transform.position - screenHeart.transform.position).y > -45) {
			rotateGoal.transform.Translate (0, -120 * Time.deltaTime, 0);
			rotateGoal.transform.rotation = Quaternion.LookRotation (camObj.transform.position - camToScreenHeartOrigin - rotateGoal.transform.position, screenHeart.transform.up);
		}
		if (mouseY < 0 && (rotateGoal.transform.position - screenHeart.transform.position).y < 45) {
			rotateGoal.transform.Translate (0, 120 * Time.deltaTime, 0);
			rotateGoal.transform.rotation = Quaternion.LookRotation (camObj.transform.position - camToScreenHeartOrigin - rotateGoal.transform.position, screenHeart.transform.up);
		}

		// 抵銷攝影機旋轉的離心力
		if (distance > 50)
			rotateGoal.transform.position = Vector3.Lerp (rotateGoal.transform.position, screenHeart.transform.position, 0.01f);
	}

	public void zoom(){
		if (!Global.StopTouch && !Global.IsPreRotating && !Global.IsRotating && !MissionSetting.CamIsMoving && !MissionSetting.CamIsMovingBack) {
			if (Input.GetAxis ("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView < 25) {
				camView += 2f;
				camView = Mathf.Clamp (camView, 5, 25);
			} else if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView > 5) {
				camView -= 2f;
				camView = Mathf.Clamp (camView, 5, 25);
			}
		}
	}
}
