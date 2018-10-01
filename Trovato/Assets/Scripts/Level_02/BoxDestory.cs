using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestory : MonoBehaviour {
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
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
    }
}
