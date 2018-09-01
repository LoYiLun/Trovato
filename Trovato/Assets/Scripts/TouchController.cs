using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	public GameObject Arrow;
	private GameObject TemptCube;
	private Material OriginMaterial;

	private float CamRollSpeed = 3;

	public GameObject GuideBall;
	GameObject[] TemptGuideBall = new GameObject[256];
	int k = 0;

	bool IsRightClick;

	void Awake(){

	}

	void Start () {
		OriginMaterial = Resources.Load ("Materials/Yellow", typeof(Material)) as Material;
		Global.IsCamCtrl = false;
		Global.StopTouch = false;

	}

	void PathFinding(){


		// Method A
		/*
		foreach (GameObject Balls in TemptGuideBall) {
			Destroy (Balls);
		}

		TemptGuideBall = new GameObject[256];
		k = 0;

		for (int i = -8; i < 8; i++) {
			for (int j = -8; j < 8; j++) {
				TemptGuideBall[k] = Instantiate (GuideBall, Global.Player.transform.position + new Vector3(i,0,j), Quaternion.identity);
				k++;
			}
		}*/

		// Method B
		/*
		for(int i=0 ; i<4 ; i++){
			TemptGuideBall[i] = Instantiate (GuideBall, Global.Player.transform.position, Quaternion.identity);
			TemptGuideBall [i].transform.Rotate (0, i*90, 0);
		}
		Global.NextTarget = TemptGuideBall [0];
		*/
	}
		
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
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
			Global.BeTouchedObj.GetComponent<Renderer> ().enabled = true;

			PathFinding ();

			if (Global.Player.activeSelf) 
			{
				Global.PlayerMove = true;
				Global.Status.text = "移動中";
			}
		} 


		// 按著滑鼠右鍵，只偵測Layer9的CubeFunction(轉動之壁)
		if (Input.GetMouseButton (1) && Physics.Raycast (ray, out hitInfo, 500, 1 << 9) && Global.IsCamCtrl != true && Global.StopTouch != true) {
			Debug.DrawLine (Camera.main.transform.position, hitInfo.transform.position, Color.blue, 0.1f, true);
			Global.BeTouchedCube = hitInfo.collider.gameObject;
			Global.BePointedObj = hitInfo.collider.gameObject;



			// 判定轉動方位，a1~a4代表上下左右的轉動方向
			// RotateNum的正負值分別表示V3魔方與V2魔方
			if (Global.IsRotating != true && Global.PlayerMove != true) {
				if (Global.BeTouchedCube.name == "a1") 
				{
					switch(TemptCube.name){
					case"PL1":
					case"PL2":
					case"PL3":
						Global.RotateNum = 15;
						break;

					case"PL4":
					case"PL6":
					case"PL7":
						Global.RotateNum = 14;
						break;

					case"PL5":
					case"PL8":
					case"PL9":
						Global.RotateNum = 13;
						break;

					case"PR1":
					case"PR2":
					case"PR3":
						Global.RotateNum = 4;
						break;
					
					case"PR4":
					case"PR6":
					case"PR7":
						Global.RotateNum = 5;
						break;
					
					case"PR5":
					case"PR8":
					case"PR9":
						Global.RotateNum = 6;
						break;

					case"PD1":
					case"PD2":
					case"PD3":
						Global.RotateNum = 1;
						break;

					case"PD4":
					case"PD5":
					case"PD6":
						Global.RotateNum = 2;
						break;

					case"PD7":
					case"PD8":
					case"PD9":
						Global.RotateNum = 3;
						break;

					case"V2_PL1":
					case"V2_PL2":
						Global.RotateNum = -10;
						break;

					case"V2_PL3":
					case"V2_PL4":
						Global.RotateNum = -9;
						break;
					
					case"V2_PR1":
					case"V2_PR2":
						Global.RotateNum = -3;
						break;
					
					case"V2_PR3":
					case"V2_PR4":
						Global.RotateNum = -4;
						break;

					case"V2_PD1":
					case"V2_PD2":
						Global.RotateNum = -1;
						break;

					case"V2_PD3":
					case"V2_PD4":
						Global.RotateNum = -2;
						break;
					}
						
					Global.ClickRotate ();
					Arrow.transform.position = new Vector3 (100, 100, 100);

				} 
				else if (Global.BeTouchedCube.name == "a2") {

					switch (TemptCube.name) {
					case"PL1":
					case"PL2":
					case"PL3":
						Global.RotateNum = 4;
						break;

					case"PL4":
					case"PL6":
					case"PL7":
						Global.RotateNum = 5;
						break;

					case"PL5":
					case"PL8":
					case"PL9":
						Global.RotateNum = 6;
						break;

					case"PR1":
					case"PR2":
					case"PR3":
						Global.RotateNum = 15;
						break;

					case"PR4":
					case"PR6":
					case"PR7":
						Global.RotateNum = 14;
						break;

					case"PR5":
					case"PR8":
					case"PR9":
						Global.RotateNum = 13;
						break;

					case"PD1":
					case"PD2":
					case"PD3":
						Global.RotateNum = 12;
						break;

					case"PD4":
					case"PD5":
					case"PD6":
						Global.RotateNum = 11;
						break;

					case"PD7":
					case"PD8":
					case"PD9":
						Global.RotateNum = 10;
						break;

					case"V2_PL1":
					case"V2_PL2":
						Global.RotateNum = -3;
						break;

					case"V2_PL3":
					case"V2_PL4":
						Global.RotateNum = -4;
						break;

					case"V2_PR1":
					case"V2_PR2":
						Global.RotateNum = -10;
						break;

					case"V2_PR3":
					case"V2_PR4":
						Global.RotateNum = -9;
						break;

					case"V2_PD1":
					case"V2_PD2":
						Global.RotateNum = -8;
						break;

					case"V2_PD3":
					case"V2_PD4":
						Global.RotateNum = -7;
						break;
					}

					Global.ClickRotate ();
					Arrow.transform.position = new Vector3 (100, 100, 100);

				}
				else if (Global.BeTouchedCube.name == "a3") {

					switch (TemptCube.name) {
					case"PL1":
					case"PL6":
					case"PL9":
						Global.RotateNum = 1;
						break;

					case"PL2":
					case"PL7":
					case"PL8":
						Global.RotateNum = 2;
						break;

					case"PL3":
					case"PL4":
					case"PL5":
						Global.RotateNum = 3;
						break;

					case"PR3":
					case"PR4":
					case"PR5":
						Global.RotateNum = 16;
						break;

					case"PR2":
					case"PR7":
					case"PR8":
						Global.RotateNum = 17;
						break;

					case"PR1":
					case"PR6":
					case"PR9":
						Global.RotateNum = 18;
						break;

					case"PD1":
					case"PD4":
					case"PD7":
						Global.RotateNum = 9;
						break;

					case"PD2":
					case"PD5":
					case"PD8":
						Global.RotateNum = 8;
						break;

					case"PD3":
					case"PD6":
					case"PD9":
						Global.RotateNum = 7;
						break;

					case"V2_PL1":
					case"V2_PL4":
						Global.RotateNum = -1;
						break;

					case"V2_PL2":
					case"V2_PL3":
						Global.RotateNum = -2;
						break;

					case"V2_PR1":
					case"V2_PR4":
						Global.RotateNum = -12;
						break;

					case"V2_PR2":
					case"V2_PR3":
						Global.RotateNum = -11;
						break;

					case"V2_PD1":
					case"V2_PD3":
						Global.RotateNum = -6;
						break;

					case"V2_PD2":
					case"V2_PD4":
						Global.RotateNum = -5;
						break;
					
					}

					Global.ClickRotate ();
					Arrow.transform.position = new Vector3 (100, 100, 100);

				}
				else if (Global.BeTouchedCube.name == "a4") {

					switch (TemptCube.name) {
					case"PL1":
					case"PL6":
					case"PL9":
						Global.RotateNum = 12;
						break;

					case"PL2":
					case"PL7":
					case"PL8":
						Global.RotateNum = 11;
						break;

					case"PL3":
					case"PL4":
					case"PL5":
						Global.RotateNum = 10;
						break;

					case"PR1":
					case"PR6":
					case"PR9":
						Global.RotateNum = 7;
						break;

					case"PR2":
					case"PR7":
					case"PR8":
						Global.RotateNum = 8;
						break;

					case"PR3":
					case"PR4":
					case"PR5":
						Global.RotateNum = 9;
						break;

					case"PD1":
					case"PD4":
					case"PD7":
						Global.RotateNum = 16;
						break;

					case"PD2":
					case"PD5":
					case"PD8":
						Global.RotateNum = 17;
						break;

					case"PD3":
					case"PD6":
					case"PD9":
						Global.RotateNum = 18;
						break;

					case"V2_PL1":
					case"V2_PL4":
						Global.RotateNum = -8;
						break;

					case"V2_PL2":
					case"V2_PL3":
						Global.RotateNum = -7;
						break;

					case"V2_PR1":
					case"V2_PR4":
						Global.RotateNum = -5;
						break;

					case"V2_PR2":
					case"V2_PR3":
						Global.RotateNum = -6;
						break;

					case"V2_PD1":
					case"V2_PD3":
						Global.RotateNum = -11;
						break;

					case"V2_PD2":
					case"V2_PD4":
						Global.RotateNum = -12;
						break;
					}

					Global.ClickRotate ();
					Arrow.transform.position = new Vector3 (100, 100, 100);

				}
			}
		}





		// 點選滑鼠右鍵
		if (Input.GetMouseButtonDown (1) && Global.IsRotating != true && Global.PlayerMove != true && Global.IsCamCtrl != true) 
		{
			if (Global.BeTouchedCube != null) 
			{
				Arrow.transform.position = Global.BeTouchedCube.transform.position;
				for (int i = 0; i < 4; i++) {
					Arrow.transform.GetChild (i).GetComponent<Renderer> ().enabled = true;
				}
				TemptCube = Global.BeTouchedCube;
				Global.BeTouchedCube.GetComponent<Renderer> ().material = OriginMaterial;
				Arrow.transform.rotation = Global.BeTouchedCube.transform.rotation;
				Global.Status.text = "選擇轉動方向";
			}
		}



		// 放開滑鼠右鍵
		if (Input.GetMouseButtonUp (1) && Global.StopTouch != true) 
		{
			IsRightClick = false;
			Arrow.transform.position = new Vector3 (100, 100, 100);
			for (int i = 0; i < 4; i++) {
				Arrow.transform.GetChild (i).GetComponent<Renderer> ().enabled = false;
			}
			Global.BeTouchedCube = GameObject.Find("VeryFarPosition");
			if(Global.PlayerMove == false)
				Global.Status.text = "正常";
		}


		// 轉六面
		/*
		Ray RotateRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit RotateHitInfo;

		if(Input.GetMouseButton (1) && Global.StopTouch != true && Global.IsCamCtrl != true && Global.IsRotating != true && Global.PlayerMove != true){
			if (Physics.Raycast (RotateRay, out RotateHitInfo, 500, 1 << 12)) {
				Global.RotateArrow = RotateHitInfo.collider.gameObject;
			}
		}
		
		if (Input.GetMouseButtonDown (1) && Global.StopTouch != true && Global.IsCamCtrl != true && Global.IsRotating != true && Global.PlayerMove != true) {

			IsRightClick = true;

			if(Physics.Raycast (RotateRay, out RotateHitInfo, 500, 1 << 9))
				Global.RotatePlane = RotateHitInfo.collider.gameObject;
			
			if (Physics.Raycast (RotateRay, out RotateHitInfo, 500, 1 << 11)) {
				Global.RotateCube = RotateHitInfo.collider.gameObject;
				for (int i = 0; i < 4; i++)
					Arrow.transform.GetChild (i).GetComponent<Renderer> ().enabled = true;
				Arrow.transform.position = Global.RotateCube.transform.position;
				Arrow.transform.rotation = Global.RotatePlane.transform.rotation;
				Arrow.transform.Translate (1.5f, 0, 0);
			}
		}*/




	}
}
