using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MissionSetting : MonoBehaviour {
	public static Flowchart FlowerChart;
	public Flowchart GetFlowChart;
	public static bool BlockOn;
	bool Oneshot;
	bool AnotherOneshot;
	int NextLevel;
	public static string Blocking;
	private GameObject MissionArrow;

	private GameObject Target;
	private GameObject CurrentCam;
	private GameObject ScreenHeart;
	private Vector3 CurrentCam_Origin;
	private Vector3 ScreenHeart_Origin;
	private Quaternion ScreenHeart_OriginRot;
	private Vector3 NextCamPos;
	private Vector3 NextHeartPos;
	private Vector3 LastHeartPos;
	public static bool CamIsMoving;
	public static bool CamIsMovingBack;
	private Quaternion CamRotTarget;
	public List<Block> AllBlocks = new List<Block>();
	public List<GameObject> MissionTargets = new List<GameObject> ();
	public List<GameObject> MissionArrows = new List<GameObject> ();
	private int TargetID = 0 ;
	private Vector3 MultiPos;

	private bool Arrow_Lucas = true;
	private bool Arrow_Soyna = true;
	private bool Arrow_Sisco = true;
	private bool Arrow_Riven = true;
	private bool Arrow_Box = true;
	private bool Arrow_RedLeaf = true;
	private bool Arrow_Engine = true;
	private bool Arrow_Kyder = true;

	// Active Area
	// Chapter 01
	public bool EisPressed;
	private GameObject Shop_Door2{get{return GameObject.Find("Shop_Door2"); }}
	private GameObject Rose{get{return GameObject.Find("Rose"); }}
	private GameObject GlassRepair{get{return GameObject.Find("GlassRepair"); }}
	private GameObject PrinceHome_Door{get{return GameObject.Find("PrinceHome_Door"); }}
	private GameObject Marley{get{return GameObject.Find("Marley"); }}
	private GameObject AnotherHouse_Door2{get{return GameObject.Find("AnotherHouse_Door2"); }}
	private GameObject WareHouse_Door{get{return GameObject.Find("WareHouse_Door"); }}
	private GameObject MtShip1{get{return GameObject.Find("Mt.SpaceShip_Door1"); }}

	// Chapter 02
	private GameObject Lucas{get{return GameObject.Find("Lucas"); }}
	private GameObject Soyna{get{return GameObject.Find("Soyna"); }}
	private GameObject Sisco{get{return GameObject.Find("Sisco"); }}
	private GameObject Riven{get{return GameObject.Find("Riven"); }}
	private GameObject Mike{get{return GameObject.Find("Mike"); }}
	private GameObject Bill{get{return GameObject.Find("Bill"); }}

	// Chapter 03
	private GameObject King{get{return GameObject.Find("King"); }}
	private GameObject Warehouse2{get{return GameObject.Find("Warehouse2"); }}
	private GameObject HouseKeeper{get{return GameObject.Find("HouseKeeper"); }}
	private GameObject Servent{get{return GameObject.Find("Servent"); }}
	private GameObject Maid{get{return GameObject.Find("Maid"); }}
	private GameObject Cat{get{return GameObject.Find("Cat"); }}

	GameObject PlayerBody;
	GameObject SpaceShip;

	void Awake(){
		MissionArrow = Resources.Load("Prefabs/Global/MissionArrow") as GameObject;
		PlayerBody = GameObject.Find ("Player_Body");
		SpaceShip = GameObject.Find ("SpaceShip_Anim");
	}

	void Start () {
		if(GetFlowChart != null)
			FlowerChart = GetFlowChart;
		if (Global.Level == "2" || Global.Level == "3") {
			foreach (Component skin in PlayerBody.GetComponentsInChildren<FadeObject>())
				skin.GetComponent<FadeObject> ().PlayerFadeOut ();
		}
	}


	void CameraMove(GameObject _Target, GameObject _CurrentCam, GameObject _ScreenHeart, Vector3 ArrowPos, bool NeedArrow){
		Target = _Target;
		CurrentCam = _CurrentCam;
		ScreenHeart = _ScreenHeart;

		if (MissionTargets.LastIndexOf (Target) <= MissionTargets.Count && ArrowPos != Vector3.zero && NeedArrow ) {
			MissionArrows.Add (Instantiate (MissionArrow, Target.transform.position, Target.transform.rotation, Target.transform));
			MissionArrows [MissionArrows.Count - 1].transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
			MissionArrows [MissionArrows.Count - 1].name = Target.name + "_Arrow";
			MissionArrows [MissionArrows.Count - 1].transform.Translate (ArrowPos);
			MissionArrows [MissionArrows.Count - 1].SetActive (false);
		}
		if (TargetID == 0) {
			CurrentCam_Origin = CurrentCam.transform.position;
			//ScreenHeart.transform.position = CameraControllerV2.currentHeart.transform.position; // For Camera track.
			ScreenHeart_Origin = ScreenHeart.transform.position;
			ScreenHeart_OriginRot = ScreenHeart.transform.rotation;
		}
		//ScreenHeart.transform.position = Vector3.zero;
		LastHeartPos = ScreenHeart.transform.position;
		ScreenHeart.transform.position = Target.transform.position;
		ScreenHeart.transform.rotation = Target.transform.rotation;

		ScreenHeart.transform.Translate (new Vector3 (1,1,1));
		ScreenHeart.transform.position += (ScreenHeart.transform.position - Target.transform.position) * 20;
		NextCamPos = ScreenHeart.transform.position;

		ScreenHeart.transform.position = Target.transform.position;
		ScreenHeart.transform.Translate (new Vector3 (0,3,0));
		NextHeartPos = ScreenHeart.transform.position;

		if (MissionTargets.LastIndexOf (Target) == MissionTargets.Count)
			ScreenHeart.transform.position = NextHeartPos;
		else
			ScreenHeart.transform.position = LastHeartPos;


		//NextCamPos = ScreenHeart.transform.position;
		//ScreenHeart.transform.position = ScreenHeart_Origin;
		Global.StopTouch = true;
		CamIsMoving = true;
		return;

	}

	void FixedUpdate ()
	{
		if (MissionTargets.Find ((x) => x.gameObject == null) == null && MissionTargets.IndexOf (MissionTargets.Find ((x) => x.gameObject == null)) != -1) {
			MissionArrows.RemoveAt (MissionTargets.IndexOf (MissionTargets.Find ((x) => x.gameObject == null)));
			MissionTargets.RemoveAt (MissionTargets.IndexOf (MissionTargets.Find ((x) => x.gameObject == null)));
		}


		if (Global.LevelEnd == null)
			Global.LevelEnd = GameObject.Find ("Bool_LevelEnd");

		if (FlowerChart != null) {

			if (Global.Level == "1") {
				if (Vector3.Distance (Global.Player.transform.position, Rose.transform.position) <= 1.2f && FlowerChart.GetBooleanVariable ("GetBread")) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("GiveBread");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, Shop_Door2.transform.position) <= 1.2f && FlowerChart.GetBooleanVariable ("Bread")) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("BuyBread");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, GlassRepair.transform.position) <= 1.2f && FlowerChart.GetBooleanVariable ("FindGP")) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("FindGP");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, PrinceHome_Door.transform.position) <= 1.2f && FlowerChart.GetBooleanVariable ("GiveBread")) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("RoseGoHome");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, PrinceHome_Door.transform.position) <= 1.2f && FlowerChart.GetBooleanVariable ("SecGoHome")) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("SecGoHome");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, MtShip1.transform.position) <= 1.2f && FlowerChart.GetBooleanVariable ("Ship")) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("GoShip");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, Marley.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("MarletTalk");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, AnotherHouse_Door2.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("HouseTalk");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, WareHouse_Door.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("WareHouseTalk");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				}  else {
					PlayerStatusImage.GetStatus ("None");
				}
			}

			if (Global.Level == "2") {
				// Landing
				if (MissionSetting.FlowerChart.GetBooleanVariable ("Landing") && PlayerBody != null) {
					SpaceShip.transform.position = Vector3.MoveTowards (SpaceShip.transform.position, new Vector3(SpaceShip.transform.position.x, Global.Player.transform.position.y, SpaceShip.transform.position.z), 0.025f);
					if (Mathf.Abs (SpaceShip.transform.position.y - Global.Player.transform.position.y) < 0.05f) {
						for (int i = 0; i < PlayerBody.transform.childCount; i++) {
							PlayerBody.transform.GetChild (i).gameObject.GetComponent<Renderer> ().enabled = true;
							PlayerBody.transform.GetChild (i).gameObject.GetComponent<FadeObject> ().PlayerFadeIn ();

						}
						if(PlayerBody.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color.a >= 0.5f && this.GetComponent<PathController>().BeTouchedFloor == null)
							this.GetComponent<PathController> ().WalkOrder ("V3Floor_10");
					}
				}

				if (Vector3.Distance (Global.Player.transform.position, Lucas.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks ()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("LucasTalk01");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, Sisco.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks ()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("SiscoTalk01");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, Riven.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks ()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("RivenTalk01");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, Soyna.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks ()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("SoynaTalk01");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, Mike.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks ()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("MikeTalk01");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, Bill.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks ()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("BillTalk01");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else {
					PlayerStatusImage.GetStatus ("None");
				}


				// Exit Planet
				if(FlowerChart.GetBooleanVariable("PushBox01") && FlowerChart.GetBooleanVariable("FindLeaf") && FlowerChart.GetBooleanVariable("FindEngine") && FlowerChart.GetBooleanVariable("FindKyder") && FlowerChart.GetBooleanVariable("Start")){
					Flowchart.BroadcastFungusMessage("GO");
				}

			}

			if (Global.Level == "3") {
				// Landing
				if (MissionSetting.FlowerChart.GetBooleanVariable ("Landing") && PlayerBody != null) {
					SpaceShip.transform.position = Vector3.Lerp (SpaceShip.transform.position, new Vector3(SpaceShip.transform.position.x, Global.Player.transform.position.y, SpaceShip.transform.position.z), 0.1f);
					if (Mathf.Abs (SpaceShip.transform.position.y - Global.Player.transform.position.y) < 0.05f) {
						for (int i = 0; i < PlayerBody.transform.childCount; i++) {
							PlayerBody.transform.GetChild (i).gameObject.GetComponent<Renderer> ().enabled = true;
							PlayerBody.transform.GetChild (i).gameObject.GetComponent<FadeObject> ().PlayerFadeIn ();

						}
						if(PlayerBody.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color.a >= 0.5f && this.GetComponent<PathController>().BeTouchedFloor == null)
							this.GetComponent<PathController> ().WalkOrder ("V3Floor_2");
					}
				}

				if (Vector3.Distance (Global.Player.transform.position, King.transform.position) <= 1.2f) {
					// 室內場景不適用
					/*if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("FirstTouchKing");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}*/
				} else if (Vector3.Distance (Global.Player.transform.position, HouseKeeper.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("HouseKeeper");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else if (Vector3.Distance (Global.Player.transform.position, Warehouse2.transform.position) <= 1.2f) {
					if (!EisPressed && !FlowerChart.HasExecutingBlocks()) {
						PlayerStatusImage.GetStatus ("Interact?");
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Flowchart.BroadcastFungusMessage ("Warehouse2");
						PlayerStatusImage.GetStatus ("None");
						EisPressed = true;
					}
				} else {
					PlayerStatusImage.GetStatus ("None");
				}
			}



			switch (Blocking) {
			case"開頭":

				MissionTargets.Add (GameObject.Find ("Event_Shop(Clone)"));
				CameraMove (GameObject.Find ("Event_Shop(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3(-0.5f, 5, -0.5f), true);

				Blocking = null;
				break;
			case"買麵包":
				
				if (FlowerChart.GetBooleanVariable ("Bread")) {
					Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Shop(Clone)"))]);
					MissionTargets.Clear ();
					MissionArrows.Clear ();
					MissionTargets.Add (GameObject.Find ("Event_Rose(Clone)"));
					CameraMove (GameObject.Find ("Event_Rose(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 4, 0), true);

					Blocking = null;
				}
				break;
			case"給麵包":
				
				if (FlowerChart.GetBooleanVariable ("GetBread")) {
					Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Rose(Clone)"))]);
					MissionTargets.Clear ();
					MissionArrows.Clear ();
					MissionTargets.Add (GameObject.Find ("Event_PrinceHome(Clone)"));
					CameraMove (GameObject.Find ("Event_PrinceHome(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0), true);

					Blocking = null;
				}
				break;
			case"帶玫瑰回家":
				
				if (FlowerChart.GetBooleanVariable ("GiveBread")) {
					Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_PrinceHome(Clone)"))]);
					MissionTargets.Clear ();
					MissionArrows.Clear ();
					MissionTargets.Add (GameObject.Find ("Event_GlassRepair(Clone)"));
					CameraMove (GameObject.Find ("Event_GlassRepair(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 1), true);

					Blocking = null;
				}
				break;
			case"找爺爺":
				
				if (FlowerChart.GetBooleanVariable ("FindGP")) {
					Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_GlassRepair(Clone)"))]);
					MissionTargets.Clear ();
					MissionArrows.Clear ();
					MissionTargets.Add (GameObject.Find ("Event_PrinceHome(Clone)"));
					CameraMove (GameObject.Find ("Event_PrinceHome(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0), true);

					Blocking = null;
				}
				break;
			case"第二次回家":
				
				if (FlowerChart.GetBooleanVariable ("SecGoHome")) {
					Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_PrinceHome(Clone)"))]);
					MissionTargets.Clear ();
					MissionArrows.Clear ();
					MissionTargets.Add (GameObject.Find ("Event_Mt.SpaceShip(Clone)"));
					CameraMove (GameObject.Find ("Event_Mt.SpaceShip(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (-0.5f, 5, -1), true);

					Blocking = null;
				}
				break;
			case"開飛船":
				if (FlowerChart.GetBooleanVariable ("Ship")) {
					Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Mt.SpaceShip(Clone)"))]);
					MissionTargets.Clear ();
					MissionArrows.Clear ();
				
					Blocking = null;
				}
				break;


			case"開頭對話":
				if (Global.Level == "2") {
					MissionTargets.Add (GameObject.Find ("Event_Lucas(Clone)"));
					MissionTargets.Add (GameObject.Find ("Event_Soyna(Clone)"));
					MissionTargets.Add (GameObject.Find ("Event_Riven(Clone)"));
					MissionTargets.Add (GameObject.Find ("Event_Sisco(Clone)"));
					CameraMove (MissionTargets [0], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0), true);
					MultiPos = new Vector3 (0, 5, 0);
					Blocking = null;
				}
				break;
			case"盧卡斯第一次對話":
				//Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Lucas(Clone)"))]);
				//Destroy (MissionArrows.Find((x) => x.name == "Event_Lucas(Clone)_MA"));
				if (MissionTargets.Contains(GameObject.Find ("Event_Lucas(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Lucas(Clone)_Arrow")) {
					MissionArrows.FindLast ((x) => x.name == "Event_Lucas(Clone)_Arrow").SetActive (false);
					MissionArrows.RemoveAt (MissionTargets.LastIndexOf (GameObject.Find ("Event_Lucas(Clone)")));
				
					MissionTargets.Remove (GameObject.Find ("Event_Lucas(Clone)"));
				}
				/*
				TargetID = MissionTargets.Count;
				MissionTargets.Add (GameObject.Find ("Box_1"));
				MissionTargets.Add (GameObject.Find ("Box_2"));
				MissionTargets.Add (GameObject.Find ("Box_3"));

				CameraMove (MissionTargets[TargetID], CameraController.CurrentCam, CameraController.CamTarget, new Vector3(0, 4, 0));*/

				if (FlowerChart.GetBooleanVariable ("PushBox01") == false && FlowerChart.GetBooleanVariable("GetTool01") == false) {
					if (Arrow_Lucas) {
						MissionTargets.Add (GameObject.Find ("Event_IncinerationPlant(Clone)"));
						CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0), Arrow_Lucas);
					}
					Arrow_Lucas = false;
				}
				Blocking = null;
				break;
			case"索依娜第一次對話":
				//Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Soyna(Clone)"))]);
				//Destroy (MissionArrows.Find((x) => x.name == "Event_Soyna(Clone)_MA"));
				if (MissionTargets.Contains(GameObject.Find ("Event_Soyna(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Soyna(Clone)_Arrow")) {
					MissionArrows.FindLast ((x) => x.name == "Event_Soyna(Clone)_Arrow").SetActive (false);
					MissionArrows.RemoveAt (MissionTargets.LastIndexOf (GameObject.Find ("Event_Soyna(Clone)")));
				
					MissionTargets.Remove (GameObject.Find ("Event_Soyna(Clone)"));
				}
				//MissionTargets.Add (GameObject.Find ("Event_Riven(Clone)"));
				//MissionTargets.Add (GameObject.Find ("Event_Station(Clone)"));
				//MissionTargets.Add (GameObject.Find ("Event_BattleShipWing(Clone)"));
				if (FlowerChart.GetBooleanVariable ("FindLeaf") == false && FlowerChart.GetBooleanVariable("GetLeaf") == false) {
						TargetID = MissionTargets.Count;

					if (GameObject.Find ("Redleaf_A") != null && Arrow_Soyna)
							MissionTargets.Add (GameObject.Find ("Redleaf_A"));
					if (GameObject.Find ("Redleaf_B") != null && Arrow_Soyna)
							MissionTargets.Add (GameObject.Find ("Redleaf_B"));
					if (GameObject.Find ("Redleaf_C") != null && Arrow_Soyna)
							MissionTargets.Add (GameObject.Find ("Redleaf_C"));
					if (Arrow_Soyna) {
						CameraMove (MissionTargets [TargetID], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 1, 0), Arrow_Soyna);
						MultiPos = new Vector3 (0, 1, 0);
					}
					Arrow_Soyna = false;
				}

				Blocking = null;
				break;
			case"瑞文第一次對話":
				//Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Riven(Clone)"))]);
				//Destroy (MissionArrows.Find((x) => x.name == "Event_Riven(Clone)_MA"));
				if (MissionTargets.Contains(GameObject.Find ("Event_Riven(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Riven(Clone)_Arrow")) {
					MissionArrows.FindLast ((x) => x.name == "Event_Riven(Clone)_Arrow").SetActive (false);
					MissionArrows.RemoveAt (MissionTargets.LastIndexOf (GameObject.Find ("Event_Riven(Clone)")));
				
					MissionTargets.Remove (GameObject.Find ("Event_Riven(Clone)"));
				}
				if (FlowerChart.GetBooleanVariable ("FindEngine") == false && FlowerChart.GetBooleanVariable("GetEngine") == false) {
					if (Arrow_Riven) {
						MissionTargets.Add (GameObject.Find ("Engine"));
						CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 1, 0), Arrow_Riven);
					}
					Arrow_Riven = false;
				}
				Blocking = null;
				break;
			case"西斯寇第一次對話":
				//Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Sisco(Clone)"))]);
				//Destroy (MissionArrows.Find((x) => x.name == "Event_Sisco(Clone)_MA"));
				if (MissionTargets.Contains(GameObject.Find ("Event_Sisco(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Sisco(Clone)_Arrow")) {
					MissionArrows.FindLast ((x) => x.name == "Event_Sisco(Clone)_Arrow").SetActive (false);
					MissionArrows.RemoveAt (MissionTargets.LastIndexOf (GameObject.Find ("Event_Sisco(Clone)")));
				
					MissionTargets.Remove (GameObject.Find ("Event_Sisco(Clone)"));
				}
				if (FlowerChart.GetBooleanVariable ("FindKyder") == false && FlowerChart.GetBooleanVariable("GetKyder") == false) {
					if (Arrow_Sisco) {
						MissionTargets.Add (GameObject.Find ("Event_Station(Clone)"));
						CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0), Arrow_Sisco);
					}
					Arrow_Sisco = false;
				}
				Blocking = null;
				break;
			case"控制箱子變數":

				/*if(MissionArrows.Contains(GameObject.Find(GameObject.Find ("Box_1").transform.parent.gameObject.name + "_MA")))
					Destroy (MissionArrows.Find((x) => x.name == GameObject.Find ("Box_1").transform.parent.gameObject.name + "_MA"));
				if(MissionArrows.Contains(GameObject.Find(GameObject.Find ("Box_2").transform.parent.gameObject.name + "_MA")))
					Destroy (MissionArrows.Find((x) => x.name == GameObject.Find ("Box_2").transform.parent.gameObject.name + "_MA"));
				if(MissionArrows.Contains(GameObject.Find(GameObject.Find ("Box_3").transform.parent.gameObject.name + "_MA")))
					Destroy (MissionArrows.Find((x) => x.name == GameObject.Find ("Box_3").transform.parent.gameObject.name + "_MA"));*/
				/*MissionTargets.Remove (GameObject.Find ("Box_1"));
				MissionTargets.Remove (GameObject.Find ("Box_2"));
				MissionTargets.Remove (GameObject.Find ("Box_3"));*/
				if (MissionTargets.Contains(GameObject.Find ("Event_IncinerationPlant(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_IncinerationPlant(Clone)_Arrow")) {
					MissionTargets.Remove (GameObject.Find ("Event_IncinerationPlant(Clone)"));
					MissionArrows.FindLast ((x) => x.name == "Event_IncinerationPlant(Clone)_Arrow").SetActive (false);
					MissionArrows.Remove (GameObject.Find ("Event_IncinerationPlant(Clone)_Arrow"));
					if(Arrow_Box)
						MissionTargets.Add (GameObject.Find ("Event_Lucas(Clone)"));
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0), Arrow_Box);
					Arrow_Box = false;
				}
				Blocking = null;
				break;
			case"控制草葉變數":
				/*if(MissionArrows.Contains(GameObject.Find ("Event_Riven(Clone)_MA")))
					Destroy (MissionArrows.Find((x) => x.name == "Event_Riven(Clone)_MA"));
				if(MissionArrows.Contains(GameObject.Find ("Event_Station(Clone)_MA")))
					Destroy (MissionArrows.Find((x) => x.name == "Event_Station(Clone)_MA"));
				if(MissionArrows.Contains(GameObject.Find ("Event_BattleShipWing(Clone)_MA")))
					Destroy (MissionArrows.Find((x) => x.name == "Event_BattleShipWing(Clone)_MA"));*/
				if (MissionTargets.Contains (GameObject.Find ("Redleaf_A")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Redleaf_A_Arrow")) {
					MissionTargets.Remove (GameObject.Find ("Redleaf_A"));
					MissionArrows.FindLast ((x) => x.name == "Redleaf_A_Arrow").SetActive (false);
					MissionArrows.Remove (GameObject.Find ("Redleaf_A_Arrow"));
				}
				if (MissionTargets.Contains (GameObject.Find ("Redleaf_B")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Redleaf_B_Arrow")) {
					MissionTargets.Remove (GameObject.Find ("Redleaf_B"));
					MissionArrows.FindLast ((x) => x.name == "Redleaf_B_Arrow").SetActive (false);
					MissionArrows.Remove (GameObject.Find ("Redleaf_B_Arrow"));
				}
				if (MissionTargets.Contains (GameObject.Find ("Redleaf_C")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Redleaf_C_Arrow")) {
					MissionTargets.Remove (GameObject.Find ("Redleaf_C"));
					MissionArrows.FindLast ((x) => x.name == "Redleaf_C_Arrow").SetActive (false);
					MissionArrows.Remove (GameObject.Find ("Redleaf_C_Arrow"));
				}
				if((MissionTargets.Contains (GameObject.Find ("Redleaf_A")) || MissionTargets.Contains (GameObject.Find ("Redleaf_B")) || MissionTargets.Contains (GameObject.Find ("Redleaf_C")))
						&& MissionArrows.FindLast ((x) => x.gameObject != null && (x.name == "Redleaf_A_Arrow" || x.name == "Redleaf_B_Arrow" || x.name == "Redleaf_C_Arrow") )){
					if(Arrow_RedLeaf)
						MissionTargets.Add (GameObject.Find ("Event_Soyna(Clone)"));
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0), Arrow_RedLeaf);
					Arrow_RedLeaf = false;
				}
				Blocking = null;
				break;
			case"控制引擎變數":

				/*if(MissionArrows.Contains(GameObject.Find ("Event_Riven(Clone)_MA")))
					Destroy (MissionArrows.Find((x) => x.name == "Event_Riven(Clone)_MA"));*/
				if (MissionTargets.Contains(GameObject.Find ("Engine")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Engine_Arrow")) {
					MissionTargets.Remove (GameObject.Find ("Engine"));
					MissionArrows.FindLast ((x) => x.name == "Engine_Arrow").SetActive (false);
					MissionArrows.Remove (GameObject.Find ("Engine_Arrow"));

					if(Arrow_Engine)
						MissionTargets.Add (GameObject.Find ("Event_Riven(Clone)"));
					
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0), Arrow_Engine);
					Arrow_Engine = false;
				}
				Blocking = null;
				break;
			case"控制水晶變數":

				
				if (MissionTargets.Contains(GameObject.Find ("Event_Station(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Station(Clone)_Arrow")) {
					MissionTargets.Remove (GameObject.Find ("Event_Station(Clone)"));
					MissionArrows.FindLast ((x) => x.name == "Event_Station(Clone)_Arrow").SetActive (false);
					MissionArrows.Remove (GameObject.Find ("Event_Station(Clone)_Arrow"));
					if(Arrow_Kyder)
						MissionTargets.Add (GameObject.Find ("Event_Sisco(Clone)"));
				
					//CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0), Arrow_Kyder);
					Arrow_Kyder = false;
				}
				Blocking = null;
				break;

			}


			// Camera Move
			if (CurrentCam != null && ScreenHeart != null && Target != null && !FlowerChart.HasExecutingBlocks () && CamIsMoving && !FlowerChart.GetBooleanVariable("LookAround")) {
				if (Vector3.Distance (CurrentCam.transform.position, NextCamPos) <= 0.5f) {
					MissionArrows [MissionArrows.Count-1].SetActive (true);
					CamRotTarget = Quaternion.LookRotation (ScreenHeart.transform.position - CurrentCam.transform.position, Vector3.Lerp (CurrentCam.transform.up, Target.transform.up, 0.1f));
					CurrentCam.transform.rotation = Quaternion.Slerp (CurrentCam.transform.rotation, CamRotTarget, 0.2f);

					ScreenHeart.transform.position = Vector3.Lerp (ScreenHeart.transform.position, NextHeartPos, 0.03f);
					CurrentCam.transform.position = Vector3.Lerp (CurrentCam.transform.position, NextCamPos, 0.03f);
					if (Input.GetMouseButtonDown (0) || Vector3.Distance (CurrentCam.transform.position, NextCamPos) <= 0.3f) {
						if (MissionTargets.LastIndexOf (Target) != MissionTargets.Count-1) {
							TargetID++;
							CameraMove (MissionTargets[TargetID], CameraController.CurrentCam, CameraController.CamTarget, MultiPos, true);

						} else if (MissionTargets.LastIndexOf (Target) == MissionTargets.Count-1) {
							TargetID++;
							CamIsMoving = false;
							CamIsMovingBack = true;
							Global.StopTouch = true;
						}
					}

					} else {
					// Camera is moving.
					PlayerStatusImage.GetStatus ("None");
					ScreenHeart.transform.position = Vector3.Lerp (ScreenHeart.transform.position, NextHeartPos, 0.03f);
					CurrentCam.transform.position = Vector3.Lerp (CurrentCam.transform.position, NextCamPos, 0.03f);
					CamRotTarget = Quaternion.LookRotation (ScreenHeart.transform.position - CurrentCam.transform.position, Vector3.Lerp (CurrentCam.transform.up, Target.transform.up, 0.1f));
					CurrentCam.transform.rotation = Quaternion.Slerp (CurrentCam.transform.rotation, CamRotTarget, 0.6f);

						}
				} else if (CurrentCam != null && ScreenHeart != null && Target != null && !CamIsMoving && CamIsMovingBack) {
					if (Vector3.Distance (CurrentCam.transform.position, CurrentCam_Origin) <= 0.1f) {
						TargetID = 0;
						ScreenHeart.transform.position = ScreenHeart_Origin;
						ScreenHeart.transform.rotation = ScreenHeart_OriginRot;
						CurrentCam = ScreenHeart = Target = null;
						Global.StopTouch = false;
						CamIsMovingBack = false;

					} else {
					// Camera is moving back.
					ScreenHeart.transform.position = Vector3.Lerp (ScreenHeart.transform.position, ScreenHeart_Origin, 0.04f);
					CurrentCam.transform.position = Vector3.Lerp (CurrentCam.transform.position, CurrentCam_Origin, 0.04f);
					CamRotTarget = Quaternion.LookRotation (ScreenHeart.transform.position - CurrentCam.transform.position, Vector3.Lerp (CurrentCam.transform.up, Vector3.up, 0.075f));
					CurrentCam.transform.rotation = Quaternion.Slerp (CurrentCam.transform.rotation, CamRotTarget, 0.8f);

					}
				}



				// Get Block's Name
				if (FlowerChart.HasExecutingBlocks () && !AnotherOneshot) {
					AllBlocks = FlowerChart.GetExecutingBlocks ();
					Blocking = AllBlocks [AllBlocks.Count - 1].BlockName;
					AnotherOneshot = true;
				} else if (!FlowerChart.HasExecutingBlocks () && AnotherOneshot) {
					Blocking = null;
					AnotherOneshot = false;
				}

				// 第一章結尾
				if (Global.Level == "1") {
					if (FlowerChart.HasExecutingBlocks () && Blocking == "開飛船") {
						if (Level01PlayerEvent.Ship && !Oneshot) {
							Oneshot = true;
						}
					} else if (!Level01PlayerEvent.Ship && Oneshot) {
						GameObject.Find ("SpaceShip_Anim").GetComponent<Animation> ().Play ("Fly");
						CameraFade.FadeOut ();
						Global.Player.SetActive (false);
						Global.NextScene = 3; // To Chapter 02
						Oneshot = false;

					}
				}

				if (Global.Level == "2") {
					if (FlowerChart.HasExecutingBlocks () && FlowerChart.SelectedBlock != null && Blocking == "閃人") {
						if (!Oneshot && FlowerChart.GetBooleanVariable ("PushBox01") && FlowerChart.GetBooleanVariable ("FindLeaf") && FlowerChart.GetBooleanVariable ("FindEngine") && FlowerChart.GetBooleanVariable ("FindKyder")) {
							Oneshot = true;
						}
					} else if (Oneshot) {
						GameObject.Find ("SpaceShip_Anim").GetComponent<Animation> ().Play ("Fly2");
						CameraFade.FadeOut ();
						Global.Player.SetActive (false);
						Global.NextScene = 4; // To Chapter 03
						Oneshot = false;
					}
				}


			}

			// 對話時停止移動、轉動
			if (FlowerChart != null) {
				if (FlowerChart.HasExecutingBlocks () && BlockOn == false) {
					BlockOn = true;
					Global.StopTouch = true;
					PlayerStatusImage.GetStatus ("IsTalking");

					CameraController.OriginView = Camera.main.fieldOfView;
					//CameraController.CamView = 10;

				} else if (!FlowerChart.HasExecutingBlocks () && BlockOn == true && !CamIsMoving) {
					BlockOn = false;
				if (!CamIsMovingBack) {
					Global.StopTouch = false;

				}
				EisPressed = false;
				PlayerStatusImage.GetStatus ("None");
				

					CameraController.CamView = CameraController.OriginView;

				}
			}



		

	}
}
