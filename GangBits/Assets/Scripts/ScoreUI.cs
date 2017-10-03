using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum players{
	p1,p2,p3,p4
}

public class ScoreUI : MonoBehaviour {

	public players playerID;
	public PlayerManagement playerManager;

	// Use this for initialization
	void Start () {
		playerManager = GameObject.FindGameObjectWithTag ("PlayerManager").GetComponent<PlayerManagement> ();
		if (playerManager == null)
		{
			Debug.Log("No playermanager");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(playerID == players.p1)
			GetComponent<Text>().text = ""+playerManager.player1Lives;
		if(playerID == players.p2)
			GetComponent<Text>().text = ""+playerManager.player2Lives;
		if(playerID == players.p3)
			GetComponent<Text>().text = ""+playerManager.player3Lives;
		if(playerID == players.p4)
			GetComponent<Text>().text = ""+playerManager.player4Lives;
	}
}
