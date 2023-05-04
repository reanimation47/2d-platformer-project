using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ExtensionCommon 
{
    public static int GetCollisionDirection(Collision2D collision) 
    {
        Collider2D collider = collision.collider;

        Vector2 contactPoint = collision.GetContact(0).point;
        Vector2 center = collider.bounds.center;

        float collider_bounds_max = collider.bounds.max.y; // Player's collider is a perfect circle so y or x doesn't matter

        float collider_size = collider.bounds.size.y; // Player's collider is a perfect circle so y or x doesn't matter
        float error_margin = collider_size / 5;

        bool collided_on_top = collider_bounds_max - contactPoint.y >= collider_size - error_margin;

        bool collided_from_bottom = collider_bounds_max - contactPoint.y <= 0 + error_margin && !collided_on_top;

        if (collided_on_top) { return 1; }
        if (collided_from_bottom) { return 2; }
        return 0;
    }
}
