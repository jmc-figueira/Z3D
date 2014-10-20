using UnityEngine;
using System.Collections;

public class Referee : MonoBehaviour {
	private int player1Score;
	private int player2Score;
	public GameObject scoreGUI;
	public GameObject scoreGUI_prefab;
	public GameObject networkController; 
	public NetworkManager networkManager;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		player1Score = 0;
		player2Score = 0;
		networkController = GameObject.Find("NetworkController");
		networkManager = networkController.GetComponent<NetworkManager>();
	}

	public void playerScoredPoint(int playerNum){
		//GameObject networkController = GameObject.Find("NetworkController");
		//NetworkManager networkManager = networkController.GetComponent<NetworkManager>();
		switch(playerNum){
			case 1:
				player1Score++;
				break;
			case 2:
				player2Score++;
				break;
		}
		networkManager.StartMGame();
	}
	

	
	void FixedUpdate(){
		if(Network.peerType == NetworkPeerType.Server){
			if(player1Score >= 10 || player2Score >=10){
				Application.LoadLevel(0);
				GameObject guiSys = GameObject.FindGameObjectWithTag("GSystem");
				Destroy(guiSys);
				GameObject networkC = GameObject.Find("NetworkController");
				Destroy(networkC);
				Destroy(this);
			}
			else{
				if(scoreGUI == null){
					scoreGUI = (GameObject) Network.Instantiate(scoreGUI_prefab, new Vector3(0,0,0), Quaternion.identity, 0);
					scoreGUI.SetActive(true);
				}
				else{
					//scoreGUI.GetComponent<SCORECONTROL>().SetScore1(player1Score);
					//scoreGUI.GetComponent<SCORECONTROL>().SetScore2(player2Score);
					networkManager.networkView.RPC("UpdateScore", RPCMode.AllBuffered, 2,3);
				}
			}
		}
	}
}
