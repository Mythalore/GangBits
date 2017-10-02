using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckLevel : MonoBehaviour {

	public Animator sign, trucks;
	public float signTime, truckChangeTime;
	public float signCount, truckChangeCount;
	public bool isFrontTruck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		signCount += Time.deltaTime;
		if(signCount >= signTime){
			sign.SetTrigger ("SIGN!");
			signCount = 0;
		}
		truckChangeCount += Time.deltaTime;
		if(truckChangeCount >= truckChangeTime){
			if (isFrontTruck) {
				trucks.SetTrigger ("FrontSwitch");
				isFrontTruck = false;
			} else {
				trucks.SetTrigger ("BackSwitch");
				isFrontTruck = true;
			}
			truckChangeCount = 0;
		}
	}
}
