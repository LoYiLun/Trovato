using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Ring : MonoBehaviour {

	// 滑鼠座標
	float MouseX;
	int PlanetsCount = 4;

	GameObject Ring;
	GameObject SelectLight;
	public GameObject CurrentLevel;
	GameObject[] Planets = new GameObject[4];

	Quaternion RingDirection;

	public Vector3 PlanetDirection;

	void Awake(){

		Ring = GameObject.Find("Ring_of_Levels");
		SelectLight = GameObject.Find ("SelectLight");
		CurrentLevel = GameObject.Find ("Level_01");
		RingDirection = Quaternion.Euler (0, -20, 0);
	}

	void Start () {
		for (int i = 0; i < PlanetsCount; i++) {
			Planets [i] = Ring.transform.GetChild (i).gameObject;
		}
	}
	

	void Update () {

		// 滑鼠區 ----------------------
		MouseX = Input.GetAxis ("Mouse X") ;

		if (Input.GetMouseButton (1)) {
			Ring.transform.Rotate (0, -10 * MouseX, 0);
		} else if (Input.GetMouseButtonUp (1)) {
			switch (CurrentLevel.name) {
			case"Level_01":
				RingDirection = Quaternion.Euler (0, -20, 0);
				break;
			case"Level_02":
				RingDirection = Quaternion.Euler (0, 70, 0);
				break;
			case"Level_03":
				RingDirection = Quaternion.Euler (0, 160, 0);
				break;
			case"Level_04":
				RingDirection = Quaternion.Euler (0, 250, 0);
				break;
			}
		} else if (Input.GetMouseButton (1) == false) {
			Ring.transform.rotation = Quaternion.Lerp (Ring.transform.rotation, RingDirection, 0.1f);
		}


		// 偵測區 ----------------------
		foreach(GameObject planet in Planets){
			if (Vector3.Distance (planet.transform.position, SelectLight.transform.position) < 30) {
				CurrentLevel = planet;
			}
		}
	}
}
