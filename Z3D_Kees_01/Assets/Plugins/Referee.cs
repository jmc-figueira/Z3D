using UnityEngine;
using System.Collections;

public class Referee : MonoBehaviour {
	private int player1Score;
	private int player2Score;
	private GameObject scoreGUI;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		player1Score = 0;
		player2Score = 0;
	}

	public void playerScoredPoint(int playerNum){
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
		networkManager.StartMGame();
	}
	
	void FixedUpdate(){
		if(scoreGUI == null)
			scoreGUI = GameObject.FindGameObjectWithTag("GSystem");
		else{
			scoreGUI.GetComponent<SCORECONTROL>().SetScore1(player1Score);
			scoreGUI.GetComponent<SCORECONTROL>().SetScore2(player2Score);
		}
	}

}
