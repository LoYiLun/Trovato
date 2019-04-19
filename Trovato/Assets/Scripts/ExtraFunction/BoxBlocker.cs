using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBlocker : MonoBehaviour {
	

	void Update () {
		if(Global.IsPushing){
			GetComponent<Collider>().enabled = true;
		}else{
			GetComponent<Collider>().enabled = false;
		}
	}
}
