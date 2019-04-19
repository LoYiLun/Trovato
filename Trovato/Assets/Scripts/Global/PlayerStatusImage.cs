using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusImage : MonoBehaviour {

	public static PlayerStatusImage instance;
	public static string Status;
	public static Image StatusImage;
	public Sprite text1;
	public Sprite text2;
	public Sprite text3;
	public Sprite text4;
	public Sprite PressE;

	void Awake(){
		instance = this;
		StatusImage = GetComponent<Image> ();
	}

	void Start () {
		//PressE = Resources.Load ("Images/PressE") as Sprite;

	}
	public static void GetStatus(string _Status){
		Status = _Status;
		instance.StatusPlay ();
	}

	void StatusPlay(){

		switch (Status) {
		case"IsTalking":
			//StatusImage.enabled = true;
			//StartCoroutine (IsTalking ());
			//Status = "None";

			break;
		case"Interact?":
			//StatusImage.enabled = false; // 隱藏提示E
			StatusImage.enabled = true;
			StatusImage.sprite = PressE;
			Status = "None";
			break;
		case"None":
			StatusImage.enabled = false;
			break;
		default:
			StatusImage.enabled = false;
			break;
		}
	}

	void Update () {
		
	}

	 IEnumerator IsTalking(){
		for (float i = 0; i < 10f; i += Time.deltaTime) {
			GetComponent<Image> ().sprite = text1;
			yield return new WaitForSeconds (0.6f);
			GetComponent<Image> ().sprite = text2;
			yield return new WaitForSeconds (0.2f);
			GetComponent<Image> ().sprite = text3;
			yield return new WaitForSeconds (0.2f);
			GetComponent<Image> ().sprite = text4;
			yield return new WaitForSeconds (0.2f);

			if (Status == null || Global.PlayerMove) {
				GetComponent<Image> ().enabled = false;
				yield break;
			}

			yield return 0;

		}

	}
}
