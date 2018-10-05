﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;

public class MainCreateController : MonoBehaviour {
    private Vector3 TreePos;
    private Vector3 KyderPos;
    public bool IsEmpty = true;
    public int Type;
    public static int CreateMode;

    // Use this for initialization
    void Start () {
        CreateMode = 0;
    }
	
	// Update is called once per frame
	void Update () {

	}
    void OnMouseDown()
    {
        
        if (IsEmpty)
        {
            /*print(transform.name + " " + transform.position);
            print(transform.parent.name + " " + transform.parent.position);
            print(transform.parent.position.x - transform.position.x);
            print(transform.GetChild(0).name + " " + transform.GetChild(0).position);*/
            if ((transform.parent.position.x - transform.position.x) > -1.6 && (transform.parent.position.x - transform.position.x) < -1.4)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(7.1f, transform.position.y, transform.position.z);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(5.5f, transform.position.y, transform.position.z);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
            }
            else if ((transform.parent.position.x - transform.position.x) > 1.4 && (transform.parent.position.x - transform.position.x) < 1.6)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(-7.1f, transform.position.y, transform.position.z);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(-5.5f, transform.position.y, transform.position.z);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
            }
            else if ((transform.parent.position.y - transform.position.y) > -1.6 && (transform.parent.position.y - transform.position.y) < -1.4)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(transform.position.x, 7.1f, transform.position.z);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(transform.position.x, 5.5f, transform.position.z);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
            }
            else if ((transform.parent.position.y - transform.position.y) > 1.4 && (transform.parent.position.y - transform.position.y) < 1.6)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(transform.position.x, -7.1f, transform.position.z);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(transform.position.x, -5.5f, transform.position.z);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
            }
            else if ((transform.parent.position.z - transform.position.z) > -1.6 && (transform.parent.position.z - transform.position.z) < -1.4)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(transform.position.x, transform.position.y, 7.1f);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(transform.position.x, transform.position.y, 5.5f);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
            }
            else if ((transform.parent.position.z - transform.position.z) > 1.4 && (transform.parent.position.z - transform.position.z) < 1.6)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(transform.position.x, transform.position.y, -7.1f);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(transform.position.x, transform.position.y, -5.5f);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
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
