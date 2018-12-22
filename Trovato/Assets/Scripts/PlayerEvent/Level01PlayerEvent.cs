using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level01PlayerEvent : MonoBehaviour {
    public static Flowchart main;
	public GameObject Shop{get{return GameObject.Find("Shop_Door1"); }}
    public GameObject Rose;
	public GameObject MtShip1{get{return GameObject.Find("Mt.SpaceShip_Door1"); }}
    // Use this for initialization

    void Start () {
        main = GameObject.Find("MainFlowChart").GetComponent<Flowchart>();
        Rose.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		if (!Global.StopTouch && Shop != null && MtShip1 != null)
        {
			if ( Bread && Vector3.Distance (Global.Player.transform.position, Shop.transform.position) <= 1.5f) 
			{
				PlayerStatusImage.GetStatus ("Interact?");
				if (Input.GetKeyDown (KeyCode.E)) {
					Flowchart.BroadcastFungusMessage ("BuyBread");
				}
			}

			else if ( Ship &&Vector3.Distance (Global.Player.transform.position, MtShip1.transform.position) <= 1.5f)
            {
				PlayerStatusImage.GetStatus ("Interact?");
				if (Input.GetKeyDown (KeyCode.E)) {
					Flowchart.BroadcastFungusMessage ("GoShip");
				}
			}

        }
        if (GiveBread)
        {
            //Rose.SetActive(false);
        }
    }
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(GetBread && other.transform.name == "Rose")
        {
            Rose = GameObject.Find("Rose");
			Flowchart.BroadcastFungusMessage("GiveBread");
			PlayerStatusImage.GetStatus("None");
        }
        if(other.transform.name == "PrinceHome_Door")
        {
            Flowchart.BroadcastFungusMessage("RoseGoHome");
			Flowchart.BroadcastFungusMessage("SecGoHome");
			PlayerStatusImage.GetStatus("None");
        }
        if(other.transform.name == "GlassRepair")
        {
			Flowchart.BroadcastFungusMessage("FindGP");
			PlayerStatusImage.GetStatus("None");
        }
        if(!Ship && (other.transform.name == "Mt.SpaceShip_Door1" || other.transform.name == "Mt.SpaceShip_Door2" || other.transform.name == "Mt.SpaceShip_Door3"))
        {
			Flowchart.BroadcastFungusMessage("GoShip");
			PlayerStatusImage.GetStatus("None");
        }
        if(other.transform.name == "Marley")
        {
			Flowchart.BroadcastFungusMessage("MarletTalk");
			PlayerStatusImage.GetStatus("None");
        }
		if (other.transform.name == "AnotherHouse_Door1" || other.transform.name == "AnotherHouse_Door2" || other.transform.name == "AnotherHouse_Door3")
        {
			Flowchart.BroadcastFungusMessage("HouseTalk");
			PlayerStatusImage.GetStatus("None");
        }
        if (other.transform.name == "WareHouse_Door")
        {
			Flowchart.BroadcastFungusMessage("WareHouseTalk");
			PlayerStatusImage.GetStatus("None");
        }
    }
    public static bool Bread
    {
        get { return main.GetBooleanVariable("Bread"); }
    }
    public static bool GetBread
    {
        get { return main.GetBooleanVariable("GetBread"); }
    }
    public static bool GiveBread
    {
        get { return main.GetBooleanVariable("GiveBread"); }
    }
    public static bool Ship
    {
        get { return main.GetBooleanVariable("Ship"); }
    }
}
