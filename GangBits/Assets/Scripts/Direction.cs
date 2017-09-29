using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

    public bool FacingLeft;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            FacingLeft = true;
            print(FacingLeft);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            FacingLeft = false;
            print(FacingLeft);
        }
        
	}
}
