using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level01PlayerEvent : MonoBehaviour {
    public static Flowchart main;
    public GameObject Shop;
    // Use this for initialization
    void Start () {
        main = GameObject.Find("MainFlowChart").GetComponent<Flowchart>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shop = GameObject.Find("Shop4");
            if ((Mathf.Abs(Shop.transform.position.x - transform.position.x) < 1.5f && Mathf.Abs(Shop.transform.position.z - transform.position.z) < 1.5f))
            {
                if (Bread)
                {
                    Flowchart.BroadcastFungusMessage("BuyBread");
                }
            }
        }
    }
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(GetBread && other.transform.name == "Rose")
        {
            Flowchart.BroadcastFungusMessage("GiveBread");
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
}
