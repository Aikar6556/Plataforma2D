using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
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

        SceneManager.LoadScene(3);
    }


    
    
    }


}
