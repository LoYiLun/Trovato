using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowName : MonoBehaviour {

	public static bool IsPointing;
	public GameObject BePointedObj;
	private Text Name{get { return gameObject.transform.GetChild (0).gameObject.GetComponent<Text>();}}
	public Vector3 FixedMove = new Vector3(150, -50, 0);
	private Ray ray;
	private Ray downray;
	private RaycastHit Eventinfo;
	public RaycastHit Downinfo;
	public GameObject Floor;

	void Awake(){
		downray.direction = Vector3.down;
	}

	void Start () {
		
	}
	

	void Update () {

		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		gameObject.transform.position = Input.mousePosition + FixedMove;

		if (Physics.Raycast (ray, out Eventinfo, 100)) {
			BePointedObj = Eventinfo.collider.gameObject;
			EditName (Eventinfo.collider.gameObject.name);
			IsPointing = true;
			
		} else {
			IsPointing = false;
		}

		if (IsPointing && BePointedObj.tag == "Obstacle" && BePointedObj.layer == 20) {
			gameObject.GetComponent<Image> ().enabled = true;
			Name.enabled = true;
			if (Input.GetMouseButtonDown (0)) {
				// just for cube.
				BePointedObj.GetComponent<Renderer> ().material.color = Color.yellow;
				SetTarget ();
			}

		} else {
			gameObject.GetComponent<Image> ().enabled = false;
			Name.enabled = false;
		}
	}

	void SetTarget(){
		downray.origin = BePointedObj.transform.position;
		if(Physics.Raycast(downray, out Downinfo, 1, 1 << 10) && !Global.IsPreRotating && !Global.StopTouch && !CameraController.IsCamRotating){
			Floor = Downinfo.collider.gameObject;
			//GameObject.Find ("GlobalScripts").GetComponent<PathController> ().hitinfo = Downinfo;
		}else{
			Floor = null;
		}
	}

	void EditName(string _Name){
		switch (_Name) {
		case "Rose":
			Name.text = "玫瑰";
			break;
		case "SuperCube":
			Name.text = "傳送點";
			break;
		case "Bush":
			Name.text = "草叢";
			break;

		default:
			Name.text = "Null";
			break;
				
		}
	}
}
