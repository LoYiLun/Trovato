using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour {

	public GameObject Panel_MainMenu;
	public GameObject Panel_SelectMode;
	public GameObject Group_SelectMode;
	//public GameObject BigGroup;
	public GameObject Group_Levels;
	public GameObject LevelWheel;
	public GameObject Image_AnyInput;
	public GameObject Image_Title;
	public GameObject[] Levels;

	private float AlphaTime;
	private bool SwitchLevel;
	private int LevelIndex = 1; // 目前關卡
	private int LevelCount = 3; // 關卡數量
	private int RotationY;


	void Awake(){
		Group_Levels.SetActive(false);
	}

	void FixedUpdate () {

		// "按任意鍵開始"的效果
		AlphaTime = Time.time * 6f % 20;
		if (AlphaTime <= 10) {
			Image_AnyInput.GetComponent<Image> ().color = new Color (255, 255, 255, AlphaTime / 10 + 0.3f);
			Image_Title.transform.Translate (0, 0.1f * Time.deltaTime, 0);
		} else if (AlphaTime > 10) {
			Image_AnyInput.GetComponent<Image> ().color = new Color (255, 255, 255, 1 - (AlphaTime - 10) / 10 + 0.3f);
			Image_Title.transform.Translate (0, -0.1f * Time.deltaTime, 0);
		}

		// 切換至選模式畫面
		if (Input.anyKeyDown && Panel_MainMenu.GetComponent<CanvasGroup> ().interactable == true) {
			ToSelectMode ();
		}

		// 主畫面淡入淡出
		if (Panel_MainMenu.GetComponent<CanvasGroup> ().interactable == false && Panel_MainMenu.GetComponent<CanvasGroup> ().alpha > 0) {
			Panel_MainMenu.GetComponent<CanvasGroup> ().alpha -= 0.05f;
		}else if (Panel_MainMenu.GetComponent<CanvasGroup> ().interactable == true && Panel_MainMenu.GetComponent<CanvasGroup> ().alpha < 1) {
			Panel_MainMenu.GetComponent<CanvasGroup> ().alpha += 0.05f;
		}

		// 選模式畫面淡入淡出
		if (Panel_SelectMode.GetComponent<CanvasGroup> ().interactable == false && Panel_SelectMode.GetComponent<CanvasGroup> ().alpha > 0) {
			Panel_SelectMode.GetComponent<CanvasGroup> ().alpha -= 0.05f;
		}else if (Panel_SelectMode.GetComponent<CanvasGroup> ().interactable == true && Panel_SelectMode.GetComponent<CanvasGroup> ().alpha < 1) {
			Panel_SelectMode.GetComponent<CanvasGroup> ().alpha += 0.05f;
		}

		if(SwitchLevel){
			LevelWheel.transform.rotation = Quaternion.RotateTowards(LevelWheel.transform.rotation, Quaternion.Euler(0, RotationY, 0), 250 * Time.deltaTime);
			if(LevelWheel.transform.rotation == Quaternion.Euler(0, RotationY, 0)){
				Levels[LevelIndex - 1].GetComponent<Collider>().enabled = true;
				SwitchLevel = false;
			}
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
		//BigGroup.SetActive (false);
		Group_Levels.SetActive(false);

	}

	public void ToSelectMode(){
		//Panel_MainMenu.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_MainMenu.GetComponent<CanvasGroup> ().interactable = false;
		Panel_MainMenu.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		//Panel_SelectMode.GetComponent<CanvasGroup> ().alpha = 1;
		Panel_SelectMode.GetComponent<CanvasGroup> ().interactable = true;
		Panel_SelectMode.GetComponent<CanvasGroup> ().blocksRaycasts = true;

		Group_SelectMode.SetActive (true);
		//BigGroup.SetActive (false);
		Group_Levels.SetActive(false);

		Panel_MainMenu.transform.parent.gameObject.SetActive(true);

	}

	// 選擇故事模式
	public void ToStory(){
		//Panel_MainMenu.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_MainMenu.GetComponent<CanvasGroup> ().interactable = false;
		Panel_MainMenu.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		//Panel_SelectMode.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_SelectMode.GetComponent<CanvasGroup> ().interactable = false;
		Panel_SelectMode.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		Group_SelectMode.SetActive (false);
		//BigGroup.SetActive (true);
		Group_Levels.SetActive(true);

		Panel_MainMenu.transform.parent.gameObject.SetActive(false);

	}

	// 選擇編輯模式
	public void ToMOD(){
		//Panel_MainMenu.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_MainMenu.GetComponent<CanvasGroup> ().interactable = false;
		Panel_MainMenu.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		//Panel_SelectMode.GetComponent<CanvasGroup> ().alpha = 0;
		Panel_SelectMode.GetComponent<CanvasGroup> ().interactable = false;
		Panel_SelectMode.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		//Group_SelectMode.SetActive (false);
		//BigGroup.SetActive (false);

		Global.ResetVar ();
		SceneManager.LoadScene ("Level_00");

	}

	public void PrevLevel(){
		if(!SwitchLevel){
			foreach(GameObject level in Levels)
				level.GetComponent<Collider>().enabled = false;
			LevelIndex = (LevelIndex - 1);
			if(LevelIndex == 0)
				LevelIndex = LevelCount;
			RotationY = (360 / LevelCount) * (LevelIndex - 1);

			SwitchLevel = true;
		}
	}

	public void NextLevel(){
		if(!SwitchLevel){
			foreach(GameObject level in Levels)
				level.GetComponent<Collider>().enabled = false;
			LevelIndex = (LevelIndex + 1);
			if( LevelIndex == (LevelCount + 1) )
				LevelIndex = 1;
			RotationY = (360 / LevelCount) * (LevelIndex - 1);
			SwitchLevel = true;
		}
	}
}
