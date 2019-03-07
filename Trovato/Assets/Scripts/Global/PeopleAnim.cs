using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PeopleAnim : MonoBehaviour { 
	// 放在People_Skin裡面

	Animation anim;

	string blockName;
	List<Block> allBlock = new List<Block>();
	Block block;
	Command command;
	int number = -100;
	bool GoMoving;

	void Awake(){
		anim = GetComponent<Animation> ();

	}

	public void getBlock(){
		if (MissionSetting.FlowerChart != null && MissionSetting.FlowerChart.HasExecutingBlocks ()) {
			allBlock = MissionSetting.FlowerChart.GetExecutingBlocks ();
			block = allBlock [allBlock.Count - 1];
			command = block.ActiveCommand;
		}
	}

	public void StopAnim(Animation anim){
		anim.Rewind ();
		anim.Play ();
		anim.Sample ();
		anim.Stop ();
	}

	public void playAnimation(string _name, string _animation){
		if(gameObject.name == _name){
			anim.Play(_animation);
			GoMoving = false;
		}
	}

	void Update () {


		if (command != null && number != command.ItemId && !GoMoving) {
			number = command.ItemId;
			GoMoving = true;
		}

		getBlock ();

		if (command != null && GoMoving) {
			if (Global.Level == "1") {
				switch (command.ItemId) {
				case 12:
				case 22:
				case 40:
				case 97:
				case 73:
				case 71:
					playAnimation ("Rose_Skin", "Rose_angry");
					break;

				case 4:
				case 11:
				case 27:
				case 31:
				case 148:
				case 37:
				case 44:
				case 42:
				case 74:
				case 69:
				case 76:
				case 84:
					playAnimation ("Rose_Skin", "Rose_move");
					break;

				case 2:
				case 95:
				case 25:
				case 24:
					playAnimation ("Rose_Skin", "Rose_yawn");
					break;

				case 88:
					playAnimation ("Marley_Skin", "Marley_normal");
					break;

				case 58:
				case 56:
				case 53:
				case 122:
				case 126:
					playAnimation ("GlassRepair_Skin", "GlassRepair_normal");
					break;

				case 98:
					StopAnim (anim);
					break;
				}
			}

			if (Global.Level == "2") {
			
			}

			if (Global.Level == "3") {
				
			}
		}
	}
}
