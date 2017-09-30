using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {
    public GameObject rightHand;
    public GameObject leftHand;
    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0))
        {
                rightHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 3.0f, 0.8f), rightHand.transform.localPosition.y, rightHand.transform.localPosition.z);
                leftHand.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 2.5f, 0.8f), leftHand.transform.localPosition.y, leftHand.transform.localPosition.z);
        }
        else
        {
            //Have Position Reset that considers position
        }
    }
}
