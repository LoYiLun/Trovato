using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLocation : MonoBehaviour {

	public int ID;
	public int CubeL;
	public int CubeR;
	public int CubeD;
	private int DX, DY, DZ;
	private float RotateSpeed = 120f;
	private float RotateTo90;
	private bool SetTeam;
	private bool StartRotate;
	private GameObject CubeHome;
	private GameObject CubeLeader;

	private bool ok;

	void Start () {
		CubeHome = GameObject.Find ("CubeHome");
		CubeLeader = GameObject.Find ("CubeLeader");
	}


	void Update () {
		if (Global.SetCubeTeam) {

			if (this.CubeD == 0 && Global.RotateNum == 4) {
				this.transform.parent = CubeLeader.transform;
				DX = 0;
				DY = -1;
				DZ = 0;
				if (CubeLeader.transform.childCount == 9) {
					Global.SetCubeTeam = false;
					StartRotate = true;
				}
			}

			if (this.CubeD == 0 && Global.RotateNum == -4) {
				this.transform.parent = CubeLeader.transform;
				DX = 0;
				DY = 1;
				DZ = 0;
				if (CubeLeader.transform.childCount == 9) {
					Global.SetCubeTeam = false;
					StartRotate = true;
				}
			}
		}

		if (StartRotate) {
			CubeLeader.transform.Rotate (new Vector3 (DX * RotateSpeed * Time.deltaTime, DY * RotateSpeed * Time.deltaTime, DZ * RotateSpeed * Time.deltaTime));
			RotateTo90 = Mathf.Abs (
				Mathf.Abs (CubeLeader.transform.eulerAngles.x) +
				Mathf.Abs (CubeLeader.transform.eulerAngles.y) +
				Mathf.Abs (CubeLeader.transform.eulerAngles.z) - 180);
		
			if (RotateTo90 >= 85 && RotateTo90 <= 95f) {
				CubeLeader.transform.rotation = Quaternion.Euler (DX * 90, DY * 90, DZ * 90);
				StartRotate = false;
			}}
	}
		

}
