using UnityEngine;
using System.Collections;

public class Tail_Behaviour : MonoBehaviour {

	public float Tail_Timer;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = Tail_Timer;
		collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer>0){
		}else{
		timer=0f;
		}
	}
}
