using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBehaviour : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    private Rigidbody2D myRigidbody;
    private GameObject player;
    private Transform player_transform;
    public Animator mushroomAnimator;


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
        mushroomAnimator.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));

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

    //Patrolling logic
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Turn
        transform.localScale = new Vector2(
            -(Mathf.Sign(-myRigidbody.velocity.x)),
            transform.localScale.y
        );
    }

    //Die logic
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
                //anim
                //Destroy(gameObject);
                StartCoroutine(Mushroomdies());
            }
        }
    }

    IEnumerator Mushroomdies()
    {
        mushroomAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
