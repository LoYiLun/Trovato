using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour {

	public int ID;
	public int CubeL;
	public int CubeR;
	public int CubeD;
	private int DX, DY, DZ, TA, TB, TK;
	private float RotateSpeed = 30f;
	private float RotateTo90;
	private bool SetTeam;
	private bool StartRotate;
	private bool FinishRotate;
	public GameObject CubeHome;
	public GameObject CubeLeader;
	public int CubeMode;



	void Start () {
		//CubeHome = GameObject.Find ("CubeHome_V3");
		//CubeLeader = GameObject.Find ("CubeLeader");
	}


	void Update () {
		if (Global.SetCubeTeam) {

			// 2*2*2 魔方
			if (CubeMode == 2) {
				if (this.CubeL == 1 && Global.RotateNum == 1) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeL == 0 && Global.RotateNum == 2) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 0 && Global.RotateNum == 3) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 1 && Global.RotateNum == 4) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 1 && Global.RotateNum == 5) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 0 && Global.RotateNum == 6) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeL == 0 && Global.RotateNum == 7) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeL == 1 && Global.RotateNum == 8) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 1 && Global.RotateNum == 9) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 0 && Global.RotateNum == 10) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 0 && Global.RotateNum == 11) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 1 && Global.RotateNum == 12) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}
			}

			// 3*3*3 魔方
			if (CubeMode == 3) {
				if (this.CubeL == 2 && Global.RotateNum == 1) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeL == 1 && Global.RotateNum == 2) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeL == 0 && Global.RotateNum == 3) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 0 && Global.RotateNum == 4) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 1 && Global.RotateNum == 5) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 2 && Global.RotateNum == 6) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 2 && Global.RotateNum == 7) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 1 && Global.RotateNum == 8) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 0 && Global.RotateNum == 9) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeL == 0 && Global.RotateNum == 10) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeL == 1 && Global.RotateNum == 11) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeL == 2 && Global.RotateNum == 12) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeL_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 2 && Global.RotateNum == 13) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 1 && Global.RotateNum == 14) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 0 && Global.RotateNum == 15) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 0 && Global.RotateNum == 16) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 1 && Global.RotateNum == 17) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 2 && Global.RotateNum == 18) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeR_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}
			}
		}




	}

	void FixedUpdate(){
		if (StartRotate) {
			Global.IsRotating = true;
			if (CubeLeader.transform.childCount >= CubeMode * CubeMode) {
				//GameObject.Find ("Player").transform.parent = CubeLeader.transform;
				Global.SetCubeTeam = false;
				CubeLeader.transform.Rotate (new Vector3 (DX * RotateSpeed * Time.deltaTime, DY * RotateSpeed * Time.deltaTime, DZ * RotateSpeed * Time.deltaTime));
			}
			RotateTo90 = Mathf.Abs (
				Mathf.Abs (CubeLeader.transform.eulerAngles.x) +
				Mathf.Abs (CubeLeader.transform.eulerAngles.y) +
				Mathf.Abs (CubeLeader.transform.eulerAngles.z) - 180);

			if (RotateTo90 >= 85 && RotateTo90 <= 95f) {
				CubeLeader.transform.rotation = Quaternion.Euler (DX * 90, DY * 90, DZ * 90);
				this.transform.parent = CubeHome.transform;
				//GameObject.Find ("Player").transform.parent = null;

				if (CubeLeader.transform.childCount == 0 && FinishRotate == false) {
					FinishRotate = true;
					StartRotate = false;
				}
			}
		} else if (FinishRotate) {
			CubeLeader.transform.rotation = Quaternion.Euler (0, 0, 0);
			Global.IsRotating = false;
			FinishRotate = false;
		}
	}
		

	// set cube's location
	void Right_CubeL_Setting(){
		if (CubeMode == 2) {
			TK = TA = this.CubeD;
			TA = TB = this.CubeR;
			TB = 1-TK;
			this.CubeD = TA;
			this.CubeR = TB;
			DX = 0;
			DY = 0;
			DZ = 1;
		}

		if (CubeMode == 3) {
			TK = TA = this.CubeD - 1;
			TA = TB = this.CubeR - 1;
			TB = -TK;
			this.CubeD = TA + 1;
			this.CubeR = TB + 1;
			DX = 0;
			DY = 0;
			DZ = 1;
		}

	}

	void Right_CubeD_Setting(){
		if (CubeMode == 2) {
			TK = TA = this.CubeL;
			TA = TB = this.CubeR;
			TB = 1-TK;
			this.CubeL = TA;
			this.CubeR = TB;
			DX = 0;
			DY = -1;
			DZ = 0;
		}

		if (CubeMode == 3) {
			TK = TA = this.CubeL - 1;
			TA = TB = this.CubeR - 1;
			TB = -TK;
			this.CubeL = TA + 1;
			this.CubeR = TB + 1;
			DX = 0;
			DY = -1;
			DZ = 0;
		}
	}

	void Right_CubeR_Setting(){
		if (CubeMode == 2) {
			TK = TA = this.CubeL;
			TA = TB = this.CubeD;
			TB = 1-TK;
			this.CubeL = TA;
			this.CubeD = TB;
			DX = 1;
			DY = 0;
			DZ = 0;
		}

		if (CubeMode == 3) {
			TK = TA = this.CubeL - 1;
			TA = TB = this.CubeD - 1;
			TB = -TK;
			this.CubeL = TA + 1;
			this.CubeD = TB + 1;
			DX = 1;
			DY = 0;
			DZ = 0;
		}
	}

	void Left_CubeR_Setting(){
		if (CubeMode == 2) {
			TK = TA = this.CubeD;
			TA = TB = this.CubeL;
			TB = 1-TK;
			this.CubeD = TA;
			this.CubeL = TB;
			DX = -1;
			DY = 0;
			DZ = 0;
		}

		if (CubeMode == 3) {
			TK = TA = this.CubeD - 1;
			TA = TB = this.CubeL - 1;
			TB = -TK;
			this.CubeD = TA + 1;
			this.CubeL = TB + 1;
			DX = -1;
			DY = 0;
			DZ = 0;
		}
	}

	void Left_CubeL_Setting(){
		if (CubeMode == 2) {
			TK = TA = this.CubeR;
			TA = TB = this.CubeD;
			TB = 1-TK;
			this.CubeR = TA;
			this.CubeD = TB;
			DX = 0;
			DY = 0;
			DZ = -1;
		}

		if (CubeMode == 3) {
			TK = TA = this.CubeR - 1;
			TA = TB = this.CubeD - 1;
			TB = -TK;
			this.CubeR = TA + 1;
			this.CubeD = TB + 1;
			DX = 0;
			DY = 0;
			DZ = -1;
		}
	}

	void Left_CubeD_Setting(){
		if (CubeMode == 2) {
			TK = TA = this.CubeR;
			TA = TB = this.CubeL;
			TB = 1-TK;
			this.CubeR = TA;
			this.CubeL = TB;
			DX = 0;
			DY = 1;
			DZ = 0;
		}

		if (CubeMode == 3) {
			TK = TA = this.CubeR - 1;
			TA = TB = this.CubeL - 1;
			TB = -TK;
			this.CubeR = TA + 1;
			this.CubeL = TB + 1;
			DX = 0;
			DY = 1;
			DZ = 0;
		}
	}
}
