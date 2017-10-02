using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {
    //Right Facing
    public GameObject rightHand;
    public GameObject leftHand;
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
    // Use this for initialization
    void Start () {
        directionFunc = GetComponent<Direction>(); // Gets the direction the player is facing

        RightrightHandStore = rightHand.transform; //Stores the inital values of the hands to move them to resetted positions
        RightleftHandStore = leftHand.transform; // ^
        rightLeftHandvec = new Vector3(RightleftHandStore.localPosition.x, RightleftHandStore.localPosition.y, RightleftHandStore.localPosition.z); //Location of left hand when facing right
        rightRightHandvec = new Vector3(RightrightHandStore.localPosition.x, RightrightHandStore.localPosition.y, RightrightHandStore.localPosition.z); //Location of right hand when facing right

        LeftLeftHandvec = new Vector3(-RightleftHandStore.localPosition.x, RightleftHandStore.localPosition.y, RightleftHandStore.localPosition.z); //Location of left hand when facing left
        LeftRightHandvec = new Vector3(-RightrightHandStore.localPosition.x, RightrightHandStore.localPosition.y, RightrightHandStore.localPosition.z); //Location of right hand when facing left
    }

    // Update is called once per frame
    void Update () { //Joystick button 0 is the A button on the controller
        if (Input.GetKey("joystick button 0") && directionFunc.FacingLeft == false) //Right Facing Punch Animation
        {
            rightHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 3.0f, 0.8f), rightHand.transform.localPosition.y, rightHand.transform.localPosition.z);
            leftHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 2.5f, 0.8f), leftHand.transform.localPosition.y, leftHand.transform.localPosition.z);
        }
        else if (Input.GetKey("joystick button 0") && directionFunc.FacingLeft == true) //Left Facing Punch Animation
        {
            rightHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 3.0f, -0.8f), rightHand.transform.localPosition.y, rightHand.transform.localPosition.z);
            leftHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 2.5f, -0.8f), leftHand.transform.localPosition.y, leftHand.transform.localPosition.z);
        }
        else if (Input.GetKeyUp("joystick button 0") && directionFunc.FacingLeft == false) //Right Facing Position reset
        {
            rightHand.transform.localPosition = rightRightHandvec;
            leftHand.transform.localPosition = rightLeftHandvec;
        }
        else if (Input.GetKeyUp("joystick button 0") && directionFunc.FacingLeft == true) //Left Facing Position reset
        {
            rightHand.transform.localPosition = LeftRightHandvec;
            leftHand.transform.localPosition = LeftLeftHandvec;

        }
    }
}
