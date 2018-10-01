using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour {

	// 以最接近玩家的方塊為原點，LRD分別為左/右/下
	public int ID;
	public int CubeL;
	public int CubeR;
	public int CubeD;

	// CubeMode代表魔方的層數
	public int CubeMode;
	public GameObject CubeHome;
	public GameObject CubeLeader;
	private GameObject Player;
	public GameObject GhostWall_V2;
	public GameObject GhostWall_V3;

	// DX~DZ調整魔方轉動方向
	// TA~TK為調整方塊LRD座標的暫存值
	private int DX, DY, DZ, TA, TB, TK;
	private float RotateSpeed = 30f;
	private float RotateTo90;
	private bool SetTeam;
	private bool StartRotate;
	private bool FinishRotate;

	// ExtraChild為處理Player等不隸屬於魔方單位的修正值
	private int ExtraChild;
	private float FixedP = 0.3f;

	//GameObject EnemyGroup_01;

	float CubeHomeX;
	float CubeHomeZ;


	void Start () {
		//EnemyGroup_01 = GameObject.Find ("EnemyGroup_01");
		CubeHomeX = CubeHome.transform.parent.transform.position.x;
		CubeHomeZ = CubeHome.transform.parent.transform.position.z;

		if (CubeMode == 2) {
			RotateSpeed = 60;
		} else if (CubeMode == 3) {
			RotateSpeed = 30;
		}
	}


	void Update () {
		Player = Global.Player;
		if (Global.SetCubeTeam) {

			// 2*2*2 魔方
			// 依順時針分為 -1 ~ -12 的方向
			if (CubeMode == 2) {
				if (this.CubeL == 1 && Global.RotateNum == -1) {
					if (Global.PlayerZ >= -2.5f - FixedP + CubeHomeZ && Global.PlayerZ <= -0.5f + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeL == 0 && Global.RotateNum == -2) {
					if (Global.PlayerZ >= 0.5f - FixedP + CubeHomeZ && Global.PlayerZ <= 2.5f + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeD == 0 && Global.RotateNum == -3) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;

					if (Global.OnCubeNum == 2) {
						Player.transform.parent = CubeLeader.transform;
						ExtraChild = 1;
						if (GhostWall_V2 != null) {
							GhostWall_V2.transform.parent = CubeLeader.transform;
							ExtraChild = 2;
						}
					}

					StartRotate = true;
				}

				if (this.CubeD == 1 && Global.RotateNum == -4) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeR == 1 && Global.RotateNum == -5) {
					if (Global.PlayerX >= -2.5f - FixedP + CubeHomeX && Global.PlayerX <= -0.5f + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeR == 0 && Global.RotateNum == -6) {
					if (Global.PlayerX >= 0.5f - FixedP + CubeHomeX && Global.PlayerX <= 2.5f + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeL == 0 && Global.RotateNum == -7) {
					if (Global.PlayerZ >= 0.5f - FixedP + CubeHomeZ && Global.PlayerZ <= 2.5f + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeL == 1 && Global.RotateNum == -8) {
					if (Global.PlayerZ >= -2.5f - FixedP + CubeHomeZ && Global.PlayerZ <= -0.5f + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeD == 1 && Global.RotateNum == -9) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					StartRotate = true;
				}

				if (this.CubeD == 0 && Global.RotateNum == -10) {

					if (StartRotate == false && FinishRotate == false)
						Left_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;

					if (Global.OnCubeNum == 2) {
						Player.transform.parent = CubeLeader.transform;
						ExtraChild = 1;
						if (GhostWall_V2 != null) {
							GhostWall_V2.transform.parent = CubeLeader.transform;
							ExtraChild = 2;
						}
					}

					StartRotate = true;
				}

				if (this.CubeR == 0 && Global.RotateNum == -11) {
					if (Global.PlayerX >= 0.5f - FixedP + CubeHomeX && Global.PlayerX <= 2.5f + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeR == 1 && Global.RotateNum == -12) {
					if (Global.PlayerX >= -2.5f - FixedP + CubeHomeX && Global.PlayerX <= -0.5f + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}
			}


			// 3*3*3 魔方
			// 依順時針分為 1 ~ 18 的方向
			if (CubeMode == 3) {
				if (this.CubeL == 2 && Global.RotateNum == 1) {
					if (Global.PlayerZ >= -4 - FixedP + CubeHomeZ && Global.PlayerZ <= -2 + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeL == 1 && Global.RotateNum == 2) {
					if (Global.PlayerZ >= -1 - FixedP + CubeHomeZ && Global.PlayerZ <= 1 + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeL == 0 && Global.RotateNum == 3) {
					if (Global.PlayerZ >= 2 - FixedP + CubeHomeZ && Global.PlayerZ <= 4 + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeD == 0 && Global.RotateNum == 4) {

					if (StartRotate == false && FinishRotate == false)
						Right_CubeD_Setting ();
					this.transform.parent = CubeLeader.transform;
					//EnemyGroup_01.transform.parent = CubeLeader.transform;
					//ExtraChild = 1;

					if (Global.OnCubeNum == 1) {
						Player.transform.parent = CubeLeader.transform;
						ExtraChild = 1;
						if (GhostWall_V3 != null) {
							GhostWall_V3.transform.parent = CubeLeader.transform;
							ExtraChild = 2;
						}
					}

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
					if (Global.PlayerX >= -4 - FixedP + CubeHomeX && Global.PlayerX <= -2 + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeR == 1 && Global.RotateNum == 8) {
					if (Global.PlayerX >= -1 - FixedP + CubeHomeX && Global.PlayerX <= 1 + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeR == 0 && Global.RotateNum == 9) {
					if (Global.PlayerX >= 2 - FixedP + CubeHomeX && Global.PlayerX <= 4 + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Right_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeL == 0 && Global.RotateNum == 10) {
					if (Global.PlayerZ >= 2 - FixedP + CubeHomeZ && Global.PlayerZ <= 4 + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeL == 1 && Global.RotateNum == 11) {
					if (Global.PlayerZ >= -1 - FixedP + CubeHomeZ && Global.PlayerZ <= 1 + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeL == 2 && Global.RotateNum == 12) {
					if (Global.PlayerZ >= -4 - FixedP + CubeHomeZ && Global.PlayerZ <= -2 + FixedP + CubeHomeZ && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeL_Setting ();
						this.transform.parent = CubeLeader.transform;

						StartRotate = true;
					}
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
					//EnemyGroup_01.transform.parent = CubeLeader.transform;
					//ExtraChild = 1;

					if (Global.OnCubeNum == 1) {
						Player.transform.parent = CubeLeader.transform;
						ExtraChild = 1;
						if (GhostWall_V3 != null) {
							GhostWall_V3.transform.parent = CubeLeader.transform;
							ExtraChild = 2;
						}
					}

					StartRotate = true;
				}

				if (this.CubeR == 0 && Global.RotateNum == 16) {
					if (Global.PlayerX >= 2 - FixedP + CubeHomeX && Global.PlayerX <= 4 + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeR == 1 && Global.RotateNum == 17) {
					if (Global.PlayerX >= -1 - FixedP + CubeHomeX && Global.PlayerX <= 1 + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}

				if (this.CubeR == 2 && Global.RotateNum == 18) {
					if (Global.PlayerX >= -4 - FixedP + CubeHomeX && Global.PlayerX <= -2 + FixedP + CubeHomeX && Global.Player != null) {
						Global.RotateNum = 0;
					} else {
						if (StartRotate == false && FinishRotate == false)
							Left_CubeR_Setting ();
						this.transform.parent = CubeLeader.transform;
						StartRotate = true;
					}
				}
			}
		}




	}

	void FixedUpdate(){
		if (StartRotate) 
		{
			Global.IsRotating = true;
			if(Global.Player != null)
				Global.Player.GetComponent<Rigidbody> ().useGravity = false;

			// 等所有child集結到CubeLeader下後再旋轉魔方
			if (CubeLeader.transform.childCount >= (CubeMode * CubeMode + ExtraChild)) 
			{
				Global.SetCubeTeam = false;
				CubeLeader.transform.Rotate (new Vector3 (DX * RotateSpeed * Time.deltaTime, DY * RotateSpeed * Time.deltaTime, DZ * RotateSpeed * Time.deltaTime));
			}
			RotateTo90 = Mathf.Abs (
				Mathf.Abs (CubeLeader.transform.eulerAngles.x) +
				Mathf.Abs (CubeLeader.transform.eulerAngles.y) +
				Mathf.Abs (CubeLeader.transform.eulerAngles.z) - 180);

			if (RotateTo90 >= 45 && RotateTo90 <= 135) {
				RotateSpeed  *= 0.91f;
			}

			// 大約轉至定位時，用來精準校正位置
			if (RotateTo90 >= 87 && RotateTo90 <= 93f) 
			{
				if (CubeMode == 2) {
					RotateSpeed = 60;
				} else if (CubeMode == 3) {
					RotateSpeed = 30;
				}
				CubeLeader.transform.rotation = Quaternion.Euler (DX * 90, DY * 90, DZ * 90);
				this.transform.parent = CubeHome.transform;
				if(Global.Player != null)
					Global.Player.transform.parent = null;
				if(GhostWall_V2 != null)
					GhostWall_V2.transform.parent = GameObject.Find("CubeV2").transform;
				if(GhostWall_V3 != null)
					GhostWall_V3.transform.parent = GameObject.Find("CubeV3").transform;
				//EnemyGroup_01.transform.parent = null;
				ExtraChild = 0;

				// 等所有child都解散後再進行後續處理
				if (CubeLeader.transform.childCount == 0 && FinishRotate == false) 
				{
					FinishRotate = true;
					StartRotate = false;
				}
			}
		} 
		else if (FinishRotate) 
		{
			CubeLeader.transform.rotation = Quaternion.Euler (0, 0, 0);
			Global.IsRotating = false;
			Global.RotateNum = 0;
			if(Global.Player != null)
				Global.Player.GetComponent<Rigidbody> ().useGravity = true;
			FinishRotate = false;
		}
	}
		

	// 設置方塊轉動後座標
	void Right_CubeL_Setting(){
		if (CubeMode == 2) 
		{
			TK = TA = this.CubeD;
			TA = TB = this.CubeR;
			TB = 1-TK;
			this.CubeD = TA;
			this.CubeR = TB;
			DX = 0;
			DY = 0;
			DZ = 1;
		}

		if (CubeMode == 3) 
		{
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
		if (CubeMode == 2) 
		{
			TK = TA = this.CubeL;
			TA = TB = this.CubeR;
			TB = 1-TK;
			this.CubeL = TA;
			this.CubeR = TB;
			DX = 0;
			DY = -1;
			DZ = 0;
		}

		if (CubeMode == 3) 
		{
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
		if (CubeMode == 2) 
		{
			TK = TA = this.CubeL;
			TA = TB = this.CubeD;
			TB = 1-TK;
			this.CubeL = TA;
			this.CubeD = TB;
			DX = 1;
			DY = 0;
			DZ = 0;
		}

		if (CubeMode == 3) 
		{
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
		if (CubeMode == 2) 
		{
			TK = TA = this.CubeD;
			TA = TB = this.CubeL;
			TB = 1-TK;
			this.CubeD = TA;
			this.CubeL = TB;
			DX = -1;
			DY = 0;
			DZ = 0;
		}

		if (CubeMode == 3) 
		{
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
		if (CubeMode == 2) 
		{
			TK = TA = this.CubeR;
			TA = TB = this.CubeD;
			TB = 1-TK;
			this.CubeR = TA;
			this.CubeD = TB;
			DX = 0;
			DY = 0;
			DZ = -1;
		}

		if (CubeMode == 3) 
		{
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
		if (CubeMode == 2) 
		{
			TK = TA = this.CubeR;
			TA = TB = this.CubeL;
			TB = 1-TK;
			this.CubeR = TA;
			this.CubeL = TB;
			DX = 0;
			DY = 1;
			DZ = 0;
		}

		if (CubeMode == 3) 
		{
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
