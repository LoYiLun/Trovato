using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class GoalHint3 : MonoBehaviour {
    public Text GoalText;
    public Flowchart Main;
    // Use this for initialization
    void Start () {
        Main = GameObject.Find("對話").GetComponent<Flowchart>();
    }
    string FirstStr = "FirstTouchKing";
    string King2Str = "King2";
    string FindcalendarStr = "Findcalendar";
    string ReturnKeyStr = "ReturnKey";
    string ServantDoneStr = "ServantDone";
    public bool ServantDoneBool
    {
        get
        {
            return Main.GetBooleanVariable(ServantDoneStr);
        }
        set
        {
            Main.SetBooleanVariable(ServantDoneStr, value);
        }
    }
    public bool ReturnKeyBool
    {
        get
        {
            return Main.GetBooleanVariable(ReturnKeyStr);
        }
        set
        {
            Main.SetBooleanVariable(ReturnKeyStr, value);
        }
    }
    public bool FirstBool
    {
        get
        {
            return Main.GetBooleanVariable(FirstStr);
        }
        set
        {
            Main.SetBooleanVariable(FirstStr, value);
        }
    }
    public bool King2Bool
    {
        get
        {
            return Main.GetBooleanVariable(King2Str);
        }
        set
        {
            Main.SetBooleanVariable(King2Str, value);
        }
    }
    public bool FindcalendarBool
    {
        get
        {
            return Main.GetBooleanVariable(FindcalendarStr);
        }
        set
        {
            Main.SetBooleanVariable(FindcalendarStr, value);
        }
    }
    // Update is called once per frame
    void Update () {
        if (FirstBool)
        {
            GoalText.text = "跟國王打聲招呼吧";
        }
        else if (King2Bool)
        {
            GoalText.text = "幫助國王解決困難";
        }
        else if (FindcalendarBool)
        {
            if(!ServantDoneBool && !ReturnKeyBool)
            GoalText.text = "解決其他居民的困難吧";
            else  if(ServantDoneBool && ReturnKeyBool)
            {
                GoalText.text = "離開這裡吧";
            }
        }
    }
}
