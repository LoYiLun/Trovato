using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingArrow : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		if(Global.Level == "Menu")
			transform.Rotate (0, 2, 0);
		else
			transform.Rotate (0, 5, 0);
	}
}
