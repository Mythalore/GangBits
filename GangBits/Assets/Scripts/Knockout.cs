using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockout : MonoBehaviour {
    public int knockoutTolerance = 10;
    public bool knockedOut = false;
    private Knockout knockOutFunc;
    private Color color;
    private float time = 0.0f;
    private float knockedDownLength = 3f;
	// Use this for initialization
	void Start () {
        color = gameObject.GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (knockedOut == true)
        {
            time += Time.deltaTime;
            if (time >= knockedDownLength)
            { 
                time = 0.0f;
                knockoutTolerance = 10;
                knockedOut = false;
                if (transform.rotation.z != 0)
                {
                    Quaternion target = Quaternion.Euler(new Vector3(0, 0, 0));
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 100f);
                }
            }
        }
        else if (knockoutTolerance <= 0)
        {
            knockedOut = true;
            Quaternion target = Quaternion.Euler(new Vector3(0, 0, 90));
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 100f);
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
