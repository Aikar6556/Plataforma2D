using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_muerte : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




void OnTriggerEnter2D(Collider2D collision)
{
    John_movement john = collision.GetComponent<John_movement>();


    if(john != null){ //hemos impactado con john

            john.Hit(john.getVidaMaxima());
    }


    
    
    }

}
