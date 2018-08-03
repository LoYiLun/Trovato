using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_PlayerMove : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}

	public void StopPlayerMove()
	{
		if (Global.StopTouch)
			Global.StopTouch = false;
		else
			Global.StopTouch = true;
	}
}
