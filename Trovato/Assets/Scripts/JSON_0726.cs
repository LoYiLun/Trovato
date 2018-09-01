using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSON_0726 : MonoBehaviour {

	UnityEngine.UI.Text PathText;
	void Start () {
		//PathText = GameObject.Find("PathText").GetComponent<UnityEngine.UI.Text>();
	}
	

	void Update () {

	}

	public void save(){
		PathText.text = Application.persistentDataPath;

		playerState myPlayer = new playerState();
		myPlayer.name = "Voidream";
		myPlayer.pos = Global.Player.transform.position;

		string saveString = JsonUtility.ToJson (myPlayer);

		StreamWriter file = new StreamWriter (System.IO.Path.Combine (Application.persistentDataPath, "myPlayer"));
		file.Write (saveString);
		file.Close ();
	}

	public void load(){
		StreamReader file = new StreamReader (System.IO.Path.Combine (Application.persistentDataPath, "myPlayer"));

		string loadJson = file.ReadToEnd ();
		file.Close();

		playerState loadData = new playerState ();
		loadData = JsonUtility.FromJson<playerState> (loadJson);
		GameObject.Find ("Player").transform.position = loadData.pos;
	}

}

public class playerState{

	public string name;
	public Vector3 pos;
	public playerState(){
		name = "Voidream";
		pos = Vector3.zero;
	}
}



