using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D myRigidbody;
    private GameObject player;
    private Transform player_transform;
    public Animator AngryPig;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        player = ICommon.GetPlayerObject();


        if (player)
        {
            player_transform = player.GetComponent<Transform>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        AngryPig.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));

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
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Turn
        transform.localScale = new Vector2(-(Mathf.Sign(-myRigidbody.velocity.x)), transform.localScale.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError("Hit");
        if (collision.gameObject == player)
        {
            int collide_state = ICommon.GetCollisionDirection(collision);

            if (collide_state == 0)
            {
                ICommon.KillPlayer();
            }
            else if (collide_state == 1)
            {
                StartCoroutine(Pigdies());
            }
        }
    }

    IEnumerator Pigdies()
    {
        AngryPig.SetTrigger("Die");
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
