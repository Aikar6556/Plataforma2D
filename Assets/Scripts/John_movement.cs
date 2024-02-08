using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D Rigidbody2D;
    void Start ()
    {

        Rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
        
    }
}
