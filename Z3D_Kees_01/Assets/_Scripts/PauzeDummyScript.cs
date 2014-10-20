using UnityEngine;
using System.Collections;

public class PauzeDummyScript : MonoBehaviour {
	public GameObject playerPrefab1;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			Debug.Log("space key was pressed");
			if(Time.timeScale==1f)
			Time.timeScale =  0f;
			else
			Time.timeScale =  1f;
			}
	}
}
