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
	bool statusing;
	float Dis;

	void Start () {
		
	}

	void FixedUpdate () {


		if (statusing != true) {
			if (Status == "IsTalking") {
				
				GetComponent<Image> ().enabled = true;
				StartCoroutine (IsTalking ());

			}
		}
	}

	IEnumerator IsTalking(){
		for (float i = 0; i < 5f; i += Time.deltaTime) {
			statusing = true;
			GetComponent<Image> ().sprite = text1;
			yield return new WaitForSeconds (0.6f);
			GetComponent<Image> ().sprite = text2;
			yield return new WaitForSeconds (0.2f);
			GetComponent<Image> ().sprite = text3;
			yield return new WaitForSeconds (0.2f);
			GetComponent<Image> ().sprite = text4;
			yield return new WaitForSeconds (0.2f);

			if (Status == null) {
				statusing = false;
				GetComponent<Image> ().enabled = false;
				Status = null;
				yield break;
			}

			yield return 0;

		}

	}
}
