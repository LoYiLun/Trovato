using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGet : MonoBehaviour {

	int BreadSwitch = 0;
	GameObject Bread{get { return GameObject.Find("Bread");}}
	GameObject Item_1 {get { return GameObject.Find ("Img_Item1");}}
	GameObject Item_2 {get { return GameObject.Find ("Img_Item2");}}
	GameObject Item_3 {get { return GameObject.Find ("Img_Item3");}}

	void Start () {
		
	}
	

	void Update () {
		if (MissionSetting.FlowerChart != null) {

			if (MissionSetting.FlowerChart.FindBlock ("買麵包") != null && MissionSetting.FlowerChart.FindBlock ("買麵包").IsExecuting () && Bread != null && Bread.activeSelf) {
				Bread.GetComponent<Renderer> ().enabled = true;
				PlayerStatusImage.GetStatus ("None");
				Bread.transform.position = Vector3.MoveTowards (Bread.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0), 0.02f);
				if (Vector3.Distance (Bread.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0)) < 0.01f) {
					Bread.SetActive (false);
				}
			}
		}
	}
}
