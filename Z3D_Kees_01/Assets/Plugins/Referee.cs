using UnityEngine;
using System.Collections;

public class Referee : MonoBehaviour {
	private int player1Score;
	private int player2Score;
	public GameObject scoreGUI;
	public GameObject scoreGUI_prefab;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		player1Score = 0;
		player2Score = 0;
	}

	public void playerScoredPoint(int playerNum){
		Debug.Log ("Player " + playerNum + " scored a point!");
		GameObject networkController = GameObject.Find ("NetworkController");
		NetworkManager networkManager = networkController.GetComponent<NetworkManager>();
		switch(playerNum){
			case 1:
				player1Score++;
				break;
			case 2:
				player2Score++;
				break;
		}
		Debug.Log ("Player 1's score: " + player1Score);
		Debug.Log ("Player 2's score: " + player2Score);
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
					Debug.Log ("Instantiating");
					scoreGUI = (GameObject) Network.Instantiate(scoreGUI_prefab, new Vector3(0,0,0), Quaternion.identity, 0);
					scoreGUI.SetActive(true);
				}
				else{
					scoreGUI.GetComponent<SCORECONTROL>().SetScore1(player1Score);
					scoreGUI.GetComponent<SCORECONTROL>().SetScore2(player2Score);
				}
			}
		}
	}
}
