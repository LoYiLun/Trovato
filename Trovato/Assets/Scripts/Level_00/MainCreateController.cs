using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;

public class MainCreateController : MonoBehaviour {
    private Vector3 TreePos;
    private Vector3 KyderPos;
    private Vector3 BushRowPos;
    private Vector3 BushColPos;
    private Vector3 RailingColPos;
    private Vector3 RailingRowPos;
    private Vector3 WareHousePos;
    private Vector3 PlayerPos;
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
                    TreePos = new Vector3(5.37f, transform.position.y, transform.position.z);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(4.9f, transform.position.y, transform.position.z);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
                if (CreateMode == 3)
                {
                    BushColPos = new Vector3(4.5f, transform.position.y, transform.position.z);
                    GameObject BushColCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushC")) as GameObject;
                    BushColCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    BushColCreate.transform.position = BushColPos;
                    BushColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 3;
                }
                if (CreateMode == 4)
                {
                    BushRowPos = new Vector3(4.5f, transform.position.y, transform.position.z);
                    GameObject BushRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushR")) as GameObject;
                    BushRowCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    BushRowCreate.transform.eulerAngles = new Vector3(0, 90, 90);
                    BushRowCreate.transform.position = BushRowPos;
                    BushRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 4;
                }
                if (CreateMode == 5)
                {
                    RailingColPos = new Vector3(4.5f, transform.position.y, transform.position.z);
                    GameObject RailingColCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingColCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    RailingColCreate.transform.position = RailingColPos;
                    RailingColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type =5;
                }
                if (CreateMode == 6)
                {
                    RailingRowPos = new Vector3(4.5f, transform.position.y, transform.position.z);
                    GameObject RailingRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingRowCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    RailingRowCreate.transform.eulerAngles = new Vector3(0, 90, 90);
                    RailingRowCreate.transform.position = RailingRowPos;
                    RailingRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 6;
                }
                if (CreateMode == 7)
                {
                    WareHousePos = new Vector3(4.5f, transform.position.y, transform.position.z);
                    GameObject WareHouseCreate = Instantiate(Resources.Load("Prefabs/Level_00/WareHouse")) as GameObject;
                    WareHouseCreate.transform.rotation = Quaternion.Euler(0, 0, -90);
                    WareHouseCreate.transform.position = WareHousePos;
                    WareHouseCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 7;
                }
            }
            else if ((transform.parent.position.x - transform.position.x) > 1.4 && (transform.parent.position.x - transform.position.x) < 1.6)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(-5.37f, transform.position.y, transform.position.z);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(-4.9f, transform.position.y, transform.position.z);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
                if (CreateMode == 3)
                {
                    BushColPos = new Vector3(-4.5f, transform.position.y, transform.position.z);
                    GameObject BushColCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushC")) as GameObject;
                    BushColCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    BushColCreate.transform.position = BushColPos;
                    BushColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 3;
                }
                if (CreateMode == 4)
                {
                    BushRowPos = new Vector3(-4.5f, transform.position.y, transform.position.z);
                    GameObject BushRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushR")) as GameObject;
                    BushRowCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    BushRowCreate.transform.eulerAngles = new Vector3(0, -90, 90);
                    BushRowCreate.transform.position = BushRowPos;
                    BushRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 4;
                }
                if (CreateMode == 5)
                {
                    RailingColPos = new Vector3(-4.5f, transform.position.y, transform.position.z);
                    GameObject RailingColCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingColCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    RailingColCreate.transform.position = RailingColPos;
                    RailingColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 5;
                }
                if (CreateMode == 6)
                {
                    RailingRowPos = new Vector3(-4.5f, transform.position.y, transform.position.z);
                    GameObject RailingRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingRowCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    RailingRowCreate.transform.eulerAngles = new Vector3(0, -90, 90);
                    RailingRowCreate.transform.position = RailingRowPos;
                    RailingRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 6;
                }
                if (CreateMode == 7)
                {
                    WareHousePos = new Vector3(-4.5f, transform.position.y, transform.position.z);
                    GameObject WareHouseCreate = Instantiate(Resources.Load("Prefabs/Level_00/WareHouse")) as GameObject;
                    WareHouseCreate.transform.rotation = Quaternion.Euler(0, 0, 90);
                    WareHouseCreate.transform.position = WareHousePos;
                    WareHouseCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 7;
                }
            }
            else if ((transform.parent.position.y - transform.position.y) > -1.6 && (transform.parent.position.y - transform.position.y) < -1.4)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(transform.position.x, 5.37f, transform.position.z);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(transform.position.x, 4.9f, transform.position.z);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
                if (CreateMode == 3)
                {
                    BushColPos = new Vector3(transform.position.x, 4.5f, transform.position.z);
                    GameObject BushColCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushC")) as GameObject;
                    BushColCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    BushColCreate.transform.position = BushColPos;
                    BushColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 3;
                }
                if (CreateMode == 4)
                {
                    BushRowPos = new Vector3(transform.position.x, 4.5f, transform.position.z);
                    GameObject BushRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushR")) as GameObject;
                    BushRowCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    BushRowCreate.transform.eulerAngles = new Vector3(-90, 90, 0);
                    BushRowCreate.transform.position = BushRowPos;
                    BushRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 4;
                }
                if (CreateMode == 5)
                {
                    RailingColPos = new Vector3(transform.position.x, 4.5f, transform.position.z);
                    GameObject RailingColCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingColCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    RailingColCreate.transform.position = RailingColPos;
                    RailingColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 5;
                }
                if (CreateMode == 6)
                {
                    RailingRowPos = new Vector3(transform.position.x, 4.5f, transform.position.z);
                    GameObject RailingRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingRowCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    RailingRowCreate.transform.eulerAngles = new Vector3(-90, 90, 0);
                    RailingRowCreate.transform.position = RailingRowPos;
                    RailingRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 6;
                }
                if (CreateMode == 7)
                {
                    WareHousePos = new Vector3(transform.position.x, 4.5f, transform.position.z);
                    GameObject WareHouseCreate = Instantiate(Resources.Load("Prefabs/Level_00/WareHouse")) as GameObject;
                    WareHouseCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    WareHouseCreate.transform.position = WareHousePos;
                    WareHouseCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 7;
                }
            }
            else if ((transform.parent.position.y - transform.position.y) > 1.4 && (transform.parent.position.y - transform.position.y) < 1.6)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(transform.position.x, -5.37f, transform.position.z);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(transform.position.x, -4.9f, transform.position.z);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
                if (CreateMode == 3)
                {
                    BushColPos = new Vector3(transform.position.x, -4.5f, transform.position.z);
                    GameObject BushColCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushC")) as GameObject;
                    BushColCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    BushColCreate.transform.position = BushColPos;
                    BushColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 3;
                }
                if (CreateMode == 4)
                {
                    BushRowPos = new Vector3(transform.position.x, -4.5f, transform.position.z);
                    GameObject BushRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushR")) as GameObject;
                    BushRowCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    BushRowCreate.transform.eulerAngles = new Vector3(90, 90, 0);
                    BushRowCreate.transform.position = BushRowPos;
                    BushRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 4;
                }
                if (CreateMode == 5)
                {
                    RailingColPos = new Vector3(transform.position.x, -4.5f, transform.position.z);
                    GameObject RailingColCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingColCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    RailingColCreate.transform.position = RailingColPos;
                    RailingColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 5;
                }
                if (CreateMode == 6)
                {
                    RailingRowPos = new Vector3(transform.position.x, -4.5f, transform.position.z);
                    GameObject RailingRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingRowCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    RailingRowCreate.transform.eulerAngles = new Vector3(90, 90, 0);
                    RailingRowCreate.transform.position = RailingRowPos;
                    RailingRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 6;
                }
                if (CreateMode == 7)
                {
                    WareHousePos = new Vector3(transform.position.x, -4.5f, transform.position.z);
                    GameObject WareHouseCreate = Instantiate(Resources.Load("Prefabs/Level_00/WareHouse")) as GameObject;
                    WareHouseCreate.transform.rotation = Quaternion.Euler(180, 90, 0);
                    WareHouseCreate.transform.position = WareHousePos;
                    WareHouseCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 7;
                }
            }
            else if ((transform.parent.position.z - transform.position.z) > -1.6 && (transform.parent.position.z - transform.position.z) < -1.4)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(transform.position.x, transform.position.y, 5.37f);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(transform.position.x, transform.position.y, 4.9f);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
                if (CreateMode == 3)
                {
                    BushColPos = new Vector3(transform.position.x, transform.position.y, 4.5f);
                    GameObject BushColCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushC")) as GameObject;
                    BushColCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    BushColCreate.transform.position = BushColPos;
                    BushColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 3;
                }
                if (CreateMode == 4)
                {
                    BushRowPos = new Vector3(transform.position.x,transform.position.y, 4.5f);
                    GameObject BushRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushR")) as GameObject;
                    BushRowCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    BushRowCreate.transform.eulerAngles = new Vector3(0, 0, 90);
                    BushRowCreate.transform.position = BushRowPos;
                    BushRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 4;
                }
                if (CreateMode == 5)
                {
                    RailingColPos = new Vector3(transform.position.x, transform.position.y, 4.5f);
                    GameObject RailingColCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingColCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    RailingColCreate.transform.position = RailingColPos;
                    RailingColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 5;
                }
                if (CreateMode == 6)
                {
                    RailingRowPos = new Vector3(transform.position.x, transform.position.y, 4.5f);
                    GameObject RailingRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingRowCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    RailingRowCreate.transform.eulerAngles = new Vector3(0, 0, 90);
                    RailingRowCreate.transform.position = RailingRowPos;
                    RailingRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 6;
                }
                if (CreateMode == 7)
                {
                    WareHousePos = new Vector3(transform.position.x, transform.position.y, 4.5f);
                    GameObject WareHouseCreate = Instantiate(Resources.Load("Prefabs/Level_00/WareHouse")) as GameObject;
                    WareHouseCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    WareHouseCreate.transform.position = WareHousePos;
                    WareHouseCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 7;
                }
            }
            else if ((transform.parent.position.z - transform.position.z) > 1.4 && (transform.parent.position.z - transform.position.z) < 1.6)
            {
                if (CreateMode == 1)
                {
                    TreePos = new Vector3(transform.position.x, transform.position.y, -5.37f);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    TreeForCreate.transform.position = TreePos;
                    TreeForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 1;
                }
                if (CreateMode == 2)
                {
                    KyderPos = new Vector3(transform.position.x, transform.position.y, -4.9f);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    KyderForCreate.transform.position = KyderPos;
                    KyderForCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 2;
                }
                if (CreateMode == 3)
                {
                    BushColPos = new Vector3(transform.position.x, transform.position.y, -4.5f);
                    GameObject BushColCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushC")) as GameObject;
                    BushColCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    BushColCreate.transform.position = BushColPos;
                    BushColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 3;
                }
                if (CreateMode == 4)
                {
                    BushRowPos = new Vector3(transform.position.x, transform.position.y, -4.5f);
                    GameObject BushRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushR")) as GameObject;
                    BushRowCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    BushRowCreate.transform.eulerAngles = new Vector3(0, 180, 90);
                    BushRowCreate.transform.position = BushRowPos;
                    BushRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 4;
                }
                if (CreateMode == 5)
                {
                    RailingColPos = new Vector3(transform.position.x, transform.position.y, -4.5f);
                    GameObject RailingColCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingColCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    RailingColCreate.transform.position = RailingColPos;
                    RailingColCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 5;
                }
                if (CreateMode == 6)
                {
                    RailingRowPos = new Vector3(transform.position.x, transform.position.y, -4.5f);
                    GameObject RailingRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingRowCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    RailingRowCreate.transform.eulerAngles = new Vector3(0, 180, 90);
                    RailingRowCreate.transform.position = RailingRowPos;
                    RailingRowCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 6;
                }
                if (CreateMode == 7)
                {
                    WareHousePos = new Vector3(transform.position.x, transform.position.y, -4.5f);
                    GameObject WareHouseCreate = Instantiate(Resources.Load("Prefabs/Level_00/WareHouse")) as GameObject;
                    WareHouseCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    WareHouseCreate.transform.position = WareHousePos;
                    WareHouseCreate.transform.parent = transform;
                    IsEmpty = false;
                    Type = 7;
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
