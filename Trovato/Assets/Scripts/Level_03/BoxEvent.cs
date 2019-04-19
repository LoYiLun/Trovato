using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class BoxEvent : MonoBehaviour {
    public Flowchart Main;
    // Use this for initialization
    void Start () {
        Main = GameObject.Find("對話").GetComponent<Flowchart>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Palace")
        {
            //Destroy(gameObject);
            //Main.SetBooleanVariable("BoxDestory1", true);
        }
    }
}
