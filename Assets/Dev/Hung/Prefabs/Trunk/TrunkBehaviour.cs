using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBehaviour : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    private Rigidbody2D myRigidbody;
    private GameObject player;
    private Transform player_transform;
    public Animator trunkAnimator;

    public GameObject bullet;


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
        trunkAnimator.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));

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

        // Check if facing player horizontally
        if (IsFacingPlayerHorizontally())
        {
            //Debug.LogError("Detect player horizontally");
            moveSpeed = 0;
            FireBullets();
            
        }else{
            moveSpeed = 3;
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
                StartCoroutine(Trunkdies());
            }
        }
    }

    IEnumerator Trunkdies()
    {
        trunkAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    // //Fire bullet logic

    private bool IsFacingPlayerHorizontally()
    {
        if (player)
        {
            float playerDirection = player.transform.position.x - transform.position.x;
            float enemyDirection = transform.localScale.x;
            bool x_axis_is_facing_towards_player = playerDirection > 0 != enemyDirection > 0;

            float y_diff = player.transform.position.y - transform.position.y;
            bool is_on_same_y_as_player = Mathf.Abs(y_diff) < 2;

            return x_axis_is_facing_towards_player && is_on_same_y_as_player;
        }

        return false;
    }


    
    private void FireBullets()
    {

        StartCoroutine(CoFireBullets());
    }

    private IEnumerator CoFireBullets()
    {
        GameObject player = ICommon.GetPlayerObject();
        while (IsFacingPlayerHorizontally()) 
        {
            GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity); //Spawns a bullet and assign it to _bullet

            Rigidbody2D _bullet_rb = _bullet.GetComponent<Rigidbody2D>();
            _bullet_rb.velocity = new Vector2(-50, 0); // give the spawned bullet some speed

            yield return new WaitForSeconds(1f);
        }

    }
}
