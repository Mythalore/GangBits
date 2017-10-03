using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockout : MonoBehaviour {
    public int knockoutTolerance = 10;
    public bool knockedOut = false;
    public int timeKnockedOut;
    private Knockout knockOutFunc;
    private float time;
	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (knockedOut == true)
        {
            if (Time.time >= time + 5f)
            {
                time = Time.time;
                knockoutTolerance = 3;
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
