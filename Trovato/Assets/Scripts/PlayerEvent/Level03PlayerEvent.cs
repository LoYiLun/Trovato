using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level03PlayerEvent : MonoBehaviour {
    public static Flowchart Talk;
	// Use this for initialization
	void Start () {
        Talk = GameObject.Find("對話").GetComponent<Flowchart>();
    }
	
	// Update is called once per frame
	void Update () {

    }
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.transform.name == "King")
        {
            Flowchart.BroadcastFungusMessage("FirstTouchKing");
        }
        if (other.transform.name == "Bookroom5")
        {
            Flowchart.BroadcastFungusMessage("Bookroom");
        }
        if (other.transform.name == "HouseKeeper")
        {
            Flowchart.BroadcastFungusMessage("HouseKeeper");
        }
        
        if (other.transform.name == "Warehouse2")
        {
            Flowchart.BroadcastFungusMessage("Warehouse2");
        }
        if (other.transform.name == "Maid")
        {
            Flowchart.BroadcastFungusMessage("SubMission01");
        }
    }
}
