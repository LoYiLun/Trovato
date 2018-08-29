using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ScrewPlatform : MonoBehaviour {

	Transform Rotation;
	float Speed = 0.03f;
	float Height;
	Vector2 VHeight;


	void Start () 
	{
		//Rotation = gameObject.transform;




	}
	

	void Update () 
	{
		
		Height = gameObject.transform.localPosition.y;
		if (Global.RotateNum == 3 && Height < 0) 
		{
			gameObject.transform.Translate(0, Speed, 0);
			//Rotation.Rotate (new Vector3 (0, 10, 0));
		} 
		else if (Global.RotateNum == 10 && Height > -1.2f) 
		{
			gameObject.transform.Translate(0, -Speed, 0);
			//Rotation.Rotate (new Vector3 (0, -10, 0));
		}


	}

}
