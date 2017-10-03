using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {
    //Right Facing
    public GameObject rightHand;
    public GameObject leftHand;

    public bool isPunching = false;

    private Transform RightrightHandStore;
    private Transform RightleftHandStore;
    private Vector3 rightLeftHandvec;
    private Vector3 rightRightHandvec;
    //-     -       -       -       -
    //Left Facing
    private Vector3 LeftLeftHandvec;
    private Vector3 LeftRightHandvec;
    //-     -       -       -       -
    //Outside Function
    private Direction directionFunc;

    private Knockout knockOutFunc;
    private bool knockOutRef;

    private string player_name = "";
	private string punch_button = "";
    // Use this for initialization
    void Start () {

        directionFunc = GetComponent<Direction>(); // Gets the direction the player is facing
        knockOutFunc = GetComponent<Knockout>();
        

        RightrightHandStore = rightHand.transform; //Stores the inital values of the hands to move them to resetted positions
        RightleftHandStore = leftHand.transform; // ^
        rightLeftHandvec = new Vector3(RightleftHandStore.localPosition.x, RightleftHandStore.localPosition.y, RightleftHandStore.localPosition.z); //Location of left hand when facing right
        rightRightHandvec = new Vector3(RightrightHandStore.localPosition.x, RightrightHandStore.localPosition.y, RightrightHandStore.localPosition.z); //Location of right hand when facing right

        LeftLeftHandvec = new Vector3(-RightleftHandStore.localPosition.x, RightleftHandStore.localPosition.y, RightleftHandStore.localPosition.z); //Location of left hand when facing left
        LeftRightHandvec = new Vector3(-RightrightHandStore.localPosition.x, RightrightHandStore.localPosition.y, RightrightHandStore.localPosition.z); //Location of right hand when facing left

		if (gameObject.tag == "Player1") {
			player_name = "Player1";
			punch_button = "joystick 1 button 2";
		}
		if (gameObject.tag == "Player2") {
			player_name = "Player2";
			punch_button = "joystick 2 button 2";
		}
		if (gameObject.tag == "Player3") {
			player_name = "Player3";
			punch_button = "joystick 3 button 2";
		}
		if (gameObject.tag == "Player4") {
			player_name = "Player4";
			punch_button = "joystick 4 button 2";
		}

    }

    // Update is called once per frame
    void Update ()
    { //Joystick button 0 is the A button on the controller
        knockOutRef = knockOutFunc.knockedOut;
        if (gameObject.tag == player_name && knockOutRef == false)
        {
            if (Input.GetKey(punch_button) && directionFunc.FacingLeft == false) //Right Facing Punch Animation
            {
                isPunching = true;
                rightHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 3.0f, 0.8f), rightHand.transform.localPosition.y, rightHand.transform.localPosition.z);
                leftHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 2.5f, 0.8f), leftHand.transform.localPosition.y, leftHand.transform.localPosition.z);
            }
            else if (Input.GetKey(punch_button) && directionFunc.FacingLeft == true) //Left Facing Punch Animation
            {
                isPunching = true;
                rightHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 3.0f, -0.5f), rightHand.transform.localPosition.y, rightHand.transform.localPosition.z);
                leftHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 2.5f, -0.5f), leftHand.transform.localPosition.y, leftHand.transform.localPosition.z);
            }
            else if (Input.GetKeyUp(punch_button) && directionFunc.FacingLeft == false) //Right Facing Position reset
            {
                isPunching = false;
                rightHand.transform.localPosition = rightRightHandvec;
                leftHand.transform.localPosition = rightLeftHandvec;
            }
            else if (Input.GetKeyUp(punch_button) && directionFunc.FacingLeft == true) //Left Facing Position reset
            {
                isPunching = false;
                rightHand.transform.localPosition = LeftRightHandvec;
                leftHand.transform.localPosition = LeftLeftHandvec;
            }
        }
    }

  
}
