using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkController : MonoBehaviour {
    public GameObject King;
    public static Flowchart Talk;
	// Use this for initialization
	void Start () {
        King = GameObject.Find("Cube_King");
        Talk = GameObject.Find("對話").GetComponent<Flowchart>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public static bool FisrtTouchKing
    {
        get { return Talk.GetBooleanVariable("FisrtTouchKing"); }
    }
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (!TalkController.FisrtTouchKing && other.transform.name == "Cube_King")
        {
            Flowchart.BroadcastFungusMessage("FisrtTouchKing");
        }
    }
}
