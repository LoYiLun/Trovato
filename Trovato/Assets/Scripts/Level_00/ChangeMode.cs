using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        EditOnly.GetComponent<TouchController>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void ModeCH()
    {
        MainCreateController.CreateMode = ModeCher.value;
    }
    public void ChangeToPlayMode()
    {
        PlayMode = 1;
        EditOnly.GetComponent<TouchController>().enabled = true;
        SaveBtn.GetComponent<Button>().enabled = false;
        LoadBtn.GetComponent<Button>().enabled = false;
        DropDowmBtn.GetComponent<Dropdown>().enabled = false;
        
    }
    public void ChangeToEditMode()
    {
        PlayMode = 0;
        EditOnly.GetComponent<TouchController>().enabled = false;
        SaveBtn.GetComponent<Button>().enabled = true;
        LoadBtn.GetComponent<Button>().enabled = true;
        DropDowmBtn.GetComponent<Dropdown>().enabled = true;
    }
}
