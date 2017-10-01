using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRepel : MonoBehaviour {

    public Vector2 repel_force = Vector2.zero;
    public float force_magnitude = 30.0f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //if(col.gameObject.tag == "Player")
       // {
            Debug.Log("Entered");
            repel_force.x = transform.position.x - col.transform.position.x;
           // repel_force.Normalize();
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(-repel_force * force_magnitude, ForceMode2D.Impulse);
       // }   
    }

    void OnCollisionExit2D(Collision2D col)
    {
        repel_force = Vector2.zero;
    }
}


