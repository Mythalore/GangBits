using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KillboxScript : MonoBehaviour {

    public GameObject playerManagerObject;
    public PlayerManagement playerManager;
    int playerCountReset;
    
	// Use this for initialization
	void Start () {

        playerManagerObject = GameObject.FindGameObjectWithTag("PlayerManager");
        if(playerManagerObject == null)
        {
            Debug.Log("No playermanager");
        }
        playerManager = playerManagerObject.GetComponent<PlayerManagement>();
        playerCountReset = playerManager.playerCount;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log("Killbox Hit");

        if (collider.tag == "Player1")
        {
            playerManager.player1Lives--;
            if (playerManager.player1Lives == 0)
            {
                playerManager.player1 = false;
                playerCountReset--;
            }
        }
        else if(collider.tag == "Player2")
        {
            playerManager.player2Lives--;
            if (playerManager.player2Lives == 0)
            {
                playerManager.player2 = false;
                playerCountReset--;
            }
        }
        else if(collider.tag == "Player3")
        {
            playerManager.player3Lives--;
            if (playerManager.player3Lives == 0)
            {
                playerManager.player3 = false;
                playerCountReset--;
            }
        }
        else if(collider.tag == "Player4")
        {
            playerManager.player4Lives--;
            if(playerManager.player4Lives == 0)
            {
                playerManager.player4 = false;
                playerCountReset--;
            }
        }
        playerManager.playerCount--;

        if (playerManager.playerCount <= 1)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Sam_TruckLevel")
            {
                SceneManager.LoadScene(3);
            }
            else if(scene.name == "Sam_TrainLevel")
            {
                SceneManager.LoadScene(2);
            }
                playerManager.playerCount = playerCountReset;
        }

        

        Destroy(collider);

        if(playerCountReset == 1)
        {
            Debug.Log("Player 1 wins!");
            playerManager.player1 = false;
            playerManager.player2 = false;
            playerManager.player3 = false;
            playerManager.player4 = false;
            playerManager.player1Lives = 3;
            playerManager.player2Lives = 3;
            playerManager.player3Lives = 3;
            playerManager.player4Lives = 3;
            playerManager.playerCount = 0;
            SceneManager.LoadScene(1);
        }
    }
}
