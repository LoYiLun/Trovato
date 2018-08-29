using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomRoute : MonoBehaviour {

	public GameObject[] RoadBlocks;

	public GameObject[] CubeV2Plane_A;
	public GameObject[] CubeV2Plane_B;
	public GameObject[] CubeV2Plane_C;
	public GameObject[] CubeV2Plane_D;
	public GameObject[] CubeV2Plane_E;
	public GameObject[] CubeV2Plane_F;

	public GameObject[] CubeV3Plane_A;
	public GameObject[] CubeV3Plane_B;
	public GameObject[] CubeV3Plane_C;
	public GameObject[] CubeV3Plane_D;
	public GameObject[] CubeV3Plane_E;
	public GameObject[] CubeV3Plane_F;

	public int[] V2PlaneA_ID = new int[4];
	public int[] V2PlaneB_ID = new int[4];
	public int[] V2PlaneC_ID = new int[4];
	public int[] V2PlaneD_ID = new int[4];
	public int[] V2PlaneE_ID = new int[4];
	public int[] V2PlaneF_ID = new int[4];

	public int[] PlaneA_ID = new int[9];
	public int[] PlaneB_ID = new int[9];
	public int[] PlaneC_ID = new int[9];
	public int[] PlaneD_ID = new int[9];
	public int[] PlaneE_ID = new int[9];
	public int[] PlaneF_ID = new int[9];
	GameObject[] TemptV2 = new GameObject[24];
	GameObject[] TemptV3 = new GameObject[54];
	int k = 0;
	int j = 0;

	void Awake(){
		for (int i = 0; i < 4; i++) {
			TemptV2[k] = Instantiate (RoadBlocks [V2PlaneA_ID[i]], CubeV2Plane_A [i].transform.position, Quaternion.Euler (0, 0, 0));
			TemptV2[k].transform.parent = CubeV2Plane_A [i].transform;
			k++;

			TemptV2[k] = Instantiate (RoadBlocks [V2PlaneB_ID[i]], CubeV2Plane_B [i].transform.position, Quaternion.Euler (0, 0, -90));
			TemptV2[k].transform.parent = CubeV2Plane_B [i].transform;
			k++;

			TemptV2[k] = Instantiate (RoadBlocks [V2PlaneC_ID[i]], CubeV2Plane_C [i].transform.position, Quaternion.Euler (90, 0, 0));
			TemptV2[k].transform.parent = CubeV2Plane_C [i].transform;
			k++;

			TemptV2[k] = Instantiate (RoadBlocks [V2PlaneD_ID[i]], CubeV2Plane_D [i].transform.position, Quaternion.Euler (0, 0, 90));
			TemptV2[k].transform.parent = CubeV2Plane_D [i].transform;
			k++;

			TemptV2[k] = Instantiate (RoadBlocks [V2PlaneE_ID[i]], CubeV2Plane_E [i].transform.position, Quaternion.Euler (-90, 0, 0));
			TemptV2[k].transform.parent = CubeV2Plane_E [i].transform;
			k++;

			TemptV2[k] = Instantiate (RoadBlocks [V2PlaneF_ID[i]], CubeV2Plane_F [i].transform.position, Quaternion.Euler (180, 0, 0));
			TemptV2[k].transform.parent = CubeV2Plane_F [i].transform;
			k++;

		}

		for (int i = 0; i < 9; i++) {
			TemptV3[j] = Instantiate (RoadBlocks [PlaneA_ID[i]], CubeV3Plane_A [i].transform.position, Quaternion.Euler (0, 0, 0));
			TemptV3[j].transform.parent = CubeV3Plane_A [i].transform;
			j++;

			TemptV3[j] = Instantiate (RoadBlocks [PlaneB_ID[i]], CubeV3Plane_B [i].transform.position, Quaternion.Euler (0, 0, -90));
			TemptV3[j].transform.parent = CubeV3Plane_B [i].transform;
			j++;

			TemptV3[j] = Instantiate (RoadBlocks [PlaneC_ID[i]], CubeV3Plane_C [i].transform.position, Quaternion.Euler (90, 0, 0));
			TemptV3[j].transform.parent = CubeV3Plane_C [i].transform;
			j++;

			TemptV3[j] = Instantiate (RoadBlocks [PlaneD_ID[i]], CubeV3Plane_D [i].transform.position, Quaternion.Euler (0, 0, 90));
			TemptV3[j].transform.parent = CubeV3Plane_D [i].transform;
			j++;

			TemptV3[j] = Instantiate (RoadBlocks [PlaneE_ID[i]], CubeV3Plane_E [i].transform.position, Quaternion.Euler (-90, 0, 0));
			TemptV3[j].transform.parent = CubeV3Plane_E [i].transform;
			j++;

			TemptV3[j] = Instantiate (RoadBlocks [PlaneF_ID[i]], CubeV3Plane_F [i].transform.position, Quaternion.Euler (180, 0, 0));
			TemptV3[j].transform.parent = CubeV3Plane_F [i].transform;
			j++;
		}

		DelOrigin ();


	}

	void Start () {

		// 隨機生成迷宮
		/*
		for (int i = 0; i < 9; i++) {
			Tempt_A = Instantiate(RoadBlocks[Random.Range(0, 14)], CubeV3Plane_A [i].transform.position, Quaternion.Euler(0, 0, 0));
			Tempt_A.transform.parent = CubeV3Plane_A [i].transform;
			AllRoadBlocks [Count] = Tempt_A;
			Count++;
			if(AllRoadBlocks[0] != null)
			Destroy (AllRoadBlocks[0]);

			Tempt_B = Instantiate(RoadBlocks[Random.Range(0, 14)], CubeV3Plane_B [i].transform.position, Quaternion.Euler(0, 0, -90));
			Tempt_B.transform.parent = CubeV3Plane_B [i].transform;
			AllRoadBlocks [Count] = Tempt_B;
			Count++;

			Tempt_C = Instantiate(RoadBlocks[Random.Range(0, 14)], CubeV3Plane_C [i].transform.position, Quaternion.Euler(90, 0, 0));
			Tempt_C.transform.parent = CubeV3Plane_C [i].transform;
			AllRoadBlocks [Count] = Tempt_C;
			Count++;

			Tempt_D = Instantiate(RoadBlocks[Random.Range(0, 14)], CubeV3Plane_D [i].transform.position, Quaternion.Euler(0, 0, 90));
			Tempt_D.transform.parent = CubeV3Plane_D [i].transform;
			AllRoadBlocks [Count] = Tempt_D;
			Count++;

			Tempt_E = Instantiate(RoadBlocks[Random.Range(0, 14)], CubeV3Plane_E [i].transform.position, Quaternion.Euler(-90, 0, 0));
			Tempt_E.transform.parent = CubeV3Plane_E [i].transform;
			AllRoadBlocks [Count] = Tempt_E;
			Count++;

			Tempt_F = Instantiate(RoadBlocks[Random.Range(0, 14)], CubeV3Plane_F [i].transform.position, Quaternion.Euler(180, 0, 0));
			Tempt_F.transform.parent = CubeV3Plane_F [i].transform;
			AllRoadBlocks [Count] = Tempt_F;
			Count++;

		}*/
	
	
	}



	void Update () {
		
	}

	void DelOrigin(){
		foreach (GameObject blocks in RoadBlocks) {
			Destroy (blocks);
		}
	}

	public void Rebuild(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);

		/*
		for (int j = 0; j < 54; j++) {
			Destroy (AllRoadBlocks [j]);
		}

		Count = 0;
		*/

		}

}
