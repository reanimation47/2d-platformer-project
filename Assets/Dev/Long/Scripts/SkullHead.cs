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

    //For Checks

    [Header("Others")]
    public Transform groundCheckUp;
    public Transform groundCheckDown;
    public Transform groundCheckWall;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private bool facingLeft = true;
    private bool goingUp = true;
    private Rigidbody2D skullRB;

    private Collider2D _debug;

    void Start()
    {
        idleMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        skullRB = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);
        AttackUpNDown();
        //IdleState();
        //_debug = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
        //Debug.LogError(Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer));
    }

    void IdleState()
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

    void AttackUpNDown()
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
