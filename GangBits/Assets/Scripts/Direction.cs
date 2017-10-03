using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

    public bool FacingLeft;
    private SideArms sideArm;
    private string axis_string = "";

	// Use this for initialization
	void Start () {
        sideArm = GetComponent<SideArms>(); //gets the side the arms should be on
        if (gameObject.tag == "Player1")
        {
            axis_string = "Horizontal1";
        }
        if (gameObject.tag == "Player2")
        {
            axis_string = "Horizontal2";
        }
        if (gameObject.tag == "Player3")
        {
            axis_string = "Horizontal3";
        }
        if (gameObject.tag == "Player4")
        {
            axis_string = "Horizontal4";
        }
    }
	
	// Update is called once per frame
	void Update () {

        float movement = (Input.GetAxis(axis_string)); //needs to be changed for multiple players


        if (movement < 0 && FacingLeft != true) //If movement is going right and wasn't moving right before
        {
            FacingLeft = true; //Changes the state and calls the function to swap the sides
            sideArm.ArmDirection();

        }
        else if (movement > 0 && FacingLeft != false) //Moving left and wasn't moving left before
        {
            FacingLeft = false; //Changes the state and calls the function to swap the sides
            sideArm.ArmDirection();
        }
        
	}
}
