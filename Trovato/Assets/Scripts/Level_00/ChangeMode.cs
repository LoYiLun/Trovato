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
    public  int PlayMode;
    // Use this for initialization
    void Start () {
        PlayMode = 0;
        //EditOnly.GetComponent<TouchController>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayMode == 0)
        {
            Global.IsCamCtrl = true;
        }
        else if(PlayMode == 1)
        {
            Global.IsCamCtrl = false;
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
    }
    public void ChangeToEditMode()
    {
        PlayMode = 0;
        //EditOnly.GetComponent<TouchController>().enabled = false;
        SaveBtn.GetComponent<Button>().enabled = true;
        LoadBtn.GetComponent<Button>().enabled = true;
        DropDowmBtn.GetComponent<Dropdown>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
