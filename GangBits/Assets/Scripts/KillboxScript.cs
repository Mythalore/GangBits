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
        playerManager = playerManagerObject.GetComponent<PlayerManagement>();
        playerCountReset = playerManager.playerCount;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log("Killbox Hit");
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
    }
}
