using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidbody;

    public Animator trunkAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        trunkAnimator.SetFloat("moveSpeed",Mathf.Abs(moveSpeed));

        if (IsFacingRight()) 
        {
            //Move right
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }

        else 
        {
            //Move left
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        Debug.Log("hello");
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Turn
        transform.localScale = new Vector2(-(Mathf.Sign(-myRigidbody.velocity.x)),transform.localScale.y);
    }
}
