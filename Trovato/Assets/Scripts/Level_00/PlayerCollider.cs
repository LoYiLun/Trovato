using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {
    // Use this for initialization
    public static bool Judge;
    public GameObject GbjForJudge;
    void Start () {
        Judge = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Judge")
        {
            collision.transform.GetComponent<MainCreateController>().IsEmpty = false;
            GbjForJudge = collision.gameObject;
            Judge = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        GbjForJudge.transform.GetComponent<MainCreateController>().IsEmpty = true;
    }
}
