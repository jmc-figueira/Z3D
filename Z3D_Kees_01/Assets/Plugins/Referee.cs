using UnityEngine;
using System.Collections;

public class Referee : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;

	private int player1Score;
	private int player2Score;

	// Use this for initialization
	void Start () {
		player1Score = 0;
		player2Score = 0;
	}

	void checkIfDead(){
		if(player1 != null && player1.GetComponent<PlayerController>().isDead())
			player2Score++;
		else if(player2 != null && player2.GetComponent<PlayerController>().isDead())
			player1Score++;
	}

	void FixedUpdate () {
		checkIfDead();
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
				break;
			case 2:
				player2 = player;
				break;
		}
	}
}
