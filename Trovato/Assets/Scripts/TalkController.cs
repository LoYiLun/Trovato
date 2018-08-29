using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkController : MonoBehaviour {
    public GameObject King;
    public static Flowchart Talk;
	// Use this for initialization
	void Start () {
        King = GameObject.Find("King");
        Talk = GameObject.Find("對話").GetComponent<Flowchart>();
    }
	
	// Update is called once per frame
	void Update () {

    }
    public static bool FirstTouchKing
    {
        get { return Talk.GetBooleanVariable("FirstTouchKing"); }
    }
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (!TalkController.FirstTouchKing && other.transform.name == "King")
        {
            Flowchart.BroadcastFungusMessage("FirstTouchKing");
        }
    }
}
