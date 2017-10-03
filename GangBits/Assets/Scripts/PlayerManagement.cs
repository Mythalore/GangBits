using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour {

    public static PlayerManagement Instance;

   public bool player1 = false;
    public bool player2 = false;
   public  bool player3 = false;
    public bool player4 = false;
    public GameObject player1Object;
    public GameObject player2Object;
    public GameObject player3Object;
    public GameObject player4Object;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Lobby")
        {
            if(Input.GetButton("P1Confirm"))
            {
                player1 = true;
                Debug.Log("PLayer 1 confirmed");
                
            }
            else if(Input.GetButton("P1Cancel"))
            {
                player1 = false;
                Debug.Log("PLayer 1 cancelled");
            }

            if (Input.GetButton("P2Confirm"))
            {
                player2 = true;
            }
            else if (Input.GetButton("P2Cancel"))
            {
                player2 = false;
            }

            if (Input.GetButton("P3Confirm"))
            {
                player3 = true;
            }
            else if (Input.GetButton("P3Cancel"))
            {
                player3 = false;
            }

            if (Input.GetButton("P4Confirm"))
            {
                player4 = true;
            }
            else if (Input.GetButton("P4Cancel"))
            {
                player4 = false;
            }

        }

        if(Input.GetButton("Tim's Level"))
        {
            SceneManager.LoadScene(2);
        }
		
	}

    void Awake()
    {
        
       if (Instance == null)
       {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            Debug.Log(player1);
        }
       else if (Instance != this)
        {
            Destroy(gameObject);
        }

        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Scene scene1 = SceneManager.GetActiveScene();
       // if (scene.name != "Lobby")
        //{
            Debug.Log(player1);
            if (player1)
            {
                Instantiate(player1Object);
                player1Object.transform.position = new Vector3(0.5f, 2.0f, 0.0f);
            }

            if (player2)
            {
                Instantiate(player2Object);
                player2Object.transform.position = new Vector3(1.5f, 2.0f, 0.0f);
            }

            if (player3)
            {
                Instantiate(player3Object);
                player3Object.transform.position = new Vector3(2.5f, 2.0f, 0.0f);
            }

            if (player4)
            {
                Instantiate(player4Object);
                player4Object.transform.position = new Vector3(-0.5f, 2.0f, 0.0f);
            }
       // }
    }
}
