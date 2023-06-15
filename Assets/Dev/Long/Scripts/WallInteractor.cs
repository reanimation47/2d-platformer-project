using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInteractor : MonoBehaviour
{
    [Header("Wall Slide")]
    public float wallSlideMaxSpeed = 2f;
    public float groundCheckRadius = 0.2f;
    public LayerMask wallLayer;

    public  bool isCollidingWithWall = false;
    private bool isTouchingWall = false;
    private Rigidbody2D body;
    public Transform groundCheckWall;
    private Collider2D[] overlappingColliders;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        groundCheckWall = transform;
        overlappingColliders = new Collider2D[1];
    }

    private void FixedUpdate()
    {
        isCollidingWithWall = false;
        isTouchingWall = Physics2D.OverlapCircleNonAlloc(groundCheckWall.position, groundCheckRadius, overlappingColliders, wallLayer) > 0;

        if (isTouchingWall)
        {
            isCollidingWithWall = true;
            body.velocity = new Vector2(body.velocity.x, Mathf.Clamp(body.velocity.y, -wallSlideMaxSpeed, 0f));
        }
        else
        {
            // Add any other desired behavior when not colliding with a wall
        }
    }
}
