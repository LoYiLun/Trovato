using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	//GameObject Player;
	Vector3 CurrentPos;
	Vector3 FixedHeight;
	public float Speed = 2f;

	void Start () 
	{
		FixedHeight = new Vector3 (0, 1f, 0);
	}
	

	void FixedUpdate () {
		//Player = Global.Player;
		if (Global.IsRotating == false) 
		{
			gameObject.transform.Translate (Speed * Time.deltaTime, 0, 0);
		} 
		else if(Global.RotateNum != 4 && Global.RotateNum != 15)
		{
			this.transform.position = CurrentPos + FixedHeight;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EnemyWall") 
		{
			Speed = -Speed;
		}
		if (other.gameObject.name == "Player") 
		{
			//Player.transform.position = new Vector3(4, 5.5f, 4);
			//Global.PlayerMove = false;
			Global.Retry();
		}
		if (other.gameObject.layer == 10) 
		{
			CurrentPos = other.gameObject.transform.position;
		}
	}
}
