using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class BoxDestory : MonoBehaviour {
    // Use this for initialization
    public Flowchart Main;
    void Start () {
        if(Global.Level == "3")
        {
            Main = GameObject.Find("對話").GetComponent<Flowchart>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.transform.name == "IncinerationPlant4")
        {
            Destroy(gameObject);
        }
        if (collision.transform.name == "IncinerationPlant5")
        {
            Destroy(gameObject);
        }
        if (collision.transform.name == "IncinerationPlant6")
        {
            Destroy(gameObject);
        }
        if (collision.transform.name == "DestroyBox(stop)")
        {
            Destroy(gameObject);
            if(Main.GetIntegerVariable("BoxDestory") == 0)
            {
                Main.SetIntegerVariable("BoxDestory", 1);
            }
            else if(Main.GetIntegerVariable("BoxDestory") == 1)
            {
                Main.SetIntegerVariable("BoxDestory", 2);
            }
        }
    }
}
