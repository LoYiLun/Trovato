using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour {
    public Material BlueMaterial;
    public Material BrownMaterial;
    private Vector3 TreePos;
    private Vector3 StonePos;
    private bool IsEmpty = true;
    private int Type;
    //1:樹木，2:石頭
    public static int CreateMode;
    // Use this for initialization
    void Start()
    {
		// TreePos = new Vector3(transform.position.x, 7.12f, transform.position.z);
        // StonePos = new Vector3(transform.position.x + 2.55f, -3.2f, transform.position.z - 1.92f);
		Type = 0;
    }

    // Update is called once per frame
	void Update(){
		TreePos = new Vector3(transform.position.x, transform.position.y + 2.4f, transform.position.z);
		StonePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        /*if (ChangeCreateMode.Clear&& !IsEmpty)
        {
                Destroy(transform.GetChild(0).gameObject);
                StartCoroutine(BackToClearYet());
        }*/
    }
    void OnMouseOver()
    {
        GetComponent<Renderer>().material = BlueMaterial;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material = BrownMaterial;
    }
    void OnMouseDown()
    {
        if (IsEmpty)
        {
            if (CreateMode == 1)
            {
                GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                TreeForCreate.transform.position = TreePos;
                TreeForCreate.transform.parent = transform;
                IsEmpty = false;
                Type = 1;
            }
            else if (CreateMode == 2)
            {
                GameObject StoneForCreate = Instantiate(Resources.Load("Prefabs/Stone")) as GameObject;
                StoneForCreate.transform.position = StonePos;
                StoneForCreate.transform.parent = transform;
                IsEmpty = false;
                Type = 2;
            }

        }
        if (Input.GetKey(KeyCode.LeftShift) && !IsEmpty)
        {
            Destroy(transform.GetChild(0).gameObject);
            IsEmpty = true;
            Type = 0;
        }
    }
}
