using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideArms : MonoBehaviour {
    private Direction store;
	// Use this for initialization
	void Start () {
        store = GetComponent<Direction>();
	}
	
	// Update is called once per frame
	void Update () {
        bool getDir = store.FacingLeft;
        if (getDir == true)
        {

        }
        else if (getDir == false)
        {

        }
	}
}
