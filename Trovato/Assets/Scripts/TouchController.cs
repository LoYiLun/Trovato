using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	GameObject Arrow;
	GameObject GuideBall;
	GameObject TemptCube;
	GameObject TargetLight;
	bool IsRightClick;

	string[] RotateNumBox = new string[2];
	string Box;


	[SerializeField]
	GameObject ArrowPrefab;

	void Awake(){

	}

	void Start () {
		Arrow = Instantiate (ArrowPrefab);
		Global.IsCamCtrl = false;
		Global.StopTouch = false;

	}

		
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit RotateHitInfo;
		RaycastHit RotateHitInfo2;
		RaycastHit hitInfo;

		// 點選滑鼠左鍵，只偵測Layer10的Floor
		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hitInfo, 500, 1 << 10) && Global.StopTouch != true && Global.IsCamCtrl != true && IsRightClick != true) 
		{
			Debug.DrawLine (Camera.main.transform.position, hitInfo.transform.position, Color.yellow, 0.1f, true);
			if (Global.BeTouchedObj.tag == "Floor") 
			{
				Global.BeTouchedObj.GetComponent<Renderer> ().enabled = false;

			}

			// 切換成新點選的物件
			Global.BeTouchedObj = hitInfo.collider.gameObject;
			if(Global.BeTouchedObj.GetComponent<Renderer>() != null)
			Global.BeTouchedObj.GetComponent<Renderer> ().enabled = true;
			Global.Targetlight.Stop ();
			Global.Targetlight.transform.position = Global.BeTouchedObj.transform.position;
			Global.Targetlight.Play ();

			if (Global.Player.activeSelf) 
			{
				Global.Wait = true;
				Global.PlayerMove = true;
				Global.Status.text = "移動中";
			}
		} 



		if (Input.GetMouseButtonDown (1) && Global.StopTouch != true && Global.IsCamCtrl != true && Global.IsRotating != true && Global.PlayerMove != true && Global.IsPushing != true) {

			IsRightClick = true;
			// BigPlane
			if (Physics.Raycast (ray, out RotateHitInfo, 500, 1 << 9)) {
				Global.RotatePlane = RotateHitInfo.collider.gameObject;
				RotateNumBox [0] = Global.RotatePlane.name;
				for (int i = 0; i < 4; i++)
					Arrow.transform.GetChild (i).GetComponent<Renderer> ().enabled = true;
				Arrow.transform.position = Global.RotatePlane.transform.position;
				Arrow.transform.rotation = Global.RotatePlane.transform.rotation;
				Global.Status.text = "選擇轉動方向";
			}

			// Cube
			if (Physics.Raycast (ray, out RotateHitInfo2, 500, 1 << 11)) {
				Global.RotateCube = RotateHitInfo2.collider.gameObject;
			}
		} else {
			if (Input.GetMouseButton (1) && Global.RotatePlane == null && Global.IsRotating == false) {
				Global.IsCamCtrl = true;
			} else {
				Global.IsCamCtrl = false;
			}
		}

		// 放開滑鼠右鍵
		if (Input.GetMouseButtonUp (1) && Global.StopTouch != true) 
		{
			IsRightClick = false;
			Global.RotatePlane = null;
			Arrow.transform.position = new Vector3 (100, 100, 100);
			for (int i = 0; i < 4; i++) {
				Arrow.transform.GetChild (i).GetComponent<Renderer> ().enabled = false;
			}
			if(Global.PlayerMove == false)
				Global.Status.text = "正常";
		}





		// Arrow
		if(Input.GetMouseButton (1) && Global.StopTouch != true && Global.IsCamCtrl != true && Global.IsRotating != true && Global.PlayerMove != true && Global.IsPushing != true){

			if (Physics.Raycast (ray, out RotateHitInfo, 500, 1 << 12)) {
				Global.RotateArrow = RotateHitInfo.collider.gameObject;
				if (Global.RotateArrow.name == "a1")
					RotateNumBox [1] = "w";
				if (Global.RotateArrow.name == "a2")
					RotateNumBox [1] = "s";
				if (Global.RotateArrow.name == "a3")
					RotateNumBox [1] = "a";
				if (Global.RotateArrow.name == "a4")
					RotateNumBox [1] = "d";

				SetRotateNum ();
			}
		}



	}

	void SetRotateNum(){
		Box = RotateNumBox [0] + RotateNumBox [1];

		switch (Box) {

		case"V2A3w":
		case"V2A4w":
		case"V2B3w":
		case"V2B4w":
		case"V2D3w":
		case"V2D4w":
		case"V2F3s":
		case"V2F4s":
			Global.RotateNum = -1;
			break;

		case"V2A1w":
		case"V2A2w":
		case"V2B1w":
		case"V2B2w":
		case"V2D1w":
		case"V2D2w":
		case"V2F1s":
		case"V2F2s":
			Global.RotateNum = -2;
			break;

		case"V2B1d":
		case"V2B3d":
		case"V2C1w":
		case"V2C3w":
		case"V2D1a":
		case"V2D3a":
		case"V2E1s":
		case"V2E3s":
			Global.RotateNum = -3;
			break;

		case"V2B2d":
		case"V2B4d":
		case"V2C2w":
		case"V2C4w":
		case"V2D2a":
		case"V2D4a":
		case"V2E2s":
		case"V2E4s":
			Global.RotateNum = -4;
			break;

		case"V2A2d":
		case"V2A4d":
		case"V2C3d":
		case"V2C4d":
		case"V2E3d":
		case"V2E4d":
		case"V2F2d":
		case"V2F4d":
			Global.RotateNum = -5;
			break;

		case"V2A1d":
		case"V2A3d":
		case"V2C1d":
		case"V2C2d":
		case"V2E1d":
		case"V2E2d":
		case"V2F1d":
		case"V2F3d":
			Global.RotateNum = -6;
			break;

		case"V2A1s":
		case"V2A2s":
		case"V2B1s":
		case"V2B2s":
		case"V2D1s":
		case"V2D2s":
		case"V2F1w":
		case"V2F2w":
			Global.RotateNum = -7;
			break;

		case"V2A3s":
		case"V2A4s":
		case"V2B3s":
		case"V2B4s":
		case"V2D3s":
		case"V2D4s":
		case"V2F3w":
		case"V2F4w":
			Global.RotateNum = -8;
			break;

		case"V2B2a":
		case"V2B4a":
		case"V2C2s":
		case"V2C4s":
		case"V2D2d":
		case"V2D4d":
		case"V2E2w":
		case"V2E4w":
			Global.RotateNum = -9;
			break;

		case"V2B1a":
		case"V2B3a":
		case"V2C1s":
		case"V2C3s":
		case"V2D1d":
		case"V2D3d":
		case"V2E1w":
		case"V2E3w":
			Global.RotateNum = -10;
			break;

		case"V2A1a":
		case"V2A3a":
		case"V2C1a":
		case"V2C2a":
		case"V2E1a":
		case"V2E2a":
		case"V2F1a":
		case"V2F3a":
			Global.RotateNum = -11;
			break;

		case"V2A2a":
		case"V2A4a":
		case"V2C3a":
		case"V2C4a":
		case"V2E3a":
		case"V2E4a":
		case"V2F2a":
		case"V2F4a":
			Global.RotateNum = -12;
			break;

			// V3

		case"V3A7w":
		case"V3A8w":
		case"V3A9w":
		case"V3B7w":
		case"V3B8w":
		case"V3B9w":
		case"V3D7w":
		case"V3D8w":
		case"V3D9w":
		case"V3F7s":
		case"V3F8s":
		case"V3F9s":
			Global.RotateNum = 1;
			break;

		case"V3A4w":
		case"V3A5w":
		case"V3A6w":
		case"V3B4w":
		case"V3B5w":
		case"V3B6w":
		case"V3D4w":
		case"V3D5w":
		case"V3D6w":
		case"V3F4s":
		case"V3F5s":
		case"V3F6s":
			Global.RotateNum = 2;
			break;

		case"V3A1w":
		case"V3A2w":
		case"V3A3w":
		case"V3B1w":
		case"V3B2w":
		case"V3B3w":
		case"V3D1w":
		case"V3D2w":
		case"V3D3w":
		case"V3F1s":
		case"V3F2s":
		case"V3F3s":
			Global.RotateNum = 3;
			break;

		case"V3B1d":
		case"V3B4d":
		case"V3B7d":
		case"V3C1w":
		case"V3C4w":
		case"V3C7w":
		case"V3D1a":
		case"V3D4a":
		case"V3D7a":
		case"V3E1s":
		case"V3E4s":
		case"V3E7s":
			Global.RotateNum = 4;
			break;

		case"V3B2d":
		case"V3B5d":
		case"V3B8d":
		case"V3C2w":
		case"V3C5w":
		case"V3C8w":
		case"V3D2a":
		case"V3D5a":
		case"V3D8a":
		case"V3E2s":
		case"V3E5s":
		case"V3E8s":
			Global.RotateNum = 5;
			break;

		case"V3B3d":
		case"V3B6d":
		case"V3B9d":
		case"V3C3w":
		case"V3C6w":
		case"V3C9w":
		case"V3D3a":
		case"V3D6a":
		case"V3D9a":
		case"V3E3s":
		case"V3E6s":
		case"V3E9s":
			Global.RotateNum = 6;
			break;

		case"V3A3d":
		case"V3A6d":
		case"V3A9d":
		case"V3C7d":
		case"V3C8d":
		case"V3C9d":
		case"V3E7d":
		case"V3E8d":
		case"V3E9d":
		case"V3F3d":
		case"V3F6d":
		case"V3F9d":
			Global.RotateNum = 7;
			break;

		case"V3A2d":
		case"V3A5d":
		case"V3A8d":
		case"V3C4d":
		case"V3C5d":
		case"V3C6d":
		case"V3E4d":
		case"V3E5d":
		case"V3E6d":
		case"V3F2d":
		case"V3F5d":
		case"V3F8d":
			Global.RotateNum = 8;
			break;

		case"V3A1d":
		case"V3A4d":
		case"V3A7d":
		case"V3C1d":
		case"V3C2d":
		case"V3C3d":
		case"V3E1d":
		case"V3E2d":
		case"V3E3d":
		case"V3F1d":
		case"V3F4d":
		case"V3F7d":
			Global.RotateNum = 9;
			break;

		case"V3A1s":
		case"V3A2s":
		case"V3A3s":
		case"V3B1s":
		case"V3B2s":
		case"V3B3s":
		case"V3D1s":
		case"V3D2s":
		case"V3D3s":
		case"V3F1w":
		case"V3F2w":
		case"V3F3w":
			Global.RotateNum = 10;
			break;

		case"V3A4s":
		case"V3A5s":
		case"V3A6s":
		case"V3B4s":
		case"V3B5s":
		case"V3B6s":
		case"V3D4s":
		case"V3D5s":
		case"V3D6s":
		case"V3F4w":
		case"V3F5w":
		case"V3F6w":
			Global.RotateNum = 11;
			break;

		case"V3A7s":
		case"V3A8s":
		case"V3A9s":
		case"V3B7s":
		case"V3B8s":
		case"V3B9s":
		case"V3D7s":
		case"V3D8s":
		case"V3D9s":
		case"V3F7w":
		case"V3F8w":
		case"V3F9w":
			Global.RotateNum = 12;
			break;

		case"V3B3a":
		case"V3B6a":
		case"V3B9a":
		case"V3C3s":
		case"V3C6s":
		case"V3C9s":
		case"V3D3d":
		case"V3D6d":
		case"V3D9d":
		case"V3E3w":
		case"V3E6w":
		case"V3E9w":
			Global.RotateNum = 13;
			break;

		case"V3B2a":
		case"V3B5a":
		case"V3B8a":
		case"V3C2s":
		case"V3C5s":
		case"V3C8s":
		case"V3D2d":
		case"V3D5d":
		case"V3D8d":
		case"V3E2w":
		case"V3E5w":
		case"V3E8w":
			Global.RotateNum = 14;
			break;

		case"V3B1a":
		case"V3B4a":
		case"V3B7a":
		case"V3C1s":
		case"V3C4s":
		case"V3C7s":
		case"V3D1d":
		case"V3D4d":
		case"V3D7d":
		case"V3E1w":
		case"V3E4w":
		case"V3E7w":
			Global.RotateNum = 15;
			break;

		case"V3A1a":
		case"V3A4a":
		case"V3A7a":
		case"V3C1a":
		case"V3C2a":
		case"V3C3a":
		case"V3E1a":
		case"V3E2a":
		case"V3E3a":
		case"V3F1a":
		case"V3F4a":
		case"V3F7a":
			Global.RotateNum = 16;
			break;

		case"V3A2a":
		case"V3A5a":
		case"V3A8a":
		case"V3C4a":
		case"V3C5a":
		case"V3C6a":
		case"V3E4a":
		case"V3E5a":
		case"V3E6a":
		case"V3F2a":
		case"V3F5a":
		case"V3F8a":
			Global.RotateNum = 17;
			break;

		case"V3A3a":
		case"V3A6a":
		case"V3A9a":
		case"V3C7a":
		case"V3C8a":
		case"V3C9a":
		case"V3E7a":
		case"V3E8a":
		case"V3E9a":
		case"V3F3a":
		case"V3F6a":
		case"V3F9a":
			Global.RotateNum = 18;
			break;
		}

		Global.ClickRotate ();
		Arrow.transform.position = new Vector3 (100, 100, 100);
	}
}
