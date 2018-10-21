using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MissionSetting : MonoBehaviour {
	public static Flowchart FlowerChart;
	public Flowchart GetFlowChart;
	bool BlockOn;
	bool Oneshot;
	int NextLevel;

	void Start () {
		if(GetFlowChart != null)
		FlowerChart = GetFlowChart;


	}


	void FixedUpdate () {
		if(Global.LevelEnd == null)
			Global.LevelEnd = GameObject.Find("Bool_LevelEnd");

		// 第一章結尾
		if (Global.Level == "1") {
			if (FlowerChart.HasExecutingBlocks () && FlowerChart.SelectedBlock.BlockName == "開飛船") {
				if (Level01PlayerEvent.Ship && !Oneshot) {
					Oneshot = true;
				}
			} else if (!Level01PlayerEvent.Ship && Oneshot) {
				GameObject.Find ("SpaceShip_Anim").GetComponent<Animation> ().Play ("Fly");
				CameraFade.FadeOut();
				Global.Player.SetActive (false);
				Global.NextScene = 3;
				Oneshot = false;

			}
		}

		if (Global.Level == "2") {
			if (FlowerChart.HasExecutingBlocks () && FlowerChart.SelectedBlock.BlockName == "閃人") {
				if (!Oneshot && FlowerChart.GetBooleanVariable ("PushBox01") && FlowerChart.GetBooleanVariable ("FindLeaf") && FlowerChart.GetBooleanVariable ("FindEngine") && FlowerChart.GetBooleanVariable ("FindKyder")) {
					Oneshot = true;
				}
			} else if (Oneshot) {
				GameObject.Find ("SpaceShip_Anim").GetComponent<Animation> ().Play ("Fly2");
				CameraFade.FadeOut();
				Global.Player.SetActive (false);
				Global.NextScene = 4;
				Oneshot = false;
			}
		}


		// 對話時停止移動、轉動
		if (FlowerChart.HasExecutingBlocks () && BlockOn == false) {
			BlockOn = true;
			Global.StopTouch = true;
			PlayerStatusImage.Status = "IsTalking";
		} else if (!FlowerChart.HasExecutingBlocks () && BlockOn == true) {
			BlockOn = false;
			Global.StopTouch = false;
			PlayerStatusImage.Status = null; 
		}


	}
		

}
