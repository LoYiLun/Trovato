using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	//private Vector3 CubeHeart;
	//private Vector3 CubeRotateDir;
	//private float MouseTan;
	public GameObject Arrow;
	private GameObject TemptCube;
	private Material OriginMaterial;

	void Start () {
		OriginMaterial = Resources.Load ("Materials/Yellow", typeof(Material)) as Material;


		//Arrow = GameObject.Find ("Arrow");
	}


	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;




		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hitInfo, 500, 1 << 10) && Global.StopTouch != true) {
			Debug.DrawLine (Camera.main.transform.position, hitInfo.transform.position, Color.yellow, 0.1f, true);
			Global.BeTouchedObj = hitInfo.collider.gameObject;
			if (Global.Player.activeSelf) 
			{
				Global.PlayerMove = true;
			}
		} 

		if (Input.GetMouseButton (1) && Physics.Raycast (ray, out hitInfo, 500, 1 << 9)) {
			Debug.DrawLine (Camera.main.transform.position, hitInfo.transform.position, Color.blue, 0.1f, true);
			Global.BeTouchedCube = hitInfo.collider.gameObject;
			Global.BePointedObj = hitInfo.collider.gameObject;

			//CubeRotateDir = Input.mousePosition - CubeHeart;
			//MouseTan = CubeRotateDir.y / CubeRotateDir.x;
			//print (MouseTan);

			if (Global.IsRotating != true && Global.PlayerMove != true) {
				if (Global.BeTouchedCube.name == "a1") {

						if (TemptCube.name == "PL1") {
							Global.RotateNum = 15;
						} else if (TemptCube.name == "PL2") {
							Global.RotateNum = 15;
						} else if (TemptCube.name == "PL3") {
							Global.RotateNum = 15;
						} else if (TemptCube.name == "PL4") {
							Global.RotateNum = 14;
						} else if (TemptCube.name == "PL5") {
							Global.RotateNum = 13;
						} else if (TemptCube.name == "PL6") {
							Global.RotateNum = 14;
						} else if (TemptCube.name == "PL7") {
							Global.RotateNum = 14;
						} else if (TemptCube.name == "PL8") {
							Global.RotateNum = 13;
						} else if (TemptCube.name == "PL9") {
							Global.RotateNum = 13;
						} else if (TemptCube.name == "PR1") {
							Global.RotateNum = 4;
						} else if (TemptCube.name == "PR2") {
							Global.RotateNum = 4;
						} else if (TemptCube.name == "PR3") {
							Global.RotateNum = 4;
						} else if (TemptCube.name == "PR4") {
							Global.RotateNum = 5;
						} else if (TemptCube.name == "PR5") {
							Global.RotateNum = 6;
						} else if (TemptCube.name == "PR6") {
							Global.RotateNum = 5;
						} else if (TemptCube.name == "PR7") {
							Global.RotateNum = 5;
						} else if (TemptCube.name == "PR8") {
							Global.RotateNum = 6;
						} else if (TemptCube.name == "PR9") {
							Global.RotateNum = 6;

					}else if (TemptCube.name == "V2_PL1") {
							Global.RotateNum = -10;
						} else if (TemptCube.name == "V2_PL2") {
							Global.RotateNum = -10;
						} else if (TemptCube.name == "V2_PL3") {
							Global.RotateNum = -9;
						} else if (TemptCube.name == "V2_PL4") {
							Global.RotateNum = -9;
						} else if (TemptCube.name == "V2_PR1") {
							Global.RotateNum = -3;
						} else if (TemptCube.name == "V2_PR2") {
							Global.RotateNum = -3;
						} else if (TemptCube.name == "V2_PR3") {
							Global.RotateNum = -4;
						} else if (TemptCube.name == "V2_PR4") {
							Global.RotateNum = -4;
						}


					/* PlaneD 
					else if (TemptCube.name == "PD1") {
						Global.RotateNum = 3;
					} else if (TemptCube.name == "PD2") {
						Global.RotateNum = 3;
					} else if (TemptCube.name == "PD3") {
						Global.RotateNum = 3;
					} else if (TemptCube.name == "PD4") {
						Global.RotateNum = 2;
					} else if (TemptCube.name == "PD5") {
						Global.RotateNum = 1;
					}*/
					Global.ClickRotate ();
					Arrow.transform.position = new Vector3 (100, 100, 100);

				} else if (Global.BeTouchedCube.name == "a2") {

					if (TemptCube.name == "PL1") {
						Global.RotateNum = 4;
					} else if (TemptCube.name == "PL2") {
						Global.RotateNum = 4;
					} else if (TemptCube.name == "PL3") {
						Global.RotateNum = 4;
					} else if (TemptCube.name == "PL4") {
						Global.RotateNum = 5;
					} else if (TemptCube.name == "PL5") {
						Global.RotateNum = 6;
					} else if (TemptCube.name == "PL6") {
						Global.RotateNum = 5;
					} else if (TemptCube.name == "PL7") {
						Global.RotateNum = 5;
					} else if (TemptCube.name == "PL8") {
						Global.RotateNum = 6;
					} else if (TemptCube.name == "PL9") {
						Global.RotateNum = 6;
					} else if (TemptCube.name == "PR1") {
						Global.RotateNum = 15;
					} else if (TemptCube.name == "PR2") {
						Global.RotateNum = 15;
					} else if (TemptCube.name == "PR3") {
						Global.RotateNum = 15;
					} else if (TemptCube.name == "PR4") {
						Global.RotateNum = 14;
					} else if (TemptCube.name == "PR5") {
						Global.RotateNum = 13;
					} else if (TemptCube.name == "PR6") {
						Global.RotateNum = 14;
					} else if (TemptCube.name == "PR7") {
						Global.RotateNum = 14;
					} else if (TemptCube.name == "PR8") {
						Global.RotateNum = 13;
					} else if (TemptCube.name == "PR9") {
						Global.RotateNum = 13;
					}

					else if (TemptCube.name == "V2_PL1") {
						Global.RotateNum = -3;
					} else if (TemptCube.name == "V2_PL2") {
						Global.RotateNum = -3;
					} else if (TemptCube.name == "V2_PL3") {
						Global.RotateNum = -4;
					} else if (TemptCube.name == "V2_PL4") {
						Global.RotateNum = -4;
					} else if (TemptCube.name == "V2_PR1") {
						Global.RotateNum = -10;
					} else if (TemptCube.name == "V2_PR2") {
						Global.RotateNum = -10;
					} else if (TemptCube.name == "V2_PR3") {
						Global.RotateNum = -9;
					} else if (TemptCube.name == "V2_PR4") {
						Global.RotateNum = -9;
					}

					/* else if (TemptCube.name == "PD1") {
					Global.RotateNum = 10;
				} else if (TemptCube.name == "PD2") {
					Global.RotateNum = 10;
				} else if (TemptCube.name == "PD3") {
					Global.RotateNum = 10;
				} else if (TemptCube.name == "PD4") {
					Global.RotateNum = 11;
				} else if (TemptCube.name == "PD5") {
					Global.RotateNum = 12;
				}*/
					Global.ClickRotate ();
					Arrow.transform.position = new Vector3 (100, 100, 100);

				}
				if (Global.BeTouchedCube.name == "a3") {

					if (TemptCube.name == "PL1") {
						Global.RotateNum = 1;
					} else if (TemptCube.name == "PL2") {
						Global.RotateNum = 2;
					} else if (TemptCube.name == "PL3") {
						Global.RotateNum = 3;
					} else if (TemptCube.name == "PL4") {
						Global.RotateNum = 3;
					} else if (TemptCube.name == "PL5") {
						Global.RotateNum = 3;
					} else if (TemptCube.name == "PL6") {
						Global.RotateNum = 1;
					} else if (TemptCube.name == "PL7") {
						Global.RotateNum = 2;
					} else if (TemptCube.name == "PL8") {
						Global.RotateNum = 2;
					} else if (TemptCube.name == "PL9") {
						Global.RotateNum = 1;
					} else if (TemptCube.name == "PR1") {
						Global.RotateNum = 18;
					} else if (TemptCube.name == "PR2") {
						Global.RotateNum = 17;
					} else if (TemptCube.name == "PR3") {
						Global.RotateNum = 16;
					} else if (TemptCube.name == "PR4") {
						Global.RotateNum = 16;
					} else if (TemptCube.name == "PR5") {
						Global.RotateNum = 16;
					} else if (TemptCube.name == "PR6") {
						Global.RotateNum = 18;
					} else if (TemptCube.name == "PR7") {
						Global.RotateNum = 17;
					} else if (TemptCube.name == "PR8") {
						Global.RotateNum = 17;
					} else if (TemptCube.name == "PR9") {
						Global.RotateNum = 18;
					}

					else if (TemptCube.name == "V2_PL1") {
						Global.RotateNum = -1;
					} else if (TemptCube.name == "V2_PL2") {
						Global.RotateNum = -2;
					} else if (TemptCube.name == "V2_PL3") {
						Global.RotateNum = -2;
					} else if (TemptCube.name == "V2_PL4") {
						Global.RotateNum = -1;
					} else if (TemptCube.name == "V2_PR1") {
						Global.RotateNum = -12;
					} else if (TemptCube.name == "V2_PR2") {
						Global.RotateNum = -11;
					} else if (TemptCube.name == "V2_PR3") {
						Global.RotateNum = -11;
					} else if (TemptCube.name == "V2_PR4") {
						Global.RotateNum = -12;
					}

					/* else if (TemptCube.name == "PD1") {
					Global.RotateNum = 7;
				} else if (TemptCube.name == "PD2") {
					Global.RotateNum = 8;
				} else if (TemptCube.name == "PD3") {
					Global.RotateNum = 9;
				} else if (TemptCube.name == "PD4") {
					Global.RotateNum = 9;
				} else if (TemptCube.name == "PD5") {
					Global.RotateNum = 9;
				}*/
					Global.ClickRotate ();
					Arrow.transform.position = new Vector3 (100, 100, 100);

				}
				if (Global.BeTouchedCube.name == "a4") {

					if (TemptCube.name == "PL1") {
						Global.RotateNum = 12;
					} else if (TemptCube.name == "PL2") {
						Global.RotateNum = 11;
					} else if (TemptCube.name == "PL3") {
						Global.RotateNum = 10;
					} else if (TemptCube.name == "PL4") {
						Global.RotateNum = 10;
					} else if (TemptCube.name == "PL5") {
						Global.RotateNum = 10;
					} else if (TemptCube.name == "PL6") {
						Global.RotateNum = 12;
					} else if (TemptCube.name == "PL7") {
						Global.RotateNum = 11;
					} else if (TemptCube.name == "PL8") {
						Global.RotateNum = 11;
					} else if (TemptCube.name == "PL9") {
						Global.RotateNum = 12;
					} else if (TemptCube.name == "PR1") {
						Global.RotateNum = 7;
					} else if (TemptCube.name == "PR2") {
						Global.RotateNum = 8;
					} else if (TemptCube.name == "PR3") {
						Global.RotateNum = 9;
					} else if (TemptCube.name == "PR4") {
						Global.RotateNum = 9;
					} else if (TemptCube.name == "PR5") {
						Global.RotateNum = 9;
					} else if (TemptCube.name == "PR6") {
						Global.RotateNum = 7;
					} else if (TemptCube.name == "PR7") {
						Global.RotateNum = 8;
					} else if (TemptCube.name == "PR8") {
						Global.RotateNum = 8;
					} else if (TemptCube.name == "PR9") {
						Global.RotateNum = 7;
					}

					else if (TemptCube.name == "V2_PL1") {
						Global.RotateNum = -8;
					} else if (TemptCube.name == "V2_PL2") {
						Global.RotateNum = -7;
					} else if (TemptCube.name == "V2_PL3") {
						Global.RotateNum = -7;
					} else if (TemptCube.name == "V2_PL4") {
						Global.RotateNum = -8;
					} else if (TemptCube.name == "V2_PR1") {
						Global.RotateNum = -5;
					} else if (TemptCube.name == "V2_PR2") {
						Global.RotateNum = -6;
					} else if (TemptCube.name == "V2_PR3") {
						Global.RotateNum = -6;
					} else if (TemptCube.name == "V2_PR4") {
						Global.RotateNum = -5;
					}

					/* else if (TemptCube.name == "PD1") {
					Global.RotateNum = 18;
				} else if (TemptCube.name == "PD2") {
					Global.RotateNum = 17;
				} else if (TemptCube.name == "PD3") {
					Global.RotateNum = 16;
				} else if (TemptCube.name == "PD4") {
					Global.RotateNum = 16;
				} else if (TemptCube.name == "PD5") {
					Global.RotateNum = 16;
				}*/
					Global.ClickRotate ();
					Arrow.transform.position = new Vector3 (100, 100, 100);

				}
			}

			//hitInfo.collider.gameObject.SetActive (false);
		}

		if (Input.GetMouseButtonDown (1) && Global.IsRotating != true && Global.PlayerMove != true) {
			//CubeHeart = Input.mousePosition;
				Arrow.transform.position = Global.BeTouchedCube.transform.position;
				TemptCube = Global.BeTouchedCube;
				Global.BeTouchedCube.GetComponent<Renderer> ().material = OriginMaterial;
				Arrow.transform.rotation = Global.BeTouchedCube.transform.rotation;


		}

		if (Input.GetMouseButtonUp (1)) {
			Arrow.transform.position = new Vector3 (100, 100, 100);
			Global.BeTouchedCube = GameObject.Find("VeryFarPosition");
		}


	}
}
