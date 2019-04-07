using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideMode : MonoBehaviour {

	public GameObject camTarget;
	public GameObject insideCam;
	public List<GameObject> exits = new List<GameObject>();
	private float oldCamView;
	private Vector3 oldCamPosition;
	private Vector3 oldPlayerPosition;
	private Quaternion oldPlayerRotation;

	InsideMode(GameObject _camTarget, GameObject _insideCam, List<GameObject> _exits){
		camTarget = _camTarget;
		insideCam = _insideCam;
		exits = _exits;
	}

	void Start(){
		
	}

	public void reset(){
		oldCamView = CameraController.CamView;
		oldCamPosition = CameraController.CurrentCam.transform.position;
		oldPlayerPosition = Global.Player.transform.position;
		oldPlayerRotation = GameObject.Find("GlobalScripts").GetComponent<PathController>().FaceRotation;
		setCamera(CameraController.CurrentCam, insideCam.transform.position, 40, camTarget);
		setPlayer(Global.Player, exits[0].transform.position, 0, true);
	
	}

	public float getOldCamView(){
		return oldCamView;
	}

	public Vector3 getOldCamPosition(){
		return oldCamPosition;
	}

	public Vector3 getOldPlayerPosition(){
		return oldPlayerPosition;
	}

	public void setCamera(GameObject _cam, Vector3 _newPosition, float _camView, GameObject _camTarget){
		if(_cam != null && _newPosition != null){
			CameraController.CamView = _camView;
			_cam.transform.position = _newPosition;
			_cam.transform.rotation = Quaternion.LookRotation(_camTarget.transform.position - _newPosition, _camTarget.transform.up);

		}
	}

	public void setPlayer(GameObject _player, Vector3 _newPosition, int index, bool goInside){
		if(_player != null && _newPosition != null){
			_player.transform.position = _newPosition;
			if(index >= 0){
				if(goInside){
					GameObject.Find("GlobalScripts").GetComponent<PathController>().FaceRotation = exits[index].transform.rotation;
					_player.transform.position = exits[index].transform.position + exits[index].transform.forward;
				}else{
					GameObject.Find("GlobalScripts").GetComponent<PathController>().FaceRotation = oldPlayerRotation * Quaternion.Euler(0, 180, 0);
				}
			}
		}
	}
}
