using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

    public bool FacingLeft;
    private SideArms sideArm;
	// Use this for initialization
	void Start () {
        sideArm = GetComponent<SideArms>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) && FacingLeft != true)
        {
            FacingLeft = true;
            sideArm.ArmDirection();
        }
        else if (Input.GetKey(KeyCode.D) && FacingLeft != false)
        {
            FacingLeft = false;
            sideArm.ArmDirection();
        }
        
	}
}
