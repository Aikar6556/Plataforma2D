using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John_movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed = 1;
    public float JumpForce = 150;
    private float horizontal;
    private bool Grounded;

    private Rigidbody2D Rigidbody2D;
    void Start ()
    {

        Rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
        
    }

    void Update(){

        horizontal = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetKeyDown(KeyCode.W)){

            Jump();
        }

        if(Physics2D.Raycast(transform.position, Vector3.down,0.1f)){
            Grounded = true;
        }
        else{
            Grounded = false;
        }

        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);



    }


    private void Jump(){

        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
}
