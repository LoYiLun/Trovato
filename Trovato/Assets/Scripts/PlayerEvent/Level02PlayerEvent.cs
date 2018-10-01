using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level02PlayerEvent : MonoBehaviour {
    public Flowchart Level02main;
    public GameObject Box_1;
    public GameObject Box_2;
    public GameObject Box_3;
    public int box;

    // Use this for initialization
    void Start () {
        box = 1;
        Level02main = GameObject.Find("Level02Main").GetComponent<Flowchart>();
        Box_1 = GameObject.Find("Box_1");
        Box_2 = GameObject.Find("Box_2");
        Box_3 = GameObject.Find("Box_3");
    }
	
	// Update is called once per frame
	void Update () {
		if(!Box_1 && Box_2 && Box_3 && box ==1)
        {
            Flowchart.BroadcastFungusMessage("BoxDestory");
            box = 0;
        }
	}
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(other.transform.name == "Lucas")
        {
            Flowchart.BroadcastFungusMessage("LucasTalk01");
        }
    }
}
