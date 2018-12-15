using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseMove : MonoBehaviour {

	//bool Go{ get{ return MissionSetting.FlowerChart.GetBooleanVariable("RoseMove"); }}
	bool Go;
	GameObject Prince{ get{ return GameObject.Find ("Player"); }}
	GameObject PrinceHome{ get{ return GameObject.Find ("PrinceHome_Door"); }}

	void Start () {
		
	}


	void Update () {
		if (MissionSetting.FlowerChart != null) {
			Go = MissionSetting.FlowerChart.GetBooleanVariable ("RoseMove");
		

			if (Go && MissionSetting.FlowerChart.FindBlock ("給麵包").IsExecuting ()) {
				this.GetComponent<Collider> ().enabled = false;
				this.transform.position = Vector3.MoveTowards (this.transform.position, Prince.transform.position, 0.03f);
				this.transform.LookAt (Prince.transform.position);
				if (Vector3.Distance (this.transform.position, Prince.transform.position) < 0.01f) {
					this.transform.SetParent (Prince.transform);
					this.transform.GetChild (0).gameObject.SetActive (false);
				}
			} else if (Go && MissionSetting.FlowerChart.FindBlock ("帶玫瑰回家").IsExecuting ()) {
				this.transform.GetChild (0).gameObject.SetActive (true);
				this.transform.position = Vector3.MoveTowards (this.transform.position, PrinceHome.transform.position, 0.03f);
				this.transform.LookAt (PrinceHome.transform.position);
				if (Vector3.Distance (this.transform.position, PrinceHome.transform.position) < 0.01f) {
					this.transform.SetParent (PrinceHome.transform.parent);
					this.transform.GetChild (0).gameObject.SetActive (false);
				}
			}
		}
	}

}
