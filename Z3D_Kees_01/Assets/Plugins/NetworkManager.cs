using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public GameObject playerPrefab1;
	public GameObject playerPrefab2;
	public GameObject refereePrefab;
	private GameObject playerPrefab;
	public GameObject GUI_ingame; //added by Daan 13-10-2014
	public int maxPlayers;
	private GameObject referee;
	//private GameObject scoreCounter;

	private float buttonX;
	private float buttonY;
	private float buttonW;
	private float buttonH;
	private const string gameSeekName = "Zatacka 3D DEMO";
	private bool refreshing;
	public HostData[] hostData;
	private int currentPlayer;
	private bool levelloaded;

	private GameObject spawnpoint;
	
	public string username = "";
	bool RegisterUI = false;
	bool LoginUI = false;
	
	
	public void Start () {
		DontDestroyOnLoad(this);
		buttonX = Screen.width * 0.05f;
		buttonY = Screen.width * 0.05f;
		buttonW = Screen.width * 0.1f;
		buttonH = Screen.width * 0.02f;
		currentPlayer = 0;
		levelloaded = false;
	}

	public void startServer(){
		Network.InitializeServer (maxPlayers, 250001, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameSeekName, "Zatacka 3D DEMO Game", "A simple networking demo for Zatacka 3D");
	}
	
	 void OnLevelWasLoaded(int level) {
	 	if (level == 1){
			levelloaded = true;
			if(Network.peerType == NetworkPeerType.Server && networkView.isMine){
				if(referee == null){
					referee = (GameObject) Network.Instantiate(refereePrefab,new Vector3(0,0,0), Quaternion.identity, 0);
					referee.SetActive(true);
				}
			}
			spawnPlayer();
	 	}
    }

	public void OnServerInitialized(){
	}

	public void OnConnectedToServer(){
		if(currentPlayer >= maxPlayers)
			Debug.Log("Maximum player count exceeded");
		else{
		}
	}

	public void refreshHostList(){
		MasterServer.RequestHostList (gameSeekName);
		refreshing = true;
	}

	public void Update(){
		if (refreshing) {
			if(MasterServer.PollHostList().Length > 0){
				refreshing = false;
				hostData = MasterServer.PollHostList();
			}
		}
	}

	public void OnGUI(){
		if(Network.peerType == NetworkPeerType.Server)
			{
				GUI.Label(new Rect(Screen.width-100,5,100,25),"Server");
				GUI.Label(new Rect(Screen.width-100,30,100,25),"Connections: " + Network.connections.Length);
				
				/*if(GUI.Button(new Rect(100,150,100,25),"Logout"))
				{
					Network.Disconnect(250);	
				}*/
			}
			if(Network.peerType == NetworkPeerType.Client){
				GUI.Label(new Rect(Screen.width-100,5,100,25),"Client");
			}
		if(Network.peerType == NetworkPeerType.Disconnected){
			/*if (GUI.Button (new Rect (buttonX, buttonY, buttonW, buttonH), "Start Server")) {
				startServer ();
			}
			if (GUI.Button (new Rect (buttonX, buttonY * 1.2f + buttonH, buttonW, buttonH), "Refresh Server")) {
				refreshHostList ();
			}*/
			
			/*if (hostData != null) {
				for (int i = 0; i < hostData.Length; i++) {
					if (GUI.Button (new Rect (buttonX * 1.5f + buttonW, buttonY * 1.2f + (buttonH * i), buttonW * 3, buttonH * 1f), hostData [i].gameName)) {
						Network.Connect (hostData [i]);
					}
				}
			}*/
		}
	}
	[RPC]
	public void ProcessPlayerDied(int playernumber){
		if(Network.peerType == NetworkPeerType.Server){
			referee.GetComponent<Referee>().playerScoredPoint(playernumber);
		}
	}


	public void PlayerDied(int playernum){
		if(playernum == 1 && Network.peerType == NetworkPeerType.Server){
			networkView.RPC("ProcessPlayerDied", RPCMode.AllBuffered, 2);
		}
		else if(playernum == 2 && Network.peerType == NetworkPeerType.Client){
			networkView.RPC("ProcessPlayerDied", RPCMode.AllBuffered, 1);
		}
	}
	
	public void StartMGame(){
		networkView.RPC( "LoadLevel", RPCMode.AllBuffered,1);
	}

	[RPC]
		public void LoadLevel(int number){
			Application.LoadLevel(number);
		}


	public void spawnPlayer(){
		int playerNum;
		if(Network.peerType == NetworkPeerType.Server){
			spawnpoint = GameObject.Find("SpawnPoint_1");
			playerPrefab = playerPrefab1;
			playerNum = 1;
		}
		else{
			spawnpoint = GameObject.Find("SpawnPoint_2");
			playerPrefab = playerPrefab2;
			playerNum = 2;
		}
		GameObject go = (GameObject) Network.Instantiate(playerPrefab, spawnpoint.transform.position, spawnpoint.transform.rotation, 0);
		CameraController controller = Camera.main.GetComponent<CameraController> ();
		Player_Physics_Controller phys = go.transform.GetChild(1).GetComponent<Player_Physics_Controller> ();
		controller.associate(go.transform.GetChild(1).transform.GetChild(0).gameObject, phys);
		// we also have to activate the GUI system (edit by Daan 13-10-2014)
		GUI_ingame.SetActive (true);
	}

}
