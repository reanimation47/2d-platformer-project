using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private Transform player_transform;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        player = ICommon.GetPlayerObject();


        if (player)
        {
            player_transform = player.GetComponent<Transform>();
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x != 0)
        {
            anim.SetInteger("state", 1);
        }else
        {
            anim.SetInteger("state", 0);
        }
    }

    private void FixedUpdate()
    {
        if (!player) { return; }
        float duck_x = transform.position.x;
        float player_x = player_transform.position.x;

        float player_y = player_transform.position.y;
        float duck_y = transform.position.y;

        float distance_x = player_x - duck_x;

        if(player_y - duck_y < 3f)
        {
            rb.velocity = new Vector2(distance_x, rb.velocity.y);
        }



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
            }else if (collide_state ==1)
            {
                //anim
                //Destroy(gameObject);
                StartCoroutine(Duckdies());
            }
        }

    }

    IEnumerator Duckdies()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject == player)
    //    {
    //        int collide_state = ICommon.GetCollisionDirection(collision);
    //        if (collide_state == 0)
    //        {
    //            ICommon.KillPlayer();
    //        }else if (collide_state ==1)
    //        {
    //            Destroy(gameObject);
    //        }
    //        //
    //    }
    //}
}
