using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	public GameObject Arrow;
	private GameObject TemptCube;
	private Material OriginMaterial;

	void Start () {
		OriginMaterial = Resources.Load ("Materials/Yellow", typeof(Material)) as Material;

	}
		
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		// 點選滑鼠左鍵，只偵測Layer10的Floor
		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hitInfo, 500, 1 << 10) && Global.StopTouch != true) 
		{
			Debug.DrawLine (Camera.main.transform.position, hitInfo.transform.position, Color.yellow, 0.1f, true);
			if (Global.BeTouchedObj.tag == "Floor") 
			{
				Global.BeTouchedObj.GetComponent<Renderer> ().enabled = false;
			}

			// 切換成新點選的物件
			Global.BeTouchedObj = hitInfo.collider.gameObject;
			Global.BeTouchedObj.GetComponent<Renderer> ().enabled = true;
			if (Global.Player.activeSelf) 
			{
				Global.PlayerMove = true;
				Global.Status.text = "移動中";
			}
		} 

		// 按著滑鼠右鍵，只偵測Layer9的CubeFunction(轉動之壁)
		if (Input.GetMouseButton (1) && Physics.Raycast (ray, out hitInfo, 500, 1 << 9)) {
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
		if (Input.GetMouseButtonDown (1) && Global.IsRotating != true && Global.PlayerMove != true) 
		{
			if (Global.BeTouchedCube != null) 
			{
				Arrow.transform.position = Global.BeTouchedCube.transform.position;
				TemptCube = Global.BeTouchedCube;
				Global.BeTouchedCube.GetComponent<Renderer> ().material = OriginMaterial;
				Arrow.transform.rotation = Global.BeTouchedCube.transform.rotation;
				Global.Status.text = "選擇轉動方向";
			}
		}

		// 放開滑鼠右鍵
		if (Input.GetMouseButtonUp (1)) 
		{
			Arrow.transform.position = new Vector3 (100, 100, 100);
			Global.BeTouchedCube = GameObject.Find("VeryFarPosition");
			if(Global.PlayerMove == false)
				Global.Status.text = "正常";
		}
	}
}
