using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustTest : MonoBehaviour {

	private GameObject plane;
	private float emission;
	//private Color _color;

	void Start () {
		plane = gameObject;
		//_color = plane.GetComponent<Renderer> ().material.color;


	}
	

	void Update () {
		
		// 物體浮空旋轉
		transform.parent.transform.localPosition = new Vector3 (0, Mathf.Sin(Time.time)/2 + 3, 0);
		transform.parent.transform.Rotate (0, 0, 10*Time.deltaTime);

		// 調整發光材質閃爍
		//emission = Mathf.PingPong (30f * Time.time, 50.0f);
		//plane.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", _color * Mathf.LinearToGammaSpace(emission));
	}
}
