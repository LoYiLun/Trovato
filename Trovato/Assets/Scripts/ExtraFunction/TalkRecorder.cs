using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class TalkRecorder : MonoBehaviour {

	public Flowchart flowchart;
	public GameObject Panel_TalkRecorder;
	public Text lastText;
	public List<Text> allTexts = new List<Text>();
	public GameObject contentObj;

	private List<Block> allBlocks = new List<Block> ();
	private Command lastCommand;
	private string lastTalk;
	private string[] lastTalk2;
	private int commandID;
	private int textWidth = 40;
	private int contentTop = 940;
	private int contentBottom = 1700;

	void Awake () {
		contentObj.transform.position = new Vector3(contentObj.transform.position.x, contentTop-400, contentObj.transform.position.z);
		foreach (Text s in allTexts) {
			s.text = null;
		}
	}

	void Update () {
		contentObj.transform.position = new Vector3(contentObj.transform.position.x, Mathf.Clamp (contentObj.transform.position.y, contentTop, contentBottom), contentObj.transform.position.z);

		if (flowchart != null && flowchart.HasExecutingBlocks ()) {
			allBlocks = flowchart.GetExecutingBlocks ();
			lastCommand = allBlocks [allBlocks.Count - 1].ActiveCommand;
			setLastText ();

		}

		if (Input.GetKeyDown (KeyCode.D)) {
			showDialog ();
		}
	}

	public void setLastText(){
		if (lastCommand.ItemId != commandID && lastCommand.GetType() == typeof(Fungus.Say) ) {

			lastTalk = lastCommand.GetSummary ();
			lastTalk = lastTalk.Replace ("\"", " "); // 取消fungus say 自帶的""
			lastTalk2 = lastTalk.Split (':');

			// 當有角色說話時，若一句話太長則分行
			if (lastTalk2.Length > 1) {
				lastTalk = (lastTalk.Length >= textWidth) ? lastTalk2 [0] + lastTalk2 [1] : lastTalk2 [0] + "\n" + lastTalk2 [1];
			}

			// 判斷有無使用fungus的Extend對話
			if (lastTalk.Contains ("EXTEND") == false) {
				for (int i = allTexts.Count - 1; i > 0; i--) {
					allTexts [i].text = allTexts [i - 1].text;
				}
				allTexts [0].text = lastTalk;
			} else {
				lastTalk = lastTalk.Replace ("EXTEND  ", "");
				allTexts [0].text += lastTalk;
			}

			//print (lastTalk + " / Length: " + lastTalk.Length);
			commandID = lastCommand.ItemId;
		}
	}

	public void showDialog(){
		if (Panel_TalkRecorder.GetComponent<CanvasGroup> ().alpha == 1) {
			Panel_TalkRecorder.GetComponent<CanvasGroup> ().interactable = false;
			Panel_TalkRecorder.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			Panel_TalkRecorder.GetComponent<CanvasGroup> ().alpha = 0;
		} else {
			Panel_TalkRecorder.GetComponent<CanvasGroup> ().interactable = true;
			Panel_TalkRecorder.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			Panel_TalkRecorder.GetComponent<CanvasGroup> ().alpha = 1;
		}
	}


}
