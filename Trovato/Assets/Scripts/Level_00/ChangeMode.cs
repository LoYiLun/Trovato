using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeMode : MonoBehaviour {
    public Dropdown ModeCher;
    public GameObject EditOnly;
    public GameObject SaveBtn;
    public GameObject LoadBtn;
    public GameObject DropDowmBtn;
    public GameObject RPA;
    public GameObject RPB;
    public GameObject RPC;
    public GameObject RPD;
    public GameObject RPE;
    public GameObject RPF;
    public GameObject list;
    public GameObject save;
    public GameObject load;
    public GameObject play;
    public GameObject imageP;
    public  int PlayMode;
	public bool FinishPlayerSetting;
    // Use this for initialization
    void Start () {
        PlayMode = 0;
        //EditOnly.GetComponent<TouchController>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (FinishPlayerSetting == false && Global.Player != null)
			Global.Player.GetComponent<PlayerController> ().EditorSetting (gameObject, PlayMode);
    
		if (PlayMode == 0)
        {
            Global.IsCamCtrl = true;
            RPA.SetActive(false);
            RPB.SetActive(false);
            RPC.SetActive(false);
            RPD.SetActive(false);
            RPE.SetActive(false);
            RPF.SetActive(false);
        }
        else if(PlayMode == 1)
        {
            //Global.IsCamCtrl = false;
            RPA.SetActive(true);
            RPB.SetActive(true);
            RPC.SetActive(true);
            RPD.SetActive(true);
            RPE.SetActive(true);
            RPF.SetActive(true);
        }
    }
    public void ModeCH()
    {
        MainCreateController.CreateMode = ModeCher.value;
    }
    public void ChangeToPlayMode()
    {
        PlayMode = 1;
        //EditOnly.GetComponent<TouchController>().enabled = true;
        SaveBtn.GetComponent<Button>().enabled = false;
        LoadBtn.GetComponent<Button>().enabled = false;
        DropDowmBtn.GetComponent<Dropdown>().enabled = false;
        MainCreateController.CreateMode = 0;
        list.SetActive(false);
        save.SetActive(false);
        load.SetActive(false);
        play.SetActive(false);
        imageP.SetActive(false);
    }
    public void ChangeToEditMode()
    {
        PlayMode = 0;
        //EditOnly.GetComponent<TouchController>().enabled = false;
        SaveBtn.GetComponent<Button>().enabled = true;
        LoadBtn.GetComponent<Button>().enabled = true;
        DropDowmBtn.GetComponent<Dropdown>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        list.SetActive(true);
        save.SetActive(true);
        load.SetActive(true);
        play.SetActive(true);
        imageP.SetActive(true);
    }
		
}
