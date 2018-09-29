using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomRoute : MonoBehaviour {

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

	[SerializeField]
	GameObject[] CubePrefabs;

	void Awake(){

	}

	void Start () {



		if(Global.Level == "1" || Global.Level == "3"){
			for (int i = 0; i < 4; i++) {
				TemptV2 [k] = Instantiate (CubePrefabs [V2PlaneA_ID [i]], CubeV2Plane_A [i].transform.position, Quaternion.Euler (0, 0, 0));
				TemptV2 [k].transform.parent = CubeV2Plane_A [i].transform;
				k++;

				TemptV2 [k] = Instantiate (CubePrefabs [V2PlaneB_ID [i]], CubeV2Plane_B [i].transform.position, Quaternion.Euler (0, 0, -90));
				TemptV2 [k].transform.parent = CubeV2Plane_B [i].transform;
				k++;

				TemptV2 [k] = Instantiate (CubePrefabs [V2PlaneC_ID [i]], CubeV2Plane_C [i].transform.position, Quaternion.Euler (90, 0, 0));
				TemptV2 [k].transform.parent = CubeV2Plane_C [i].transform;
				k++;

				TemptV2 [k] = Instantiate (CubePrefabs [V2PlaneD_ID [i]], CubeV2Plane_D [i].transform.position, Quaternion.Euler (0, 0, 90));
				TemptV2 [k].transform.parent = CubeV2Plane_D [i].transform;
				k++;

				TemptV2 [k] = Instantiate (CubePrefabs [V2PlaneE_ID [i]], CubeV2Plane_E [i].transform.position, Quaternion.Euler (-90, 0, 0));
				TemptV2 [k].transform.parent = CubeV2Plane_E [i].transform;
				k++;

				TemptV2 [k] = Instantiate (CubePrefabs [V2PlaneF_ID [i]], CubeV2Plane_F [i].transform.position, Quaternion.Euler (180, 0, 0));
				TemptV2 [k].transform.parent = CubeV2Plane_F [i].transform;
				k++;
			}
		}

		if (Global.Level == "2" || Global.Level == "3") {
			for (int i = 0; i < 9; i++) {
				TemptV3 [j] = Instantiate (CubePrefabs [PlaneA_ID [i]], CubeV3Plane_A [i].transform.position, Quaternion.Euler (0, 0, 0));
				TemptV3 [j].transform.parent = CubeV3Plane_A [i].transform;
				j++;

				TemptV3 [j] = Instantiate (CubePrefabs [PlaneB_ID [i]], CubeV3Plane_B [i].transform.position, Quaternion.Euler (0, 0, -90));
				TemptV3 [j].transform.parent = CubeV3Plane_B [i].transform;
				j++;

				TemptV3 [j] = Instantiate (CubePrefabs [PlaneC_ID [i]], CubeV3Plane_C [i].transform.position, Quaternion.Euler (90, 0, 0));
				TemptV3 [j].transform.parent = CubeV3Plane_C [i].transform;
				j++;

				TemptV3 [j] = Instantiate (CubePrefabs [PlaneD_ID [i]], CubeV3Plane_D [i].transform.position, Quaternion.Euler (0, 0, 90));
				TemptV3 [j].transform.parent = CubeV3Plane_D [i].transform;
				j++;

				TemptV3 [j] = Instantiate (CubePrefabs [PlaneE_ID [i]], CubeV3Plane_E [i].transform.position, Quaternion.Euler (-90, 0, 0));
				TemptV3 [j].transform.parent = CubeV3Plane_E [i].transform;
				j++;

				TemptV3 [j] = Instantiate (CubePrefabs [PlaneF_ID [i]], CubeV3Plane_F [i].transform.position, Quaternion.Euler (180, 0, 0));
				TemptV3 [j].transform.parent = CubeV3Plane_F [i].transform;
				j++;
			}
		}
	}
		
	void Update () {
		
	}

	public void Rebuild(){
		Global.IsPushing = false;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

}
