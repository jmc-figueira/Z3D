using UnityEngine;
using System.Collections;

public class Referee : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;

	private int player1Score;
	private int player2Score;
	private bool initialized1;
	private bool initialized2;

	// Use this for initialization
	void Start () {
		initialized1 = false;
		initialized2 = false;
		player1Score = 0;
		player2Score = 0;
	}

	void checkIfDead(int playerNum){
		if(player1.GetComponent<PlayerController>().isDead())
			player2Score++;
		else if(player2.GetComponent<PlayerController>().isDead())
			player1Score++;
	}

	void FixedUpdate () {
		if(initialized1)
			checkIfDead(1);
		if(initialized2)
			checkIfDead(2);
	}

	public int getCurrentScore(int playernum){
		switch(playernum){
		case 1:
			return player1Score;
		case 2:
			return player2Score;
		default:
			return 0;
		}
	}

	public void addPlayerToTrack(int playernum, GameObject player){
		switch(playernum){
			case 1:
				player1 = player;
				initialized1 = true;
				break;
			case 2:
				player2 = player;
				initialized2 = true;
				break;
		}
	}
}
