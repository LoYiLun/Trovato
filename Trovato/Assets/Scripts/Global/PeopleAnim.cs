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
				switch (command.ItemId) {
				case 184:
				case 26:
				case 24:
				case 160:
				case 127:
				case 129:
				case 131:
					playAnimation ("Lucas_Skin", "Lucas_normal");
					break;
				
				case 187:
				case 41:
				case 163:
				case 166:
				case 44:
				case 42:
				case 49:
				case 136:
					playAnimation ("Soyna_Skin", "Soyna_normal");
					break;

				case 181:
				case 72:
				case 143:
					playAnimation ("Riven_Skin", "Riven_normal");
					break;

				case 167:
				case 169:
					playAnimation ("Riven_Skin", "Riven_think");
					break;

				case 190:
				case 97:
				case 149:
					playAnimation ("Sisco_Skin", "Sisco_normal");
					break;

				case 106:
					playAnimation ("Mike_Skin", "Mike_normal");
					break;

				case 107:
					playAnimation ("Bill_Skin", "Bill_normal");
					break;

				}
			}

			if (Global.Level == "3") {
				switch (command.ItemId) {
				case 78:
				case 76:
				case 9:
				case 14:
				case 80:
				case 18: // case 16 no move
				case 20:
				case 22:
				case 24:
				case 50:
				case 85:
				case 83:
					playAnimation ("King_Skin", "King_normal");
					break;

				case 7:
				case 47:
					playAnimation ("King_Skin", "King_bad");
					break;

				case 11:
				case 49:
				case 54:
					playAnimation ("King_Skin", "King_serious");
					break;

				case 89: // no case 58
				case 92:
				case 94: // no case 63
				case 248: // no case 247
				case 250:
					playAnimation ("HouseKeeper_Skin", "HouseKeeper_normal");
					break;

				case 276:
				case 278:
					playAnimation ("Maid_Skin", "Maid_nervous");
					break;
					// not normal yet

				}
			}
		}
	}
}
