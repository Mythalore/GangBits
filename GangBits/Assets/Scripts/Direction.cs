using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

    public bool FacingLeft;
    private SideArms sideArm;
	// Use this for initialization
	void Start () {
        sideArm = GetComponent<SideArms>(); //gets the side the arms should be on
	}
	
	// Update is called once per frame
	void Update () {
        float movement = (Input.GetAxis("Horizontal1")); //needs to be changed for multiple players
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
