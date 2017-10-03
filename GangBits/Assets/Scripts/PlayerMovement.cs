using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rig;

    public float speed = 1.0f;
    public float max_force = 20f;
    public Vector2 moveDirection = Vector2.zero;
    public float jump_height = 1.0f;
    public float gravity = 50.0f;
    public float jump_force = 50.0f;

    public Vector2 impulse_force = Vector2.zero;

    private bool grounded = false;

    /*.................................................
      IMPULSE BASED X,Y MOVEMENT
      (works much better using gamepad)
      .................................................
    */


    void Start()
    {
        //Initialisations
        rig = GetComponent<Rigidbody2D>();
        rig.mass = 5.0f;
        rig.drag = 5.0f;
        rig.freezeRotation = true;
        rig.gravityScale = 0.0f;
    }


    //Update is called once per frame
    void FixedUpdate()
    {
        if (this.gameObject.tag == "Player1")
        {
   //         moveDirection.x = (Input.GetAxis("Horizontal1"));
			//if(moveDirection.x < 0.1 && moveDirection.x > -0.1 )
   //         {
   //             moveDirection.x = 0;
   //         }
            impulse_force = Vector2.ClampMagnitude((speed * moveDirection * rig.mass), max_force);

            if (grounded)
            {
                if(Input.GetButton("P1 Jump")  )
                {
                    //Debug.Log("P1 Jump");
                    rig.AddForce(new Vector2(0, jump_force * rig.mass));
                }
                
            }
            else
            {
                moveDirection.y = 0;
                rig.AddForce(new Vector2(0, -gravity * rig.mass));
                //Debug.Log("going down");
            }

            rig.AddForce(impulse_force, ForceMode2D.Impulse);
            moveDirection = Vector2.zero;
        }

        //PLAYER 2
        else if (this.gameObject.tag == "Player2")
        {

            moveDirection.x = (Input.GetAxis("Horizontal2"));
            impulse_force = Vector2.ClampMagnitude((speed * moveDirection * rig.mass), max_force);

            if (grounded)
            {
                if (Input.GetButton("P2 Jump"))
                {
                    //Debug.Log("P1 Jump");
                    rig.AddForce(new Vector2(0, jump_force * rig.mass));
                }

            }
            else
            {
                moveDirection.y = 0;
                rig.AddForce(new Vector2(0, -gravity * rig.mass));
                //Debug.Log("going down");
            }

            rig.AddForce(impulse_force, ForceMode2D.Impulse);
            moveDirection = Vector2.zero;
        }

        //PLAYER 3
        else if (this.gameObject.tag == "Player3")
        {

            moveDirection.x = (Input.GetAxis("Horizontal3"));
            impulse_force = Vector2.ClampMagnitude((speed * moveDirection * rig.mass), max_force);

            if (grounded)
            {
                if (Input.GetButton("P3 Jump"))
                {
                    //Debug.Log("P1 Jump");
                    rig.AddForce(new Vector2(0, jump_force * rig.mass));
                }

            }
            else
            {
                moveDirection.y = 0;
                rig.AddForce(new Vector2(0, -gravity * rig.mass));
                //Debug.Log("going down");
            }

            rig.AddForce(impulse_force, ForceMode2D.Impulse);
            moveDirection = Vector2.zero;
			impulse_force = Vector2.zero;
        }

        //PLAYER 4
        else if (this.gameObject.tag == "Player4")
        {

            moveDirection.x = (Input.GetAxis("Horizontal4"));
            impulse_force = Vector2.ClampMagnitude((speed * moveDirection * rig.mass), max_force);

            if (grounded)
            {
                if (Input.GetButton("P4 Jump"))
                {
                    //Debug.Log("P1 Jump");
                    rig.AddForce(new Vector2(0, jump_force * rig.mass));
                }

            }
            else
            {
                moveDirection.y = 0;
                rig.AddForce(new Vector2(0, -gravity * rig.mass));
                //Debug.Log("going down");
            }

            rig.AddForce(impulse_force, ForceMode2D.Impulse);
            moveDirection = Vector2.zero;
        }
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }

    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            transform.parent = col.gameObject.transform;
            Debug.Log("Parented");
        }
    }

    //Not working, but could be?
    //public bool isGrounded()
    //{
    //    return Physics.Raycast(rig.transform.position, -Vector2.up, dist_to_ground);
    //}

}