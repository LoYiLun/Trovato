using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseMove : MonoBehaviour {

	//bool Go{ get{ return MissionSetting.FlowerChart.GetBooleanVariable("RoseMove"); }}
	bool Go;
	int count;
	GameObject Prince{ get{ return GameObject.Find ("Player"); }}
	GameObject PrinceHome{ get{ return GameObject.Find ("PrinceHome_Door"); }}


	void Start () {

	}


	void Update () {
		if (MissionSetting.FlowerChart != null) {
			Go = MissionSetting.FlowerChart.GetBooleanVariable ("RoseMove");
		

			if (Go && MissionSetting.FlowerChart.FindBlock ("給麵包").IsExecuting ()) {
				this.GetComponent<Collider> ().enabled = false;

				// 玫瑰移動
				
				this.transform.position = Vector3.MoveTowards (this.transform.position, Prince.transform.position, 0.03f);
				this.transform.LookAt (Prince.transform.position);
				if (Vector3.Distance (this.transform.position, Prince.transform.position) < 0.01f) {
					//this.transform.SetParent (Prince.transform);
					//this.transform.GetChild (0).gameObject.SetActive (false);
					//this.transform.GetChild (1).gameObject.SetActive (false);
					this.transform.position = new Vector3(10000, 10000, 10000);
				}


			} else if (Go && MissionSetting.FlowerChart.FindBlock ("帶玫瑰回家").IsExecuting ()) {

				if (count != 1) {
					//this.transform.GetChild (0).gameObject.SetActive (true);
					//this.transform.GetChild (0).gameObject.SetActive (true);
					this.transform.position = Global.Player.transform.position;
					this.transform.LookAt (PrinceHome.transform.position);
					this.transform.Translate (1, 0, 0);

					this.transform.LookAt (Global.Player.transform.position);
					Global.Player.transform.LookAt (this.transform.position);
					count = 1;
				}

				if (MissionSetting.FlowerChart.FindBlock ("帶玫瑰回家").ActiveCommand.ItemId == 98) {
					this.transform.GetChild (0).gameObject.SetActive (false);
					this.transform.GetChild (1).gameObject.SetActive (false);

					/*
					this.transform.position = Vector3.MoveTowards (this.transform.position, PrinceHome.transform.position, 0.03f);
					this.transform.LookAt (PrinceHome.transform.position);
					if (Vector3.Distance (this.transform.position, PrinceHome.transform.position) < 0.01f) {
						this.transform.SetParent (PrinceHome.transform.parent);
						this.transform.GetChild (0).gameObject.SetActive (false);
						this.transform.GetChild (1).gameObject.SetActive (false);
					}*/
				}
			}
		}
	}

}
