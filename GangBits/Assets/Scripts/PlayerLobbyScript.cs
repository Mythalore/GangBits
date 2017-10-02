using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobbyScript : MonoBehaviour {

    public GameObject playerManagerObject;
    public PlayerManagement playerManager;
    

    // Use this for initialization
    void Start () {

        //playerManagerObject = GameObject.Find("PlayerManager");
        playerManager = playerManagerObject.GetComponent<PlayerManagement>();
        
	}
	
	// Update is called once per frame
	void Update () {


        

        if (this.gameObject.tag == "Player1")
        {
            if (playerManager.player1 == true)
            {
               gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else if(this.gameObject.tag == "Player2")
        {

        }
        else if (this.gameObject.tag == "Player3")
        {

        }
        else if (this.gameObject.tag == "Player4")
        {

        }
		
	}
}
