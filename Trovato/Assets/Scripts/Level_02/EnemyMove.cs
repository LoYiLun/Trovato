using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	float Speed = 0.03f;
	float Dis;
	Vector3 Pos;
	int i = 0;
	public GameObject[] Patrols = new GameObject[4];


	void Start () {
		Pos = Patrols[i].transform.position;
		i++;

	}


	void FixedUpdate () {
		

		if (!Global.IsPreRotating && !Global.IsRotating && GameObject.Find("GlobalScripts").GetComponent<MissionSetting>() != null && !MissionSetting.BlockOn && !MissionSetting.CamIsMoving && !MissionSetting.CamIsMovingBack) {
			transform.Translate (Speed, 0, 0);
			Dis = Vector3.Distance (transform.position, Pos);
			if (Dis >= 1) {
				transform.position = Patrols [i].transform.position;
				transform.Rotate (0, 90, 0);
				Pos = Patrols[i].transform.position;
				i++;
				i %= 4;
				Dis = 0;
			}
		}
	}
}
