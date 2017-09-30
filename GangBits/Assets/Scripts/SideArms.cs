using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideArms : MonoBehaviour {
    private Direction store;
    public GameObject LeftArm;
    public GameObject RightArm;
    private Transform leftArmTran;
    private Transform rightArmTran;
	// Use this for initialization
	void Start () {
        store = GetComponent<Direction>();
        leftArmTran = LeftArm.transform;
        rightArmTran = RightArm.transform;
	}
	
	// Update is called once per frame
	void Update () {
        //transform = gameObject.transform;
	}

    public void ArmDirection()
    {
        bool getDir = store.FacingLeft;
        print(getDir);
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
