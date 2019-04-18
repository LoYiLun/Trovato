using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class SaveGame : MonoBehaviour {
    public int[] NowType;
    public GameObject[] Plane;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Save()
    {
        JSONObject ObjectJson = new JSONObject();
        JSONArray TypeJson = new JSONArray();
        JSONArray positionX = new JSONArray();
        JSONArray positionY = new JSONArray();
        JSONArray positionZ = new JSONArray();
        /*JSONArray rotationX = new JSONArray();
        JSONArray rotationY = new JSONArray();
        JSONArray rotationZ = new JSONArray();*/
        for (int i = 0; i < 486; i++)
        {
            NowType[i] = Plane[i].GetComponent<MainCreateController>().Type;
            TypeJson.Add(NowType[i]);
            ObjectJson.Add("NowType", TypeJson);
            if (ObjectJson["NowType"][i] == 0)
            {
                positionX.Add(0);
                positionY.Add(0);
                positionZ.Add(0);
                /*rotationX.Add(0);
                rotationY.Add(0);
                rotationZ.Add(0);*/
                ObjectJson.Add("PositionX", positionX);
                ObjectJson.Add("PositionY", positionY);
                ObjectJson.Add("PositionZ", positionZ);
                /*ObjectJson.Add("RotationX", rotationX);
                ObjectJson.Add("RotationY", rotationY);
                ObjectJson.Add("RotationZ", rotationZ);*/
            }
            if (!Plane[i].GetComponent<MainCreateController>().IsEmpty)
            {
                /*if(i == 61)
                {
                    positionX.Add(0);
                    positionY.Add(0);
                    positionZ.Add(0);
                    ObjectJson.Add("PositionX", positionX);
                    ObjectJson.Add("PositionY", positionY);
                    ObjectJson.Add("PositionZ", positionZ);
                }*/
                //else
                //{
                    positionX.Add(Plane[i].transform.GetChild(0).position.x);
                    positionY.Add(Plane[i].transform.GetChild(0).position.y);
                    positionZ.Add(Plane[i].transform.GetChild(0).position.z);
                    /*rotationX.Add(Plane[i].transform.GetChild(0).rotation.x);
                    rotationY.Add(Plane[i].transform.GetChild(0).rotation.y);
                    rotationZ.Add(Plane[i].transform.GetChild(0).rotation.z);*/
                    ObjectJson.Add("PositionX", positionX);
                    ObjectJson.Add("PositionY", positionY);
                    ObjectJson.Add("PositionZ", positionZ);
                    /*ObjectJson.Add("RotationX", rotationX);
                    ObjectJson.Add("RotationY", rotationY);
                    ObjectJson.Add("RotationZ", rotationZ);*/
                //}
            }
        }
        string path = Application.dataPath + "/PlayerSave.json";
        File.WriteAllText(path, ObjectJson.ToString());
    }
    public void Load()
    {
        string path = Application.dataPath + "/PlayerSave.json";
        string jsonString = File.ReadAllText(path);
        JSONObject ObjectJson = (JSONObject)JSON.Parse(jsonString);
        //設定值
        for (int i = 0; i < 486; i++)
        {
            if (ObjectJson["NowType"][i] == 1)
            {
                if (Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {

                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //TreeForCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    TreeForCreate.transform.parent = Plane[i].transform;
                    TreeForCreate.transform.localScale = new Vector3(100,100,33);
                    if(Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(0,90,0);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(90,0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 1;
                }
                else if (!Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    Destroy(Plane[i].transform.GetChild(0).gameObject);
                    GameObject TreeForCreate = Instantiate(Resources.Load("Prefabs/Tree")) as GameObject;
                    TreeForCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //TreeForCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    TreeForCreate.transform.parent = Plane[i].transform;
                    TreeForCreate.transform.localScale = new Vector3(100, 100, 33);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        TreeForCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 1;
                }
            }
            if (ObjectJson["NowType"][i] == 2)
            {
                if (Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //KyderForCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    KyderForCreate.transform.parent = Plane[i].transform;
                    KyderForCreate.transform.localScale = new Vector3(3.3f, 3.3f, 1.1f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 2;
                }
                else if (!Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    Destroy(Plane[i].transform.GetChild(0).gameObject);
                    GameObject KyderForCreate = Instantiate(Resources.Load("Prefabs/Kyder")) as GameObject;
                    KyderForCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //KyderForCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    KyderForCreate.transform.parent = Plane[i].transform;
                    KyderForCreate.transform.localScale = new Vector3(3.3f, 3.3f, 1.1f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        KyderForCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 2;
                }
            }
            if (ObjectJson["NowType"][i] == 3)
            {
                if (Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    GameObject BushColCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushC")) as GameObject;
                    BushColCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //BushColCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    BushColCreate.transform.parent = Plane[i].transform;
                    BushColCreate.transform.localScale = new Vector3(1f, 1f, 0.3f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 3;
                }
                else if (!Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    Destroy(Plane[i].transform.GetChild(0).gameObject);
                    GameObject BushColCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushC")) as GameObject;
                    BushColCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //BushColCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    BushColCreate.transform.parent = Plane[i].transform;
                    BushColCreate.transform.localScale = new Vector3(1f, 1f, 0.3f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        BushColCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 3;
                }
            }
            if (ObjectJson["NowType"][i] == 4)
            {
                if (Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    GameObject BushRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushR")) as GameObject;
                    BushRowCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //BushRowCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    BushRowCreate.transform.parent = Plane[i].transform;
                    BushRowCreate.transform.localScale = new Vector3(1f, 1f, 0.3f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(0, 90, 90);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(0, -90, 90);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(-90, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(90, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(0, 0, 90);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(0, 180, 90);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 4;
                }
                else if (!Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    Destroy(Plane[i].transform.GetChild(0).gameObject);
                    GameObject BushRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/BushR")) as GameObject;
                    BushRowCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //BushRowCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    BushRowCreate.transform.parent = Plane[i].transform;
                    BushRowCreate.transform.localScale = new Vector3(1f, 1f, 0.3f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(0, 90, 90);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(0, -90, 90);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(-90, 90,0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(90, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(0, 0, 90);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        BushRowCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                        BushRowCreate.transform.eulerAngles = new Vector3(0, 180, 90);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 4;
                }
            }
            if (ObjectJson["NowType"][i] == 5)
            {
                if (Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    GameObject RailingColCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingColCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //RailingColCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    RailingColCreate.transform.parent = Plane[i].transform;
                    RailingColCreate.transform.localScale = new Vector3(3f, 3f, 0.9f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 5;
                }
                else if (!Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    Destroy(Plane[i].transform.GetChild(0).gameObject);
                    GameObject RailingColCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingColCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //RailingColCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    RailingColCreate.transform.parent = Plane[i].transform;
                    RailingColCreate.transform.localScale = new Vector3(3f, 3f, 0.9f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        RailingColCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 5;
                }
            }
            if (ObjectJson["NowType"][i] == 6)
            {
                if (Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    GameObject RailingRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingRowCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //RailingRowCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    RailingRowCreate.transform.parent = Plane[i].transform;
                    RailingRowCreate.transform.localScale = new Vector3(3f, 3f, 0.9f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(0, 90, 90);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(0, -90, 90);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(-90, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(90, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(0, 0, 90);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(0, 180, 90);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 6;
                }
                else if (!Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    Destroy(Plane[i].transform.GetChild(0).gameObject);
                    GameObject RailingRowCreate = Instantiate(Resources.Load("Prefabs/Level_00/Railing")) as GameObject;
                    RailingRowCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //RailingRowCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    RailingRowCreate.transform.parent = Plane[i].transform;
                    RailingRowCreate.transform.localScale = new Vector3(3f, 3f, 0.9f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(0, 90, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(0, 90, 90);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(0, -90, 90);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(-90, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(90, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(0, 0, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(0, 0, 90);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        RailingRowCreate.transform.rotation = Quaternion.Euler(0, 180, 0);
                        RailingRowCreate.transform.eulerAngles = new Vector3(0, 180, 90);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 6;
                }
            }
            if (ObjectJson["NowType"][i] == 7)
            {
                if (Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    GameObject WareHouseCreate = Instantiate(Resources.Load("Prefabs/Level_00/WareHouse")) as GameObject;
                    WareHouseCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //WareHouseCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    WareHouseCreate.transform.parent = Plane[i].transform;
                    WareHouseCreate.transform.localScale = new Vector3(9.9f, 2.97f, 9.9f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(180, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 7;
                }
                else if (!Plane[i].GetComponent<MainCreateController>().IsEmpty)
                {
                    Destroy(Plane[i].transform.GetChild(0).gameObject);
                    GameObject WareHouseCreate = Instantiate(Resources.Load("Prefabs/Level_00/WareHouse")) as GameObject;
                    WareHouseCreate.transform.position = new Vector3(ObjectJson["PositionX"][i], ObjectJson["PositionY"][i], ObjectJson["PositionZ"][i]);
                    //WareHouseCreate.transform.rotation = Quaternion.Euler(ObjectJson["RotationX"][i], ObjectJson["RotationY"][i], ObjectJson["RotationZ"][i]);
                    WareHouseCreate.transform.parent = Plane[i].transform;
                    WareHouseCreate.transform.localScale = new Vector3(9.9f, 2.97f, 9.9f);
                    if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x > -1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x < -1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    else if (Plane[i].transform.parent.position.x - Plane[i].transform.position.x < 1.6 && Plane[i].transform.parent.position.x - Plane[i].transform.position.x > 1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y > -1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y < -1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if (Plane[i].transform.parent.position.y - Plane[i].transform.position.y < 1.6 && Plane[i].transform.parent.position.y - Plane[i].transform.position.y > 1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(180, 90, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z > -1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z < -1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (Plane[i].transform.parent.position.z - Plane[i].transform.position.z < 1.6 && Plane[i].transform.parent.position.z - Plane[i].transform.position.z > 1.4)
                    {
                        WareHouseCreate.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = false;
                    Plane[i].GetComponent<MainCreateController>().Type = 7;
                }
            }
            if (ObjectJson["NowType"][i] == 0 && !Plane[i].GetComponent<MainCreateController>().IsEmpty)
            {
                //if(i != 61)
                //{
                    Destroy(Plane[i].transform.GetChild(0).gameObject);
                    Plane[i].GetComponent<MainCreateController>().IsEmpty = true;
                    Plane[i].GetComponent<MainCreateController>().Type = 0;
                //}
            }
        }
    }

}
