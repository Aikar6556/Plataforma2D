using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class John_movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed = 1;
    public float JumpForce = 150;
    private float horizontal;
    private bool Grounded;
       private float Health;


    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public GameObject prefabBullet;
    private float LastShoot;
    public Image barraDeVida;
    public float vidaMaxima;

    void Start ()
    {

        Rigidbody2D = GetComponent<Rigidbody2D>();
        Health=vidaMaxima;
        Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
        
    }

    void Update(){

        horizontal = Input.GetAxisRaw("Horizontal");

            Animator.SetBool("running",horizontal !=0.0f);

                Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
       

        if(Physics2D.Raycast(transform.position, Vector3.down,0.1f)){
            Grounded = true;
        }
        else{
            Grounded = false;
        }

        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }

     if(Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f){
    Shoot();  
    LastShoot = Time.time;

}

        if(horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);




    }


    private void Shoot(){

         Vector3 direction;

    if ( transform.localScale.x == 1.0f ) direction = Vector3.right;
    else direction = Vector3.left;
    // Pintamos el Prefab en scena, en la posición indicada y la rotación=0
GameObject bullet = Instantiate(prefabBullet,transform.position + direction *0.1f, Quaternion.identity);

bullet.GetComponent<BulletScript>().SetDirection(direction);

}


public void Hit(float dano){

    
    Health = Health - dano;
    if(Health <= 0){
        Destroy(gameObject);
        SceneManager.LoadScene(2);


    } 
    barraDeVida.fillAmount = Health/vidaMaxima;
}



    private void Jump(){

        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }


public float getVidaMaxima (){

    return this.vidaMaxima;

}

}
