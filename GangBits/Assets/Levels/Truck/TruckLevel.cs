using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckLevel : MonoBehaviour {

	public Animator sign, trucks;
	public float signTime, initalSignTime;
	public float signCount;
	public bool initialSign = true;

	// Use this for initialization
	void Start () {
		initialSign = true;
	}
	
	// Update is called once per frame
	void Update () {
		signCount += Time.deltaTime;
		if (initialSign) {
			if (signCount >= initalSignTime) {
				sign.SetTrigger ("SIGN!");
				signCount = 0;
				initialSign = false;
			}
		} else {
			if(signCount >= signTime){
				sign.SetTrigger ("SIGN!");
				signCount = 0;
			}
		}
	}
}
