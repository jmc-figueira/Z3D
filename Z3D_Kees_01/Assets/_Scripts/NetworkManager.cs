﻿using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public GameObject playerPrefab;
	public Transform spawnObject;
	public Camera mainCamera;
	public GameObject GUI_ingame; //added by Daan 13-10-2014

	private float buttonX;
	private float buttonY;
	private float buttonW;
	private float buttonH;
	private const string gameSeekName = "Zatacka 3D DEMO";
	private bool refreshing;
	private HostData[] hostData;

	void Start () {
		buttonX = Screen.width * 0.05f;
		buttonY = Screen.width * 0.05f;
		buttonW = Screen.width * 0.1f;
		buttonH = Screen.width * 0.1f;
	}

	void startServer(){
		Network.InitializeServer (4, 250001, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameSeekName, "Zatacka 3D DEMO Game", "A simple networking demo for Zatacka 3D");
	}

	void OnServerInitialized(){
		spawnPlayer();
	}

	void OnConnectedToServer(){
		spawnPlayer();
	}

	void refreshHostList(){
		MasterServer.RequestHostList (gameSeekName);
		refreshing = true;
	}

	void Update() {
		if (refreshing) {
			if(MasterServer.PollHostList().Length > 0){
				refreshing = false;
				hostData = MasterServer.PollHostList();
			}
		}

	}

	void OnGUI(){
		if (!Network.isClient && !Network.isServer) {
			if (GUI.Button (new Rect (buttonX, buttonY, buttonW, buttonH), "Start Server")) {
				startServer ();
			}
			if (GUI.Button (new Rect (buttonX, buttonY * 1.2f + buttonH, buttonW, buttonH), "Refresh Server")) {
				refreshHostList ();
			}
			if (hostData != null) {
				for (int i = 0; i < hostData.Length; i++) {
					if (GUI.Button (new Rect (buttonX * 1.5f + buttonW, buttonY * 1.2f + (buttonH * i), buttonW * 3, buttonH * 0.5f), hostData [i].gameName)) {
						Network.Connect (hostData [i]);
					}
				}
			}
		}
	}

	void spawnPlayer(){
		GameObject go = (GameObject) Network.Instantiate(playerPrefab, spawnObject.position, Quaternion.identity, 0);
		CameraController controller = mainCamera.GetComponent<CameraController> ();
		Player_Physics_Controller phys = go.transform.GetChild(1).GetComponent<Player_Physics_Controller> ();
		controller.associate(go.transform.GetChild(1).transform.GetChild(0).gameObject, phys);
		// we also have to activate the GUI system (edit by Daan 13-10-2014)
		GUI_ingame.SetActive (true);

	}

}
