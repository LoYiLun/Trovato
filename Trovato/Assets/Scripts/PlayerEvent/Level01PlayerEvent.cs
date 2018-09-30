using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level01PlayerEvent : MonoBehaviour {
    public static Flowchart main;
    public GameObject Shop;
    public GameObject Rose;
    public GameObject MtShip2;
    public GameObject MtShip5;
    public GameObject MtShip6;
    // Use this for initialization
    void Start () {
        main = GameObject.Find("MainFlowChart").GetComponent<Flowchart>();
        Rose.GetComponent<MeshRenderer>().enabled = true;
        Rose.GetComponent<SphereCollider>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shop = GameObject.Find("Shop4");
            MtShip2 = GameObject.Find("Mt.SpaceShip2");
            MtShip5 = GameObject.Find("Mt.SpaceShip5");
            MtShip6 = GameObject.Find("Mt.SpaceShip6");
            if ((Mathf.Abs(Shop.transform.position.x - transform.position.x) < 1.5f && Mathf.Abs(Shop.transform.position.z - transform.position.z) < 1.5f))
            {
                if (Bread)
                {
                    Flowchart.BroadcastFungusMessage("BuyBread");
                }
            }
            if ((Mathf.Abs(MtShip2.transform.position.x - transform.position.x) < 1.5f && Mathf.Abs(MtShip2.transform.position.z - transform.position.z) < 1.5f))
            {
                if (Ship)
                {
                    Flowchart.BroadcastFungusMessage("GoShip");
                }
            }
            if ((Mathf.Abs(MtShip5.transform.position.x - transform.position.x) < 1.5f && Mathf.Abs(MtShip5.transform.position.z - transform.position.z) < 1.5f))
            {
                if (Ship)
                {
                    Flowchart.BroadcastFungusMessage("GoShip");
                }
            }
            if ((Mathf.Abs(MtShip6.transform.position.x - transform.position.x) < 1.5f && Mathf.Abs(MtShip6.transform.position.z - transform.position.z) < 1.5f))
            {
                if (Ship)
                {
                    Flowchart.BroadcastFungusMessage("GoShip");
                }
            }

        }
        if (GiveBread)
        {
            Rose.GetComponent<MeshRenderer>().enabled = false;
            Rose.GetComponent<SphereCollider>().enabled = false;
        }
    }
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(GetBread && other.transform.name == "Rose")
        {
            Rose = GameObject.Find("Rose");
            Flowchart.BroadcastFungusMessage("GiveBread");
        }
        if(other.transform.name == "PrinceHome6")
        {
            Flowchart.BroadcastFungusMessage("RoseGoHome");
            Flowchart.BroadcastFungusMessage("SecGoHome");
        }
        if(other.transform.name == "GlassRepair")
        {
            Flowchart.BroadcastFungusMessage("FindGP");
        }
        if(!Ship && (other.transform.name == "Mt.SpaceShip2" || other.transform.name == "Mt.SpaceShip5" || other.transform.name == "Mt.SpaceShip6"))
        {
            Flowchart.BroadcastFungusMessage("GoShip");
        }
        if(other.transform.name == "Marley")
        {
            Flowchart.BroadcastFungusMessage("MarletTalk");
        }
        if (other.transform.name == "AnotherHouse4")
        {
            Flowchart.BroadcastFungusMessage("HouseTalk");
        }
        if (other.transform.name == "WareHouse")
        {
            Flowchart.BroadcastFungusMessage("WareHouseTalk");
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
