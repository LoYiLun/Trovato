using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MissionSetting : MonoBehaviour {
	public static Flowchart FlowerChart;
	bool BlockOn;

	void Start () {
		if (Global.Level == "1") {
			FlowerChart = GameObject.Find("MainFlowChart").GetComponent<Flowchart>();
		}
		if (Global.Level == "2") {
			FlowerChart = GameObject.Find("Level02Main").GetComponent<Flowchart>();
		}
		if (Global.Level == "3") {
			FlowerChart = GameObject.Find("對話").GetComponent<Flowchart>();
		}


	}


	void Update () {

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
