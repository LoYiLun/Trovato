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
	public string Blocking;
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
	private bool OS2;
	private Vector3 FixedRot;
	private Quaternion CamRotTarget;
	public List<Block> AllBlocks = new List<Block>();
	public List<GameObject> MissionTargets = new List<GameObject> ();
	public List<GameObject> MissionArrows = new List<GameObject> ();
	private int TargetID = 0 ;
	private float Heartdis;
	private Vector3 MultiPos;


	void Awake(){
		MissionArrow = Resources.Load("Prefabs/Global/MissionArrow") as GameObject;
	}

	void Start () {
		if(GetFlowChart != null)
		FlowerChart = GetFlowChart;

		

	}


	void CameraMove(GameObject _Target, GameObject _CurrentCam, GameObject _ScreenHeart, Vector3 ArrowPos){


		Target = _Target;
		CurrentCam = _CurrentCam;
		ScreenHeart = _ScreenHeart;
		FixedRot = Vector3.up;

		PlayerStatusImage.Status = null; 

		//MissionArrows.Clear ();
		if (MissionTargets.LastIndexOf (Target) <= MissionTargets.Count && ArrowPos != Vector3.zero ) {
			MissionArrows.Add (Instantiate (MissionArrow, Target.transform.position, Target.transform.rotation, Target.transform));
			MissionArrows [MissionArrows.Count - 1].transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
			MissionArrows [MissionArrows.Count - 1].name = Target.name;
			MissionArrows [MissionArrows.Count - 1].transform.Translate (ArrowPos);
			MissionArrows [MissionArrows.Count - 1].SetActive (false);
		}
		if (TargetID == 0) {
			CurrentCam_Origin = CurrentCam.transform.position;
			ScreenHeart_Origin = ScreenHeart.transform.position;
			ScreenHeart_OriginRot = ScreenHeart.transform.rotation;
		}
		//ScreenHeart.transform.position = Vector3.zero;
		LastHeartPos = ScreenHeart.transform.position;
		ScreenHeart.transform.position = Target.transform.position;
		ScreenHeart.transform.rotation = Target.transform.rotation;

		ScreenHeart.transform.Translate (new Vector3 (1,1,1));
		ScreenHeart.transform.position += (ScreenHeart.transform.position - Target.transform.position) * 20;
		Heartdis = 1.5f;
		NextCamPos = ScreenHeart.transform.position;

		ScreenHeart.transform.position = Target.transform.position;
		ScreenHeart.transform.Translate (new Vector3 (0,3,0));
		NextHeartPos = ScreenHeart.transform.position;

		if (MissionTargets.LastIndexOf (Target) == MissionTargets.Count)
			ScreenHeart.transform.position = NextHeartPos;
		else
			ScreenHeart.transform.position = LastHeartPos;
		/*if (Global.OnCubeNum == 1) {
			ScreenHeart.transform.Translate (new Vector3 (0, 6, 0));
			//print(Vector3.Distance(Target.transform.position, Vector3.zero)+1);
			//ScreenHeart.transform.Translate (new Vector3 (0, Vector3.Distance(Target.transform.position, Vector3.zero) + 1, 0));
			ScreenHeart.transform.position += (ScreenHeart.transform.position - Target.transform.position) * 5;
			Heartdis = 1.5f;
		}else if(Global.OnCubeNum == 2){
			ScreenHeart.transform.Translate (new Vector3 (0, 3, 0));
			ScreenHeart.transform.position += (ScreenHeart.transform.position - Target.transform.position) * 10;
			Heartdis = 2;
		}*/

		//NextCamPos = ScreenHeart.transform.position;
		//ScreenHeart.transform.position = ScreenHeart_Origin;
		Global.StopTouch = true;
		CamIsMoving = true;
		OS2 = true;
		return;

	}

	void Update ()
	{

		if (MissionTargets.Find ((x) => x.gameObject == null) == null && MissionTargets.IndexOf (MissionTargets.Find ((x) => x.gameObject == null)) != -1) {
			MissionArrows.RemoveAt (MissionTargets.IndexOf (MissionTargets.Find ((x) => x.gameObject == null)));
			MissionTargets.RemoveAt (MissionTargets.IndexOf (MissionTargets.Find ((x) => x.gameObject == null)));
		}


		/*
		if (MissionCam != null && MissionTarget != null && !MissionCamSetting && !FlowerChart.HasExecutingBlocks()) {
			print ("ok");
			MissionCam.transform.rotation = MissionTarget.transform.rotation;
			MissionCam.transform.position = Vector3.zero;
			MissionCam.transform.Translate(new Vector3 ((MissionCam.transform.position.x - MissionTarget.transform.position.x) * 7, MissionTarget.transform.position.y * 7, (MissionCam.transform.position.z - MissionTarget.transform.position.z) * 7));
			MissionCam.transform.LookAt (MissionTarget.transform);
			MissionCamObj.SetActive (true);

			if(Input.GetMouseButtonDown(0)){
				MissionCamSetting = true;
				MissionCamObj.SetActive (false);
			}
		}*/


		if (Global.LevelEnd == null)
			Global.LevelEnd = GameObject.Find ("Bool_LevelEnd");

		if (FlowerChart != null) {
			


			switch (Blocking) {
			case"開頭":

				MissionTargets.Add (GameObject.Find ("Event_Shop(Clone)"));
				CameraMove (GameObject.Find ("Event_Shop(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3(-0.5f, 5, -0.5f));

				Blocking = null;
				break;
			case"買麵包":
				Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Shop(Clone)"))]);
				MissionTargets.Clear ();
				MissionArrows.Clear ();
				MissionTargets.Add (GameObject.Find ("Event_Rose(Clone)"));
				CameraMove (GameObject.Find ("Event_Rose(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3(0, 4, 0));

				Blocking = null;
				break;
			case"給麵包":
				Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Rose(Clone)"))]);
				MissionTargets.Clear ();
				MissionArrows.Clear ();
				MissionTargets.Add (GameObject.Find ("Event_PrinceHome(Clone)"));
				CameraMove (GameObject.Find ("Event_PrinceHome(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3(0, 5, 0));

				Blocking = null;
				break;
			case"帶玫瑰回家":
				Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_PrinceHome(Clone)"))]);
				MissionTargets.Clear ();
				MissionArrows.Clear ();
				MissionTargets.Add (GameObject.Find ("Event_GlassRepair(Clone)"));
				CameraMove (GameObject.Find ("Event_GlassRepair(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3(0, 4, 1));

				Blocking = null;
				break;
			case"找爺爺":
				Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_GlassRepair(Clone)"))]);
				MissionTargets.Clear ();
				MissionArrows.Clear ();
				MissionTargets.Add (GameObject.Find ("Event_PrinceHome(Clone)"));
				CameraMove (GameObject.Find ("Event_PrinceHome(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3(0, 5, 0));

				Blocking = null;
				break;
			case"第二次回家":
				Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_PrinceHome(Clone)"))]);
				MissionTargets.Clear ();
				MissionArrows.Clear ();
				MissionTargets.Add (GameObject.Find ("Event_Mt.SpaceShip(Clone)"));
				CameraMove (GameObject.Find ("Event_Mt.SpaceShip(Clone)"), CameraController.CurrentCam, CameraController.CamTarget, new Vector3(-0.5f, 5, -1));

				Blocking = null;
				break;
			case"開飛船":
				if (FlowerChart.GetBooleanVariable ("Ship")) {
					Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Mt.SpaceShip(Clone)"))]);
					MissionTargets.Clear ();
					MissionArrows.Clear ();
				}
				Blocking = null;
				break;


			case"開頭對話":
				if (Global.Level == "2") {
					MissionTargets.Add (GameObject.Find ("Event_Lucas(Clone)"));
					MissionTargets.Add (GameObject.Find ("Event_Soyna(Clone)"));
					MissionTargets.Add (GameObject.Find ("Event_Riven(Clone)"));
					MissionTargets.Add (GameObject.Find ("Event_Sisco(Clone)"));
					CameraMove (MissionTargets [0], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 4, 0));
					MultiPos = new Vector3 (0, 4, 0);
					Blocking = null;
				}
				break;
			case"盧卡斯第一次對話":
				//Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Lucas(Clone)"))]);
				//Destroy (MissionArrows.Find((x) => x.name == "Event_Lucas(Clone)_MA"));
				if (MissionTargets.Contains(GameObject.Find ("Event_Lucas(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Lucas(Clone)")) {
					MissionArrows.FindLast ((x) => x.name == "Event_Lucas(Clone)").SetActive (false);
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
					MissionTargets.Add (GameObject.Find ("Event_IncinerationPlant(Clone)"));
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0));
				}
				Blocking = null;
				break;
			case"索依娜第一次對話":
				//Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Soyna(Clone)"))]);
				//Destroy (MissionArrows.Find((x) => x.name == "Event_Soyna(Clone)_MA"));
				if (MissionTargets.Contains(GameObject.Find ("Event_Soyna(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Soyna(Clone)")) {
					MissionArrows.FindLast ((x) => x.name == "Event_Soyna(Clone)").SetActive (false);
					MissionArrows.RemoveAt (MissionTargets.LastIndexOf (GameObject.Find ("Event_Soyna(Clone)")));
				
					MissionTargets.Remove (GameObject.Find ("Event_Soyna(Clone)"));
				}
				//MissionTargets.Add (GameObject.Find ("Event_Riven(Clone)"));
				//MissionTargets.Add (GameObject.Find ("Event_Station(Clone)"));
				//MissionTargets.Add (GameObject.Find ("Event_BattleShipWing(Clone)"));
				if (FlowerChart.GetBooleanVariable ("FindLeaf") == false && FlowerChart.GetBooleanVariable("GetLeaf") == false) {
					TargetID = MissionTargets.Count;
					if(GameObject.Find ("Redleaf_A") != null)
						MissionTargets.Add (GameObject.Find ("Redleaf_A"));
					if(GameObject.Find ("Redleaf_B") != null)
						MissionTargets.Add (GameObject.Find ("Redleaf_B"));
					if(GameObject.Find ("Redleaf_C") != null)
						MissionTargets.Add (GameObject.Find ("Redleaf_C"));
					CameraMove (MissionTargets [TargetID], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 1, 0));
					MultiPos = new Vector3 (0, 1, 0);
				}

				Blocking = null;
				break;
			case"瑞文第一次對話":
				//Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Riven(Clone)"))]);
				//Destroy (MissionArrows.Find((x) => x.name == "Event_Riven(Clone)_MA"));
				if (MissionTargets.Contains(GameObject.Find ("Event_Riven(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Riven(Clone)")) {
					MissionArrows.FindLast ((x) => x.name == "Event_Riven(Clone)").SetActive (false);
					MissionArrows.RemoveAt (MissionTargets.LastIndexOf (GameObject.Find ("Event_Riven(Clone)")));
				
					MissionTargets.Remove (GameObject.Find ("Event_Riven(Clone)"));
				}
				if (FlowerChart.GetBooleanVariable ("FindEngine") == false && FlowerChart.GetBooleanVariable("GetEngine") == false) {
					MissionTargets.Add (GameObject.Find ("Engine"));
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 1, 0));
				}
				Blocking = null;
				break;
			case"西斯寇第一次對話":
				//Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Sisco(Clone)"))]);
				//Destroy (MissionArrows.Find((x) => x.name == "Event_Sisco(Clone)_MA"));
				if (MissionTargets.Contains(GameObject.Find ("Event_Sisco(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Sisco(Clone)")) {
					MissionArrows.FindLast ((x) => x.name == "Event_Sisco(Clone)").SetActive (false);
					MissionArrows.RemoveAt (MissionTargets.LastIndexOf (GameObject.Find ("Event_Sisco(Clone)")));
				
					MissionTargets.Remove (GameObject.Find ("Event_Sisco(Clone)"));
				}
				if (FlowerChart.GetBooleanVariable ("FindKyder") == false && FlowerChart.GetBooleanVariable("GetKyder") == false) {
					MissionTargets.Add (GameObject.Find ("Event_Station(Clone)"));
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 5, 0));
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
				if (MissionTargets.Contains(GameObject.Find ("Event_IncinerationPlant(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_IncinerationPlant(Clone)")) {
					MissionTargets.Remove (GameObject.Find ("Event_IncinerationPlant(Clone)"));
					MissionTargets.Add (GameObject.Find ("Event_Lucas(Clone)"));
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 4, 0));
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
				if (MissionTargets.Contains(GameObject.Find ("Redleaf_A")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Redleaf_A"))
					MissionTargets.Remove (GameObject.Find ("Redleaf_A"));
				if (MissionTargets.Contains(GameObject.Find ("Redleaf_B")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Redleaf_B"))
					MissionTargets.Remove (GameObject.Find ("Redleaf_B"));
				if (MissionTargets.Contains(GameObject.Find ("Redleaf_C")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Redleaf_C")) {
					MissionTargets.Remove (GameObject.Find ("Redleaf_C"));
					MissionTargets.Add (GameObject.Find ("Event_Soyna(Clone)"));
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 4, 0));
				}
				Blocking = null;
				break;
			case"控制引擎變數":

				/*if(MissionArrows.Contains(GameObject.Find ("Event_Riven(Clone)_MA")))
					Destroy (MissionArrows.Find((x) => x.name == "Event_Riven(Clone)_MA"));*/
				if (MissionTargets.Contains(GameObject.Find ("Engine")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Engine")) {
					MissionTargets.Remove (GameObject.Find ("Engine"));
					MissionTargets.Add (GameObject.Find ("Event_Riven(Clone)"));
				
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 4, 0));
				}
				Blocking = null;
				break;
			case"控制水晶變數":

				/*if(MissionArrows.Contains(GameObject.Find ("Event_Station(Clone)_MA")))
					Destroy (MissionArrows [MissionTargets.LastIndexOf (GameObject.Find ("Event_Station(Clone)"))]);*/
				if (MissionTargets.Contains(GameObject.Find ("Event_Station(Clone)")) && MissionArrows.FindLast ((x) => x.gameObject != null && x.name == "Event_Station(Clone)")) {
					MissionTargets.Remove (GameObject.Find ("Event_Station(Clone)"));
					MissionTargets.Add (GameObject.Find ("Event_Sisco(Clone)"));
				
					CameraMove (MissionTargets [MissionTargets.Count - 1], CameraController.CurrentCam, CameraController.CamTarget, new Vector3 (0, 4, 0));
				}
				Blocking = null;
				break;

			}

			if (CurrentCam != null && ScreenHeart != null && Target != null && !FlowerChart.HasExecutingBlocks () && CamIsMoving) {
				

				if (Vector3.Distance (CurrentCam.transform.position, NextCamPos) <= 0.2f) {
					//ScreenHeart.transform.position = Vector3.Lerp (ScreenHeart.transform.position, Target.transform.position * Heartdis, 0.02f);
					//ScreenHeart.transform.position = NextHeartPos;
					MissionArrows [MissionArrows.Count-1].SetActive (true);
					CamRotTarget = Quaternion.LookRotation (ScreenHeart.transform.position - CurrentCam.transform.position, Vector3.Lerp (CurrentCam.transform.up, Target.transform.up, 0.1f));
					CurrentCam.transform.rotation = Quaternion.Slerp (CurrentCam.transform.rotation, CamRotTarget, 0.2f);
					if (OS2) {
						//CurrentCam.transform.position = NextCamPos;
						OS2 = false;
					}
					if (Input.GetMouseButtonDown (0)) {
						if (MissionTargets.LastIndexOf (Target) != MissionTargets.Count-1) {
							print (MissionTargets.LastIndexOf (Target));
							TargetID++;
							CameraMove (MissionTargets[TargetID], CameraController.CurrentCam, CameraController.CamTarget, MultiPos);

						} else if (MissionTargets.LastIndexOf (Target) == MissionTargets.Count-1) {
							TargetID++;
							CamIsMoving = false;
							CamIsMovingBack = true;
							Global.StopTouch = true;
							OS2 = true;
						}
					}

					} else {
					ScreenHeart.transform.position = Vector3.Lerp (ScreenHeart.transform.position, NextHeartPos, 0.03f);
					CurrentCam.transform.position = Vector3.Lerp (CurrentCam.transform.position, NextCamPos, 0.03f);

					//ScreenHeart.transform.position = Vector3.MoveTowards (ScreenHeart.transform.position, NextHeartPos, 0.3f);
					//CurrentCam.transform.position = Vector3.MoveTowards (CurrentCam.transform.position, NextCamPos, 0.3f);

					//FixedRot = Vector3.Lerp (FixedRot, Target.transform.up, 0.2f);
					CamRotTarget = Quaternion.LookRotation (ScreenHeart.transform.position - CurrentCam.transform.position, Vector3.Lerp (CurrentCam.transform.up, Target.transform.up, 0.1f));
					CurrentCam.transform.rotation = Quaternion.Slerp (CurrentCam.transform.rotation, CamRotTarget, 0.6f);
						//CamRotTarget = Quaternion.LookRotation (Target.transform.position - CurrentCam.transform.position, FixedRot);

						}
				} else if (CurrentCam != null && ScreenHeart != null && Target != null && !CamIsMoving && CamIsMovingBack) {
					if (Vector3.Distance (CurrentCam.transform.position, CurrentCam_Origin) <= 0.3f) {
						
						if (OS2) {
							OS2 = false;
						}
						//MissionTargets.Clear();
						//MissionArrows.Clear ();
						
						TargetID = 0;
						//CurrentCam.transform.rotation = Quaternion.Slerp (CurrentCam.transform.rotation, CamRotTarget, 1f);
						ScreenHeart.transform.position = ScreenHeart_Origin;
						//CurrentCam.transform.position = CurrentCam_Origin;
						ScreenHeart.transform.rotation = ScreenHeart_OriginRot;
						CurrentCam = ScreenHeart = Target = null;
						Global.StopTouch = false;
						CamIsMovingBack = false;

					} else {
					ScreenHeart.transform.position = Vector3.Lerp (ScreenHeart.transform.position, ScreenHeart_Origin, 0.04f);
					CurrentCam.transform.position = Vector3.Lerp (CurrentCam.transform.position, CurrentCam_Origin, 0.04f);
						//ScreenHeart.transform.position = Vector3.MoveTowards (ScreenHeart.transform.position, ScreenHeart_Origin, 0.3f);
						//CurrentCam.transform.position = Vector3.MoveTowards (CurrentCam.transform.position, CurrentCam_Origin, 0.3f);
					//FixedRot = Vector3.Lerp (FixedRot, Vector3.up, 0.2f);
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
						Global.NextScene = 3;
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
						Global.NextScene = 4;
						Oneshot = false;
					}
				}


			}

			// 對話時停止移動、轉動
			if (FlowerChart != null) {
				if (FlowerChart.HasExecutingBlocks () && BlockOn == false) {
					BlockOn = true;
					Global.StopTouch = true;
					PlayerStatusImage.Status = "IsTalking";


					CameraController.OriginView = Camera.main.fieldOfView;
					//CameraController.CamView = 10;

				} else if (!FlowerChart.HasExecutingBlocks () && BlockOn == true && !CamIsMoving) {
					BlockOn = false;
					if (!CamIsMovingBack)
						Global.StopTouch = false;
					PlayerStatusImage.Status = null; 

					CameraController.CamView = CameraController.OriginView;

				}
			}



		

	}
}
