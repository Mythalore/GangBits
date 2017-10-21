using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {
    //Right Facing
    public GameObject rightHand;
    public GameObject leftHand;

    public bool isLeftPunching = false;
	public bool isRightPunching = false;
	public float punch_distance = 6.0f;
	public float punch_time = 8.0f;
	Vector2 target_pos;



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
	private string punchL = "";
	private string punchR = "";
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
			punchL = "P1PunchL";
			punchR = "P1PunchR";
		}
		if (gameObject.tag == "Player2") {
			player_name = "Player2";
			punchL = "P2PunchL";
			punchR = "P2PunchR";
		}
		if (gameObject.tag == "Player3") {
			player_name = "Player3";
			punchL = "P3PunchL";
			punchR = "P3PunchR";
		}
		if (gameObject.tag == "Player4") {
			player_name = "Player4";
			punchL = "P4PunchL";
			punchR = "P4PunchR";
		}

    }

    // Update is called once per frame
    void FixedUpdate ()
	{ //Joystick button 0 is the A button on the controller
		knockOutRef = knockOutFunc.knockedOut;
		if (gameObject.tag == player_name && knockOutRef == false) {

			leftPunch ();
			rightPunch ();

			if (Input.GetButtonDown (punchL)) { //Right Facing Punch Animation
				isLeftPunching = true;
			}

			if (Input.GetButtonDown (punchR)) {
				isRightPunching = true;
			}

	

			if (isLeftPunching == false) {
				leftHand.transform.localPosition = Vector2.Lerp (leftHand.transform.localPosition, transform.localPosition, (punch_time * 1.3f) * Time.deltaTime);

			}
				
			if (isRightPunching == false) {
				rightHand.transform.localPosition = Vector2.Lerp (rightHand.transform.localPosition, transform.localPosition, (punch_time * 1.3f) * Time.deltaTime);
			}
		}
	}

	void leftPunch()
	{
		target_pos = new Vector2(leftHand.transform.localPosition.x + punch_distance, leftHand.transform.localPosition.y);

		if (directionFunc.FacingLeft == false) {
			target_pos = new Vector2(leftHand.transform.localPosition.x + punch_distance, leftHand.transform.localPosition.y);
			if (target_pos.x <= 10.0f) {
				//punch done
				if (isLeftPunching == true) {
					leftHand.transform.localPosition = Vector2.Lerp (leftHand.transform.localPosition, target_pos, punch_time * Time.deltaTime);
				}
				
			} else {
				isLeftPunching = false;
			}
		} else if (directionFunc.FacingLeft == true) { //Left Facing Punch Animation
			target_pos = new Vector2(leftHand.transform.localPosition.x - punch_distance, leftHand.transform.localPosition.y);
			if (target_pos.x >= -10.0f) {
				//punch done
				if (isLeftPunching == true) {
					leftHand.transform.localPosition = Vector2.Lerp (leftHand.transform.localPosition, target_pos, punch_time * Time.deltaTime);
				}

			} else {
				isLeftPunching = false;
			}

		}
	}


	void rightPunch ()
	{
		target_pos = new Vector2(rightHand.transform.localPosition.x + punch_distance, rightHand.transform.localPosition.y);

		if (directionFunc.FacingLeft == false) {
			target_pos = new Vector2(rightHand.transform.localPosition.x + punch_distance, rightHand.transform.localPosition.y);
			if (target_pos.x <= 10.0f) {
				//punch done
				if (isRightPunching == true) {
					rightHand.transform.localPosition = Vector2.Lerp (rightHand.transform.localPosition, target_pos, punch_time * Time.deltaTime);
				}

			} else {
				isRightPunching = false;
			}
		} else if (directionFunc.FacingLeft == true) { //Left Facing Punch Animation
			target_pos = new Vector2(rightHand.transform.localPosition.x - punch_distance, rightHand.transform.localPosition.y);
			if (target_pos.x >= -10.0f) {
				//punch done
				if (isRightPunching == true) {
					rightHand.transform.localPosition = Vector2.Lerp (rightHand.transform.localPosition, target_pos, punch_time * Time.deltaTime);
				}

			} else {
				isRightPunching = false;
			}

		}


	}
  
}
