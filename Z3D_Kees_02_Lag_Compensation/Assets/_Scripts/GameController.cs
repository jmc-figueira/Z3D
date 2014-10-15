using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public float Freeze_Counter_init;
	public Text Debugger;
	public float Freeze_Counter;
	
	
	// Use this for initialization
	void Start () {
		Freeze_Counter = Freeze_Counter_init;
	}
	
	// Update is called once per frame
	void Update () {
		//Currently the freeze_counter is primarily used to reset the game on a fancy way  
		#region [restarter]
		if (Freeze_Counter>Freeze_Counter_init){
			Freeze_Counter--;
			Debugger.text = "You died!!!";
			if(Freeze_Counter<=Freeze_Counter_init){
			Application.LoadLevel(Application.loadedLevel);
			}
		}else if(Freeze_Counter>0){
			Debugger.text = Mathf.Ceil(Freeze_Counter/20f).ToString();
			Freeze_Counter--;
			if(Freeze_Counter<=0){
				Debugger.text = "GO!";
				Freeze_Counter=0f;
			}
		}
		#endregion
	}
}
