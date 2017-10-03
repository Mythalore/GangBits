using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockout : MonoBehaviour {
    public int knockoutTolerance = 10;
    public bool knockedOut = false;
    private Knockout knockOutFunc;
    private Color color;
    private float time;
    private float time2;
	// Use this for initialization
	void Start () {
        time = Time.time;
        color = gameObject.GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (knockedOut == true)
        {
            if (Time.time >= time + 5f)
            { 
                time = Time.time;
                knockoutTolerance = 10;
                knockedOut = false;
                
            }
        }
        else if (knockoutTolerance <= 0)
        {
            knockedOut = true;
        }

	}
   public void Hit(GameObject playerObject, string Player)
    {
         knockOutFunc = playerObject.GetComponent<Knockout>();
        knockOutFunc.reduceTol();
    }
    public void reduceTol()
    {
        knockoutTolerance--;
    }
}
