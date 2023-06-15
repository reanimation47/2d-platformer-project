using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "Player"){
            CompleteLevel(); 
        }
    }

    private void CompleteLevel(){
        Destroy(gameObject);
    }
}
