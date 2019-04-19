using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class GoalHint2 : MonoBehaviour {
    public Text GoalText;
    public Flowchart Main;
    // Use this for initialization
    void Start () {
        Main = GameObject.Find("Level02Main").GetComponent<Flowchart>();
    }
    string StartStr = "Start";
    string EndStr = "End";
    public bool StartBool
    {
        get
        {
            return Main.GetBooleanVariable(StartStr);
        }
        set
        {
            Main.SetBooleanVariable(StartStr, value);
        }
    }
    public bool EndBool
    {
        get
        {
            return Main.GetBooleanVariable(EndStr);
        }
        set
        {
            Main.SetBooleanVariable(EndStr, value);
        }
    }
    // Update is called once per frame
    void Update () {
        if (StartBool)
        {
            GoalText.text = "幫助這裡的居民解決困難吧";
        }
        else if (EndBool)
        {
            GoalText.text = "搭上飛船離開這裡吧";
        }
	}
}
