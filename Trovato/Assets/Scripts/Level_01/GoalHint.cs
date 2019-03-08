using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class GoalHint : MonoBehaviour {
    public Text GoalText;
    public Flowchart Main;
    
	// Use this for initialization
	void Start () {
        Main =
        Main = GameObject.Find("MainFlowChart").GetComponent<Flowchart>();
    }
    string BreadStr = "Bread";
    public bool BreadBool
    {
        get
        {
            return Main.GetBooleanVariable(BreadStr);
        }
        set
        {
            Main.SetBooleanVariable(BreadStr, value);
        }
    }
    string GetBreadStr = "GetBread";
    public bool GetBreadBool
    {
        get
        {
            return Main.GetBooleanVariable(GetBreadStr);
        }
        set
        {
            Main.SetBooleanVariable(GetBreadStr, value);
        }
    }
    string GiveBreadStr = "GiveBread";
    public bool GiveBreadBool
    {
        get
        {
            return Main.GetBooleanVariable(GiveBreadStr);
        }
        set
        {
            Main.SetBooleanVariable(GiveBreadStr, value);
        }
    }
    string FindGPStr = "FindGP";
    public bool FindGPBool
    {
        get
        {
            return Main.GetBooleanVariable(FindGPStr);
        }
        set
        {
            Main.SetBooleanVariable(FindGPStr, value);
        }
    }
    string SecGoHomeStr = "SecGoHome";
    public bool SecGoHomeBool
    {
        get
        {
            return Main.GetBooleanVariable(SecGoHomeStr);
        }
        set
        {
            Main.SetBooleanVariable(SecGoHomeStr, value);
        }
    }
    string ShipStr = "Ship";
    public bool ShipBool
    {
        get
        {
            return Main.GetBooleanVariable(ShipStr);
        }
        set
        {
            Main.SetBooleanVariable(ShipStr, value);
        }
    }
    // Update is called once per frame
    void Update () {
        if (BreadBool)
        {
            GoalText.text = "去麵包店買麵包";
        }
        else if (GetBreadBool)
        {
            GoalText.text = "把麵包拿給女孩";
        }
        else if (GiveBreadBool)
        {
            GoalText.text = "回到小王子的家";
        }
        else if (FindGPBool)
        {
            GoalText.text = "去找修伯里爺爺";
        }
        else if (SecGoHomeBool)
        {
            GoalText.text = "去跟女孩道別吧";
        }
        else if (ShipBool)
        {
            GoalText.text = "找到飛船並展開你的新旅程";
        }
    }

}
