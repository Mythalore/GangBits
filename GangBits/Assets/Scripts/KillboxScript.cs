using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class KillboxScript : MonoBehaviour
{

    public GameObject playerManagerObject;
    public PlayerManagement playerManager;
    int playerCountReset;
    private float time = 0.0f;
    private float displayWinnerTime = 2f;

    private bool isWinnerP1 = false;
    private bool isWinnerP2 = false;
    private bool isWinnerP3 = false;
    private bool isWinnerP4 = false;
    public Canvas winnerCanvas;
    // Use this for initialization
    void Start()
    {

        playerManagerObject = GameObject.FindGameObjectWithTag("PlayerManager");
        if (playerManagerObject == null)
        {
            Debug.Log("No playermanager");
        }
        playerManager = playerManagerObject.GetComponent<PlayerManagement>();
        playerCountReset = playerManager.playerCount;
        if (playerManager.player1 == true)
        {
            isWinnerP1 = true;
        }
        if (playerManager.player2 == true)
        {
            isWinnerP2 = true;
        }
        if (playerManager.player3 == true)
        {
            isWinnerP3 = true;
        }
        if (playerManager.player4 == true)
        {
            isWinnerP4 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.playerCount <= 1)
        {
            time += Time.deltaTime;
            if (time >= displayWinnerTime)
            {
                time = 0.0f;
                sceneChange();
            }
        }
        print("P1:" + playerManager.player1Lives);
        print("P2:" + playerManager.player2Lives);
        print("P3:" + playerManager.player3Lives);
        print("P4:" + playerManager.player4Lives);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log("Killbox Hit");

        if (collider.tag == "Player1")
        {
            playerManager.player1Lives--;
            playerManager.playerCount--;
            Destroy(collider.gameObject);
            isWinnerP1 = false;
            if (playerManager.player1Lives == 0)
            {
                playerManager.player1 = false;
                playerCountReset--;
            }
        }
        if (collider.tag == "Player2")
        {
            playerManager.player2Lives--;
            playerManager.playerCount--;
            Destroy(collider.gameObject);
            isWinnerP2 = false;
            if (playerManager.player2Lives == 0)
            {
                playerManager.player2 = false;
                playerCountReset--;
            }
        }
        if (collider.tag == "Player3")
        {
            playerManager.player3Lives--;
            playerManager.playerCount--;
            Destroy(collider.gameObject);
            isWinnerP3 = false;
            if (playerManager.player3Lives == 0)
            {
                playerManager.player3 = false;
                playerCountReset--;
            }
        }
        if (collider.tag == "Player4")
        {
            playerManager.player4Lives--;
            playerManager.playerCount--;
            Destroy(collider.gameObject);
            isWinnerP4 = false;
            if (playerManager.player4Lives == 0)
            {
                playerManager.player4 = false;
                playerCountReset--;
            }
        }
        

        if (playerManager.playerCount <= 1)
        {
            printWinner(findWinner());
        }




        if (playerCountReset == 1)
        {
            isWinnerP1 = true;
            isWinnerP2 = true;
            isWinnerP3 = true;
            isWinnerP4 = true;
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
    void printWinner(int winningPlayer)
    {
        winnerCanvas.GetComponentInChildren<Text>().text = winningPlayer + "Is the Winner!";
    }
    int findWinner()
    {
        int winner = 0;
        if (isWinnerP1 == true)
        {
            winner = 1;
        }
        else if (isWinnerP2 == true)
        {
            winner = 2;
        }
        else if (isWinnerP3 == true)
        {
            winner = 3;
        }
        else if (isWinnerP4 == true)
        {
            winner = 4;
        }
        return winner;
    }
    void sceneChange()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Sam_TruckLevel")
        {
            SceneManager.LoadScene(3);
        }
        else if (scene.name == "Sam_TrainLevel")
        {
            SceneManager.LoadScene(2);
        }
        playerManager.playerCount = playerCountReset;
    }
}
