using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowName : MonoBehaviour {

	public static bool IsPointing;
	public GameObject BePointedObj;
	private Text Name{get { return gameObject.transform.GetChild (0).gameObject.GetComponent<Text>();}}
	public Vector3 FixedMove;
	private Ray ray;
	private RaycastHit Eventinfo;
	public RaycastHit Downinfo;

	void Awake(){
		
	}

	void Start () {
		
	}
	

	void Update () {
		FixedMove = new Vector3 (Screen.width / 1920 * 150, Screen.height / 1080 * (-50), 0);

		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		gameObject.transform.position = Input.mousePosition + FixedMove;

		if (Physics.Raycast (ray, out Eventinfo, 100)) {
			BePointedObj = Eventinfo.collider.gameObject;
			EditName (Eventinfo.collider.gameObject.name);
			IsPointing = true;
			
		} else {
			IsPointing = false;
			HideNameText ("null");
		}

		if (IsPointing && BePointedObj.tag == "Obstacle" && BePointedObj.layer == 20) {
			EditName (BePointedObj.name);
		}
}

	public void ShowNameText(string _Name){
		gameObject.GetComponent<Image> ().enabled = true;
		Name.enabled = true;
		Name.text = _Name;
	}

	public void HideNameText(string _Name){
		gameObject.GetComponent<Image> ().enabled = false;
		Name.enabled = false;
		Name.text = _Name;
	}
		
	public void EditName (string _Name)
	{
		switch (_Name) {

		// Level_01 //

		case "Rose":
			ShowNameText ("玫瑰");
			break;

		case "Shop_Door1":
		case "Shop_Door2":
			ShowNameText ("麵包店");
			break;

		case "PrinceHome_Door":
			ShowNameText ("王子家");
			break;

		case "GlassRepair":
			ShowNameText ("修伯里");
			break;

		case "Marley":
			ShowNameText ("馬雷");
			break;

		case "Mt.SpaceShip_Door1":
		case "Mt.SpaceShip_Door2":
			ShowNameText ("太空船");
			break;

		case "AnotherHouse_Door1":
		case "AnotherHouse_Door2":
		case "AnotherHouse_Door3":
			ShowNameText ("別人家");
			break;

		case "WareHouse_Door":
			ShowNameText ("倉庫");
			break;

		// Level_02 //

		case "Bill":
			ShowNameText ("比爾");
			break;

		case "Mike":
			ShowNameText ("麥克");
			break;

		case "Lucas":
			ShowNameText ("盧卡斯");
			break;

		case "Riven":
			ShowNameText ("瑞文");
			break;

		case "Sisco":
			ShowNameText ("西斯寇");
			break;

		case "Soyna":
			ShowNameText ("索依娜");
			break;

		case "Engine":
			ShowNameText ("引擎");
			break;

		case "IncinerationPlant":
		case "IncinerationPlant2":
		case "IncinerationPlant3":
		case "IncinerationPlant4":
		case "IncinerationPlant5":
		case "IncinerationPlant6":
			ShowNameText ("焚化廠");
			break;

		case "Kyder":
			ShowNameText ("水晶");
			break;

		case "Redleaf_A":
		case "Redleaf_B":
		case "Redleaf_C":
			ShowNameText ("紅葉草");
			break;

		case "Box_1":
		case "Box_2":
		case "Box_3":
			ShowNameText ("箱子");
			break;

		// Level_03 //

		case "Bookroom5":
			ShowNameText ("書房");
			break;

		case "Cat":
			ShowNameText ("貓咪");
			break;

		case "Fountain":
			ShowNameText ("噴水池");
			break;

		case "HouseKeeper":
			ShowNameText ("管家");
			break;

		case "King":
			ShowNameText ("國王");
			break;

		case "KingRoom1":
		case "KingRoom2":
		case "KingRoom3":
		case "KingRoom4":
		case "KingRoom5":
		case "KingRoom6":
			ShowNameText ("國王寢室");
			break;

		case "Maid":
			ShowNameText ("仕女");
			break;

		case "Portal":
		case "Portal2":
			ShowNameText ("傳送點");
			break;

		case "Servent":
			ShowNameText ("僕人");
			break;

		case "Warehouse2":
			ShowNameText ("倉庫");
			break;

		case "OldMan":
			ShowNameText ("老臣");
			break;

		case "Inscription":
			ShowNameText ("碑文");
			break;

		case "Palace":
			ShowNameText ("皇宮大廳");
			break;

		case "Graveyard":
			ShowNameText ("地底墓園");
			break;

		//------------------

		case "SuperCube":
			ShowNameText ("傳送點");
			break;

		case "Bush":
			HideNameText ("null");
			break;

		default:
			HideNameText ("null");
			break;

		}
	}
}
