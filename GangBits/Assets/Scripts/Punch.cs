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
   // private Transform LeftrightHandStore;
    //private Transform LeftleftHandStore;
    private Vector3 LeftLeftHandvec;
    private Vector3 LeftRightHandvec;
    //-     -       -       -       -
    //Outside Function
    private Direction directionFunc;
    // Use this for initialization
    void Start () {
        directionFunc = GetComponent<Direction>();
        RightrightHandStore = rightHand.transform;
        RightleftHandStore = leftHand.transform;
        rightLeftHandvec = new Vector3(RightleftHandStore.localPosition.x, RightleftHandStore.localPosition.y, RightleftHandStore.localPosition.z);
        rightRightHandvec = new Vector3(RightrightHandStore.localPosition.x, RightrightHandStore.localPosition.y, RightrightHandStore.localPosition.z);

        LeftLeftHandvec = new Vector3(-RightleftHandStore.localPosition.x, RightleftHandStore.localPosition.y, RightleftHandStore.localPosition.z);
        LeftRightHandvec = new Vector3(-RightrightHandStore.localPosition.x, RightrightHandStore.localPosition.y, RightrightHandStore.localPosition.z);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0) && directionFunc.FacingLeft == false) //Right Facing
        {
            rightHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 3.0f, 0.8f), rightHand.transform.localPosition.y, rightHand.transform.localPosition.z);
            leftHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 2.5f, 0.8f), leftHand.transform.localPosition.y, leftHand.transform.localPosition.z);
        }
        else if (Input.GetMouseButton(0) && directionFunc.FacingLeft == true) //Left Facing
        {
            rightHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 3.0f, -0.8f), rightHand.transform.localPosition.y, rightHand.transform.localPosition.z);
            leftHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 2.5f, -0.8f), leftHand.transform.localPosition.y, leftHand.transform.localPosition.z);
        }
        else if (Input.GetMouseButtonUp(0) && directionFunc.FacingLeft == false) //Right Facing
        {
            rightHand.transform.localPosition = rightRightHandvec;
            leftHand.transform.localPosition = rightLeftHandvec;
        }
        else if (Input.GetMouseButtonUp(0) && directionFunc.FacingLeft == true) //Left Facing
        {
            rightHand.transform.localPosition = LeftRightHandvec;
            leftHand.transform.localPosition = LeftLeftHandvec;

            //Have Position Reset that considers position
        }
    }
}
