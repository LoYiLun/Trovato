using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using UnityEngine.UI;


public class ButtonEvent : MonoBehaviour {
    public Text StartBtn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        if(StartBtn.text == "開始遊戲")
        {
            Flowchart.BroadcastFungusMessage("StartGame");
        }
        else if(StartBtn.text == "上一頁")
        {
            Flowchart.BroadcastFungusMessage("Back");
        }
    }
    public void GotoLevel_00()
    {
        SceneManager.LoadScene("Level_00");
    }
    public void GotoLevel_01()
    {
        SceneManager.LoadScene("Level_01");
    }
    public void GotoLevel_02()
    {
        SceneManager.LoadScene("Level_02");
    }
    public void GotoLevel_03()
    {
        SceneManager.LoadScene("Level_03");
    }
}
