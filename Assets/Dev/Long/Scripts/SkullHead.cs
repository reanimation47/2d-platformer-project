using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SkullHead : MonoBehaviour
{
    
    //For Idle Stage
    [Header("Idle")]
    public float idleMoveSpeed = 1f;
    public Vector2 idleMoveDirection;

    //For Attack stage
    [Header("Attack")]
    public float attackMoveSpeed;
    public Vector2 attackMoveDirection;

    [Header("Attack Player")]
    public float attackPlayerSpeed = 1f;
    public Transform player;
    private Vector2 playerPosis;
    //For Checks

    [Header("Others")]
    public Transform groundCheckUp;
    public Transform groundCheckDown;
    public Transform groundCheckWall;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    //For detect ground
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;

    //for turn the skull
    private bool facingLeft = true;
    private bool goingUp = true;
    private Rigidbody2D skullRB;

    //for logic of skull attack
    public int groundTouchCount = 0; // Counter for tracking ground touches
    public float maxDistanceToPlayer = 3f; // Maximum distance to consider the player as far

    public Animator skullHead;
    public bool isImmortal = false;

    void Start()
    {
        idleMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        skullRB = GetComponent<Rigidbody2D>();
        skullHead = GetComponent<Animator>();
    }


    // Update is called once per frame

    void Update()
    {
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);

        if (isTouchingDown || isTouchingUp || isTouchingWall)
        {   
            isImmortal = !isImmortal;
            AttackUpNDown();
            groundTouchCount++; // Increment the ground touch counter
            if (groundTouchCount >= 1000)
            {
                AttackPlayer();
                //groundTouchCount = 0; // Reset the ground touch counter
                
            }
        }
        else 
        {
            IdleState();
        }
        
        FlipTowardsPlayer();
    }


    public void IdleState()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        } else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Turn();
            } 
            else if (!facingLeft)
            {
                Turn();
            }
        }

        skullRB.velocity = idleMoveSpeed * idleMoveDirection;

    }

    public void AttackUpNDown()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Turn();
            }
            else if (!facingLeft)
            {
                Turn();
            }
        }

        skullRB.velocity = attackMoveSpeed * attackMoveDirection;

    }

    public void AttackPlayer()
    {
        skullHead.SetBool("isImmortal", true);
        //take player position
        playerPosis = player.position - transform.position;
        //normalize player position
        playerPosis.Normalize();
        //attack on player
        skullRB.velocity = playerPosis * attackPlayerSpeed;
    }

    void FlipTowardsPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if (playerDirection > 0 && facingLeft)
        {
            Turn();
        } 
        else if (playerDirection < 0 && !facingLeft)
        {
            Turn();
        }
    }
    void ChangeDirection()
    {
        goingUp = !goingUp;
        idleMoveDirection.y *= -1;
        attackMoveDirection.y *= -1;
    }
    
    void Turn()
    {
        facingLeft = !facingLeft;
        idleMoveDirection.x *= -1;
        attackMoveDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position, groundCheckRadius);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == IPlayer.GetPlayerObject())
        {
            ICommon.KillPlayer();
        }
    }
}
