using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafEffect : MonoBehaviour {

	public GameObject Leaf;
	public int Speed = 50;
	private GameObject[] Leaves = new GameObject[6];
	private Vector3 OriginPosition;
	private int Count;

	void FixedUpdate () {
		OriginPosition = Leaf.transform.position;

		// 主角撞擊灌木叢時的動畫
		// 設定葉子初始位置
		if (Input.GetKeyDown (KeyCode.A) || Count == 0) {
			
			for (int i = 0; i < 6 ; i++) {
				Leaves [i] = Instantiate (Leaf);
				Leaves [i].transform.position = Leaf.transform.position;
				Leaves [i].transform.position += new Vector3 (Random.Range(-0.3f - i/10, 0.3f + i/10), 0.3f, Random.Range(-0.3f - i/10, 0.3f + i/10)); 
			}
			Count = 1;
		}

		// 葉子往上彈出
		if (Count == 1) {
			foreach (GameObject leaf in Leaves) {
				leaf.GetComponent<Rigidbody> ().isKinematic = false;
				leaf.GetComponent<Rigidbody> ().AddForce (0, Speed*2, 0);
			
				if (Vector3.Distance (OriginPosition, leaf.transform.position) >= 0.45f) {
					Count = 2;
				}
			}
		}

		// 葉子掙扎著落下
		if (Count == 2) {
			float A = 40f / Time.deltaTime;
			foreach (GameObject leaf in Leaves) {
				leaf.transform.position += new Vector3 (Random.Range(-Speed/A, Speed/A), 0, Random.Range(-Speed/A, Speed/A));
				if (leaf.transform.position.y - OriginPosition.y < 0) {
					Destroy (leaf);
					Count = 0;
					gameObject.GetComponent<LeafEffect> ().enabled = false;
				}
			}
		}
	}
}
