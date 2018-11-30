using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusImage : MonoBehaviour {

	public static string Status;
	public Sprite text1;
	public Sprite text2;
	public Sprite text3;
	public Sprite text4;
	public Sprite PressE;
	bool statusing;

	void Start () {
		//PressE = Resources.Load ("Images/PressE") as Sprite;
	}
	

	void Update () {
		if (!statusing) {
			if (Status == "IsTalking" && !statusing) {
				
				GetComponent<Image> ().enabled = true;
				StartCoroutine (IsTalking ());

			} else if (Status == "Interact?") {
				statusing = true;
				GetComponent<Image> ().enabled = true;
				GetComponent<Image> ().sprite = PressE;
			}
		} else if(Status == null){
			GetComponent<Image> ().enabled = false;
			statusing = false;
		}
	}

	IEnumerator IsTalking(){
		for (float i = 0; i < 10f; i += Time.deltaTime) {
			statusing = true;
			GetComponent<Image> ().sprite = text1;
			yield return new WaitForSeconds (0.6f);
			GetComponent<Image> ().sprite = text2;
			yield return new WaitForSeconds (0.2f);
			GetComponent<Image> ().sprite = text3;
			yield return new WaitForSeconds (0.2f);
			GetComponent<Image> ().sprite = text4;
			yield return new WaitForSeconds (0.2f);

			if (Status == null || Global.PlayerMove) {
				statusing = false;
				GetComponent<Image> ().enabled = false;
				yield break;
			}

			yield return 0;

		}

	}
}
