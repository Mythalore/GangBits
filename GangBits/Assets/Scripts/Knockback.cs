using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    private string self_name = "";
    private string player_hit = "";

    private Vector3 punch_vector = Vector2.zero;
    private Direction directionFunc;
    private GameObject parent;
    private Knockout knockOutFunc;

    private Punch punchFunc;
    private bool isPunchingRef;
    public float punch_force = 10.0f;
	public AudioSource punch;
	
	void playPunchSound()
	{

		punch.Play ();
	}

    // Use this for initialization
	void Start () {
        //parent = GetComponentInParent<Rigidbody2D>();
        directionFunc = GetComponentInParent<Direction>();
        knockOutFunc = GetComponentInParent<Knockout>();
        punchFunc = GetComponentInParent<Punch>();
        if (gameObject.tag == "Player1")
        {
            self_name = "Player1";
        }
        if (gameObject.tag == "Player2")
        {
            self_name = "Player2";
        }
        if (gameObject.tag == "Player3")
        {
            self_name = "Player3";
        }
        if (gameObject.tag == "Player4")
        {
            self_name = "Player4";
        }
    }
	
	// Update is called once per frame
	void Update () {
        isPunchingRef = punchFunc.isPunching;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //set the direction of force dependent on player's current direction
        if(directionFunc.FacingLeft)
        {
            punch_vector.x = -punch_force;
        }
        else
        {
            punch_vector.x = punch_force;
        }

        if (col.gameObject.tag == "Player1" && col.gameObject.tag != self_name)
        {
            if (isPunchingRef == true)
            {

                //Debug.Log(self_name + "hit P1");
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(punch_vector, ForceMode2D.Impulse);
                playPunchSound();
                knockOutFunc.Hit(col.gameObject, "Player1");

            }

        }
        if (col.gameObject.tag == "Player2" && col.gameObject.tag != self_name)
        {
            print(isPunchingRef);
            if (isPunchingRef == true)
            {
                //Debug.Log(self_name + "hit P2");
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(punch_vector, ForceMode2D.Impulse);
                playPunchSound();
                knockOutFunc.Hit(col.gameObject, "Player2");
            }
        }
        if (col.gameObject.tag == "Player3" && col.gameObject.tag != self_name)
        {
            print(isPunchingRef);
            if (isPunchingRef == true)
            {
                //Debug.Log(self_name + "hit P3");
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(punch_vector, ForceMode2D.Impulse);
                playPunchSound();
                knockOutFunc.Hit(col.gameObject, "Player3");
            }
        }
        if (col.gameObject.tag == "Player4" && col.gameObject.tag != self_name)
        {
            print(isPunchingRef);
            if (isPunchingRef == true)
            {
                //Debug.Log(self_name + "hit P4");
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(punch_vector, ForceMode2D.Impulse);
                playPunchSound();
                knockOutFunc.Hit(col.gameObject, "Player4");
            }
        }
    }
}
