using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCreateMode : MonoBehaviour {
    public static bool Clear = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Mode1()
    {
        PlaneManager.CreateMode = 1;
    }
    public void Mode2()
    {
        PlaneManager.CreateMode = 2;
    }
    /*public void Clean()
    {
            Clear = true;
    }*/
}
