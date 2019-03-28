using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustTest : MonoBehaviour {

	private GameObject plane;
	private float emission;
	private Color _color;

	void Start () {
		plane = gameObject;
		_color = plane.GetComponent<Renderer> ().material.color;


	}
	

	void Update () {
		
		transform.parent.transform.localPosition = new Vector3 (0, Mathf.Sin(Time.time)/2 + 3, 0);
		transform.parent.transform.Rotate (0, 0, 10*Time.deltaTime);

		emission = Mathf.PingPong (30f * Time.time, 50.0f);
		//emission = Mathf.Cos (3 * Time.time) * 20;
		plane.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", _color * Mathf.LinearToGammaSpace(emission));
	}
}
