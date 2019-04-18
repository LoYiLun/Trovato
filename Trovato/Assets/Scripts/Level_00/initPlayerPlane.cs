using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initPlayerPlane : MonoBehaviour {
    public GameObject Plane;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (Plane.transform.childCount == 1)
        {
            Plane.transform.GetChild(0).gameObject.SetActive(false);
        }
	}
}
