using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SCORECONTROL : MonoBehaviour {

	public Text scoreText1;
	public int score1;

	public Text scoreText2;
	public int score2;

	public Text scoreText3;
	public int score3;

	public Text scoreText4;
	public int score4;

	private int[] Player_alive = new int[4];
	private int[] score = new int[4];

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject); //This causes the score to existno matter the level load option
		UpdateScore(1);
		UpdateScore(2);
		UpdateScore(3);
		UpdateScore(4);
	}

	void GameStart(){
		score = new int[]{0,0,0,0};
		Player_alive = new int[]{1,1,1,1};
	}

	void LevelStart(){
		Player_alive = new int[]{1,1,1,1};
	}

	/*public void PlayerDied(int Number){
		Player_alive[Number]=0;
		for(int i=0; i<4; i++){
			if(Player_alive[i]==1){
				if(i!=Number){
					score[i]++;
					UpdateScore(i);
				}
			}
		}
	}*/

	public void SetScore1 (int newScoreValue) {
		score1 = newScoreValue;
		UpdateScore(1);
	}
	public void SetScore2 (int newScoreValue) {
		score2 = newScoreValue;
		UpdateScore(2);
	}
	public void SetScore3 (int newScoreValue) {
		score3 = newScoreValue;
		UpdateScore(3);
	}
	public void SetScore4 (int newScoreValue) {
		score4 = newScoreValue;
		UpdateScore(4);
	}

	void UpdateScore(int Number) {
		if(Number==1)
			scoreText1.text = "Player1: " + score1;
		else if(Number==2)
			scoreText2.text = "Player2: " + score2;
		else if(Number==3)
			scoreText3.text = "Player3: " + score3;
		else if(Number==4)
			scoreText4.text = "Player4: " + score4;
		else 
			Debug.Log("Massive error on score");
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info){
		string sc1, sc2, sc3, sc4;
		if(stream.isWriting){
			sc1 = scoreText1;
			sc2 = scoreText2;
			sc3 = scoreText3;
			sc4 = scoreText4;
			stream.Serialize(ref sc1);
			stream.Serialize(ref sc2);
			stream.Serialize(ref sc3);
			stream.Serialize(ref sc4);
		}
	}
	
}
