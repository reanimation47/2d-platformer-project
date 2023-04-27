using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInteraction 
{
    //Default values
    private static string defaultGroundLayer = "Ground";
    private static string defaultObstacleTag = "Obstacle";

    


    //Checking states
    public static bool isGrounded(CapsuleCollider2D collider)
    {
        LayerMask groundLayer = LayerMask.GetMask(defaultGroundLayer);
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer); //Creating a boxcast with the position & size as the collider's
    }

    public static bool CollidedWithAnObstacle(Collision2D collision)
    {
        return collision.gameObject.CompareTag(defaultObstacleTag);
    }
}
