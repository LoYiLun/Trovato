using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour {

	GameObject Arrow;
	GameObject TargetLight;
	bool IsRightClick;
	bool TouchOnce;

	public GameObject Star;
	GameObject[] stars = new GameObject[8];

	public Texture2D Hand1;
	public Texture2D Hand2;


	void Awake(){
		Star = GameObject.Find("UI_Star");
		Hand1 = Resources.Load ("Image/UI/cursor") as Texture2D;
		Hand2 = Resources.Load ("Image/UI/cursor2") as Texture2D;
	}

	void Start () {
		//Arrow = Instantiate (ArrowPrefab);
		//Global.IsCamCtrl = false;
		Global.StopTouch = false;
	}


	// 目的地地板動畫效果
	IEnumerator TouchEffect(GameObject TheFloor){
		for (float i=0; i < 10f; i += Time.deltaTime) {
			if (TheFloor.GetComponent<Renderer> () != null) {
				TheFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/touch0")as Material;
				yield return new WaitForSeconds (0.1f);
				TheFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/touch1")as Material;
				yield return new WaitForSeconds (0.2f);
				TheFloor.GetComponent<Renderer> ().material = Resources.Load ("Materials/Materials/touch2")as Material;
				yield return new WaitForSeconds (0.15f);
			}

			if (Global.PlayerMove == false) {
				yield break;
			}
		}
			


	}
		
	void Update () {

		/*
		if (Input.GetMouseButton (0)) {
			Cursor.SetCursor (Hand2, Vector2.zero, CursorMode.Auto);
		} else {
			Cursor.SetCursor (Hand1, Vector2.zero, CursorMode.Auto);
		}
*/

		if (Input.GetMouseButtonDown (0)) {
			foreach (GameObject allstars in stars) {
				Destroy (allstars);
			}

			for (int i = 0; i < 8; i++) {
				
				GameObject star = Instantiate (Star) as GameObject;
				star.transform.SetParent (Star.transform.parent.transform, false);
				star.GetComponent<Image> ().enabled = true;
				star.GetComponent<Image>().transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
				stars [i] = star;
				stars[i].transform.Rotate (0, 0, i * 45);
			}
		}

		if (stars[0] != null) {
			foreach (GameObject allstars in stars) {
				
				allstars.transform.Translate (0, 9f - Vector3.Distance (stars [0].transform.position, stars [1].transform.position)/10, 0);
				allstars.GetComponent<Image> ().color -= new Color(0, 0, 0, 0.05f);
				//allstars.GetComponent<Image> ().transform.Rotate (0, 0, 2);
			}
			if (Vector3.Distance (stars [0].transform.position, stars [1].transform.position) > 75) {
				foreach (GameObject allstars in stars) {
					Destroy (allstars);
				}

			}
		}


	}

}
