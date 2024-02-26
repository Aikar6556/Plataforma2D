using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
        public AudioClip Sonido;


    public void SetDirection(Vector2 direction){
		Direction = direction;
}

    


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
                Camera.main.GetComponent<AudioSource>().PlayOneShot(Sonido);


        
    }

    // Update is called once per frame

    private void FixedUpdate(){

       // Rigidbody2D.velocity = Vector2.right*Speed;
    Rigidbody2D.velocity = Direction * Speed;

    }

    public void DestroyBullet()
{
    Destroy(gameObject);
}


    void Update()
    {
        
        
    }


void OnTriggerEnter2D(Collider2D collision)
{
    John_movement john = collision.GetComponent<John_movement>();
    Grunt_Script grunt = collision.GetComponent<Grunt_Script>();
    if(john != null){ //hemos impactado con john
    john.Hit();
    DestroyBullet();
    }   
    if(grunt != null){//hemos impactado con grunt
    grunt.Hit();
    DestroyBullet();
    }


    
    
}



}
