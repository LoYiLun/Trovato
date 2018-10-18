using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level02PlayerEvent : MonoBehaviour {
    public Flowchart Level02main;
    public static int box;
    public int RedLeaf;

    // Use this for initialization
    void Start () {
        box = 0;
        RedLeaf = 0;
        Level02main = GameObject.Find("Level02Main").GetComponent<Flowchart>();

    }
	
	// Update is called once per frame
	void Update () {
		if(box == 3)
        {
            Flowchart.BroadcastFungusMessage("BoxDestory");
            box = 0;
        }
        if(RedLeaf == 3)
        {
            Flowchart.BroadcastFungusMessage("RedLeafx3");
            RedLeaf = 0;
        }
	}
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(other.transform.name == "Lucas")
        {
            Flowchart.BroadcastFungusMessage("LucasTalk01");
        }
        if (other.transform.name == "Soyna")
        {
            Flowchart.BroadcastFungusMessage("SoynaTalk01");
        }
        if (other.transform.name == "Riven")
        {
            Flowchart.BroadcastFungusMessage("RivenTalk01");
        }
        if (other.transform.name == "Engine")
        {
            Flowchart.BroadcastFungusMessage("GetEngine");
            Destroy(other.gameObject);
        }
        if (other.transform.name == "Redleaf_A"|| other.transform.name == "Redleaf_B"|| other.transform.name == "Redleaf_C")
        {
            Destroy(other.gameObject);
            //print(RedLeaf);
            RedLeaf++;
        }
        if (other.transform.name == "Sisco")
        {
            Flowchart.BroadcastFungusMessage("SiscoTalk01");
        }
		if ((other.transform.name == "Mt.SpaceShip_Door1" || other.transform.name == "Mt.SpaceShip_Door2" || other.transform.name == "Mt.SpaceShip_Door3"))
        {
            Flowchart.BroadcastFungusMessage("GO");
        }
        if (other.transform.name == "Mike")
        {
            Flowchart.BroadcastFungusMessage("MikeTalk01");
        }
        if (other.transform.name == "Bill")
        {
            Flowchart.BroadcastFungusMessage("BillTalk01");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Kyder")
        {
            Flowchart.BroadcastFungusMessage("GetKyder");
        }
    }
}
