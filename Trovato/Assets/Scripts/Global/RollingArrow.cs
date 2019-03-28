using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingArrow : MonoBehaviour {

	private Vector3 pos;
	private bool stop;

	void Start () {
		pos = transform.position;
		transform.Translate (0, 1, 0);
	}
	

	void Update () {
		if (!stop) {
			if (Vector3.Distance (transform.position, pos) >= 0.5f)
				transform.Translate (0, -0.1f, 0);
			else
				stop = true;
		}

		if(Global.Level == "Menu")
			transform.Rotate (0, 2, 0);
		else
			transform.Rotate (0, 5, 0);
	}
}
