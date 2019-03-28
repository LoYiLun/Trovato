using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGet : MonoBehaviour {

	GameObject Bread{get { return GameObject.Find("Bread");}}
	GameObject Key{get { return GameObject.Find("Key");}}

	GameObject Booster{get { return GameObject.Find("Booster");}}
	GameObject FireBottle{get { return GameObject.Find("FireBottle");}}

	GameObject Item_1 {get { return GameObject.Find ("Img_Item1");}}
	GameObject Item_2 {get { return GameObject.Find ("Img_Item2");}}
	GameObject Item_3 {get { return GameObject.Find ("Img_Item3");}}
	GameObject Spotlight{get { return GameObject.Find ("Image_Spotlight");}}
	Vector3 MidScreen;

	void Awake(){
		MidScreen = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Item_1.transform.rotation = Quaternion.Euler (0, 90, 0);
		Item_2.transform.rotation = Quaternion.Euler (0, 90, 0);
		Item_3.transform.rotation = Quaternion.Euler (0, 90, 0);
	}

	void Start () {
		
	}
	

	void Update () {
		if (MissionSetting.FlowerChart != null) {

			// Light
			if(Spotlight != null){
				switch (MissionSetting.FlowerChart.GetIntegerVariable ("ItemLight")) {
				case 0:
					Spotlight.GetComponent<Image> ().enabled = false;
					Spotlight.transform.position = Vector3.Lerp (Spotlight.transform.position, MidScreen, 10*Time.deltaTime);
					break;
				case 1:
					Spotlight.GetComponent<Image> ().enabled = true;
					Spotlight.transform.position = Vector3.Lerp (Spotlight.transform.position, Item_1.transform.position, 5 * Time.deltaTime);
					if(Item_1.transform.rotation != Quaternion.Euler(0, 0, 0))
						Item_1.transform.rotation *= Quaternion.Euler (0, -100 * Time.deltaTime, 0);
					Item_1.GetComponent<Image> ().color = new Color (255, 255, 255, 1);
					Item_2.GetComponent<Image> ().color = new Color (255, 255, 255, 0.3f);
					Item_3.GetComponent<Image> ().color = new Color (255, 255, 255, 0.3f);
					break;
				case 2:
					Spotlight.GetComponent<Image> ().enabled = true;
					Spotlight.transform.position = Vector3.Lerp (Spotlight.transform.position, Item_2.transform.position, 5 * Time.deltaTime);
					Item_1.transform.rotation = Quaternion.Euler (0, 0, 0);
					if(Item_2.transform.rotation != Quaternion.Euler(0, 0, 0))
						Item_2.transform.rotation *= Quaternion.Euler (0, -100 * Time.deltaTime, 0);
					Item_1.GetComponent<Image> ().color = new Color (255, 255, 255, 0.3f);
					Item_2.GetComponent<Image> ().color = new Color (255, 255, 255, 1);
					Item_3.GetComponent<Image> ().color = new Color (255, 255, 255, 0.3f);
					break;
				case 3:
					Spotlight.GetComponent<Image> ().enabled = true;
					Spotlight.transform.position = Vector3.Lerp (Spotlight.transform.position, Item_3.transform.position, 5 * Time.deltaTime);
					Item_2.transform.rotation = Quaternion.Euler (0, 0, 0);
					if(Item_3.transform.rotation != Quaternion.Euler(0, 0, 0))
						Item_3.transform.rotation *= Quaternion.Euler (0, -100 * Time.deltaTime, 0);
					Item_1.GetComponent<Image> ().color = new Color (255, 255, 255, 0.3f);
					Item_2.GetComponent<Image> ().color = new Color (255, 255, 255, 0.3f);
					Item_3.GetComponent<Image> ().color = new Color (255, 255, 255, 1);
					break;
				case 4:
					Spotlight.GetComponent<Image> ().enabled = true;
					Item_3.transform.rotation = Quaternion.Euler (0, 0, 0);
					Item_1.GetComponent<Image> ().color = new Color (255, 255, 255, 0.3f);
					Item_2.GetComponent<Image> ().color = new Color (255, 255, 255, 0.3f);
					Item_3.GetComponent<Image> ().color = new Color (255, 255, 255, 0.3f);
					break;
				}
			}

			if (Global.Level == "1") {
				if (MissionSetting.FlowerChart.FindBlock ("買麵包") != null && MissionSetting.FlowerChart.FindBlock ("買麵包").IsExecuting () && Bread != null && Bread.activeSelf) {
					Bread.GetComponent<Renderer> ().enabled = true;
					PlayerStatusImage.GetStatus ("None");
					Bread.transform.position = Vector3.MoveTowards (Bread.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0), 0.02f);
					if (Vector3.Distance (Bread.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0)) < 0.01f) {
						Bread.SetActive (false);
					}
				}

				if (MissionSetting.FlowerChart.GetBooleanVariable ("TakeKey")) {
					Key.transform.GetChild (0).GetComponent<Renderer> ().enabled = true;
					Key.transform.GetChild (1).GetComponent<Renderer> ().enabled = true;
					PlayerStatusImage.GetStatus ("None");
					Key.transform.position = Vector3.MoveTowards (Key.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0), 0.02f);
					if (Vector3.Distance (Key.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0)) < 0.01f) {
						Key.transform.GetChild (0).GetComponent<Renderer> ().enabled = false;
						Key.transform.GetChild (1).GetComponent<Renderer> ().enabled = false;
					}
				}
			}

			if (Global.Level == "2") {
				if (MissionSetting.FlowerChart.GetBooleanVariable ("TakeBooster")) {
					Booster.GetComponent<Renderer> ().enabled = true;
					PlayerStatusImage.GetStatus ("None");
					Booster.transform.position = Vector3.MoveTowards (Booster.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0), 0.02f);
					if (Vector3.Distance (Booster.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0)) < 0.01f) {
						Booster.GetComponent<Renderer> ().enabled = false;
						Item_1.GetComponent<Image> ().color = new Color (255, 255, 255, 1);
					}
				}

				if (MissionSetting.FlowerChart.GetBooleanVariable ("TakeFire")) {
					//FireBottle.GetComponent<Renderer> ().enabled = true;
					showRenderer(FireBottle, true);
					PlayerStatusImage.GetStatus ("None");
					FireBottle.transform.position = Vector3.MoveTowards (FireBottle.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0), 0.02f);
					if (Vector3.Distance (FireBottle.transform.position, Global.Player.transform.position + new Vector3 (0, 1, 0)) < 0.01f) {
						showRenderer (FireBottle, false);
						Item_2.GetComponent<Image> ().color = new Color (255, 255, 255, 1);
					}
				}

				if (MissionSetting.FlowerChart.GetBooleanVariable ("TakeOil")) {
					PlayerStatusImage.GetStatus ("None");
					Item_3.GetComponent<Image> ().color = new Color (255, 255, 255, 1);
				}
			}

			if (Global.Level == "3") {
				
			}

		}
	}

	public void showRenderer(GameObject item, bool status){
		if (item.transform.childCount == 0) {
			item.GetComponent<Renderer> ().enabled = status;
		} else {
			for (int i = 0; i < item.transform.childCount - 1; i++)
				item.transform.GetChild (i).GetComponent<Renderer> ().enabled = status;
		}
	}
}
