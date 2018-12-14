using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachController : MonoBehaviour {

	private GameObject Spotlight;

	void Awake(){
		Spotlight = GameObject.Find ("Image_Spotlight");
	}

	void Start () {
		
	}
	

	void Update () {
		Spotlight.transform.position = Input.mousePosition;
	}
}
