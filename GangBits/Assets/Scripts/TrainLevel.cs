using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainLevel : MonoBehaviour {

	public Animator train;
	public float trainTime, trainCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		trainCount += Time.deltaTime;
		if(trainCount >= trainTime){
			train.SetTrigger ("TRAIN!");
			trainCount = 0;
		}
	}
}
