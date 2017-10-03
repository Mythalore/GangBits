using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideArms : MonoBehaviour {
    private Direction store;
    public GameObject LeftArm;
    public GameObject RightArm;
    private Transform leftArmTran;
    private Transform rightArmTran;
	private string player_name = "";
	// Use this for initialization
	//bool getDir ;

	void Start () {
        

		if (gameObject.tag == "Player1") {
			player_name = "Player1";
            store = gameObject.GetComponent<Direction>(); //Gets the direction the player is facing
            leftArmTran = LeftArm.transform; //Stores the initial values of the arm
            rightArmTran = RightArm.transform; //Stores the initial value of the arms
                                               
        }
		else if (gameObject.tag == "Player2") {
			player_name = "Player2";
            store = gameObject.GetComponent<Direction>(); //Gets the direction the player is facing
            leftArmTran = LeftArm.transform; //Stores the initial values of the arm
            rightArmTran = RightArm.transform; //Stores the initial value of the arms
                                               
        }
		else if (gameObject.tag == "Player3") {
			player_name = "Player3";
            store = gameObject.GetComponent<Direction>(); //Gets the direction the player is facing
            leftArmTran = LeftArm.transform; //Stores the initial values of the arm
            rightArmTran = RightArm.transform; //Stores the initial value of the arms                                              
        }
		else if (gameObject.tag == "Player4") {
			player_name = "Player4";
            store = gameObject.GetComponent<Direction>(); //Gets the direction the player is facing
            leftArmTran = LeftArm.transform; //Stores the initial values of the arm
            rightArmTran = RightArm.transform; //Stores the initial value of the arms                                               
        }

	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ArmDirection() //When called it validates the side the arms should be on and swaps the sides
    {
       // print(getDir);
		if (gameObject.tag == player_name) {

			bool getDir = store.FacingLeft;
            //Debug.Log(player_name + store.FacingLeft);

			if (getDir == true)
			{
				LeftArm.transform.localPosition = new Vector3(-leftArmTran.localPosition.x, leftArmTran.localPosition.y, leftArmTran.localPosition.z);
				RightArm.transform.localPosition = new Vector3(-rightArmTran.localPosition.x, rightArmTran.localPosition.y, rightArmTran.localPosition.z);
			}
			else if (getDir == false)
			{
				LeftArm.transform.localPosition = new Vector3(-leftArmTran.localPosition.x, leftArmTran.localPosition.y, leftArmTran.localPosition.z);
				RightArm.transform.localPosition = new Vector3(-rightArmTran.localPosition.x, rightArmTran.localPosition.y, rightArmTran.localPosition.z);
			}		
		}

    }

}
