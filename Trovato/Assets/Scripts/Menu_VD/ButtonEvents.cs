using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour {

	public GameObject Panel_MainMenu;
	public GameObject Panel_SelectMode;
	public GameObject Group_SelectMode;
	public GameObject BigGroup;
	public GameObject Text_AnyInput;
	public GameObject Image_Title;
	float AlphaTime;

	void Awake(){
		/*Panel_MainMenu = GameObject.Find ("Panel_MainMenu");
		Panel_SelectMode = GameObject.Find ("Panel_SelectMode");
		Group_SelectMode = GameObject.Find ("Group_SelectMode");
		BigGroup = GameObject.Find ("BigGroup");*/
	}

	void Start () {
		
	}
	

	void Update () {
		AlphaTime = Time.time * 6f % 20;
		if (AlphaTime <= 10) {
			Text_AnyInput.GetComponent<Text> ().color = new Color (255, 255, 255, AlphaTime / 10 + 0.3f);
			Image_Title.transform.Translate (0, 0.05f, 0);
		} else if (AlphaTime > 10) {
			Text_AnyInput.GetComponent<Text> ().color = new Color (255, 255, 255, 1 - (AlphaTime - 10) / 10 + 0.3f);
			Image_Title.transform.Translate (0, -0.05f, 0);
		}

		if (Input.anyKeyDown && Panel_MainMenu.GetComponent<CanvasGroup> ().interactable == true) {
			ToSelectMode ();
		}

		if (Panel_MainMenu.GetComponent<CanvasGroup> ().interactable == false && Panel_MainMenu.GetComponent<CanvasGroup> ().alpha > 0) {
			Panel_MainMenu.GetComponent<CanvasGroup> ().alpha -= 0.05f;
		}else if (Panel_MainMenu.GetComponent<CanvasGroup> ().interactable == true && Panel_MainMenu.GetComponent<CanvasGroup> ().alpha < 1) {
			Panel_MainMenu.GetComponent<CanvasGroup> ().alpha += 0.05f;
		}

		if (Panel_SelectMode.GetComponent<CanvasGroup> ().interactable == false && Panel_SelectMode.GetComponent<CanvasGroup> ().alpha > 0) {
			Panel_SelectMode.GetComponent<CanvasGroup> ().alpha -= 0.05f;
		}else if (Panel_SelectMode.GetComponent<CanvasGroup> ().interactable == true && Panel_SelectMode.GetComponent<CanvasGroup> ().alpha < 1) {
			Panel_SelectMode.GetComponent<CanvasGroup> ().alpha += 0.05f;
		}


	}

	public void ToMainMenu(){
		//Panel_MainMenu.GetComponent<CanvasGroup> ().alpha = 1;
		Panel_MainMenu.GetComponent<CanvasGroup> ().interactable = true;
		Panel_MainMenu.GetComponent<CanvasGroup> ().blocksRaycasts = true;

		//Panel_SelectMode.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_SelectMode.GetComponent<CanvasGroup> ().interactable = false;
		Panel_SelectMode.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		Group_SelectMode.SetActive (false);
		BigGroup.SetActive (false);

	}

	public void ToSelectMode(){
		//Panel_MainMenu.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_MainMenu.GetComponent<CanvasGroup> ().interactable = false;
		Panel_MainMenu.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		//Panel_SelectMode.GetComponent<CanvasGroup> ().alpha = 1;
		Panel_SelectMode.GetComponent<CanvasGroup> ().interactable = true;
		Panel_SelectMode.GetComponent<CanvasGroup> ().blocksRaycasts = true;

		Group_SelectMode.SetActive (true);
		BigGroup.SetActive (false);

	}

	public void ToStory(){
		//Panel_MainMenu.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_MainMenu.GetComponent<CanvasGroup> ().interactable = false;
		Panel_MainMenu.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		//Panel_SelectMode.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_SelectMode.GetComponent<CanvasGroup> ().interactable = false;
		Panel_SelectMode.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		Group_SelectMode.SetActive (false);
		BigGroup.SetActive (true);

	}

	public void ToMOD(){
		//Panel_MainMenu.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_MainMenu.GetComponent<CanvasGroup> ().interactable = false;
		Panel_MainMenu.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		//Panel_SelectMode.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_SelectMode.GetComponent<CanvasGroup> ().interactable = false;
		Panel_SelectMode.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		Group_SelectMode.SetActive (false);
		BigGroup.SetActive (false);

		Global.ResetVar ();
		SceneManager.LoadScene ("Level_00");

	}
}
