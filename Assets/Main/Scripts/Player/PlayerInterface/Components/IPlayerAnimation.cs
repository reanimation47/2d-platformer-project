using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAnimation
{
    public static void Testing()
    {
        Debug.Log("animmm");
    }
    private enum anim_state { idle, running, jumping, falling };

    public static void UpdateAnimState(Animator anim, Rigidbody2D rb, float dir_x, SpriteRenderer srenderer)
    {
        anim_state state;
        bool isRunning = dir_x != 0;
        float vertical_velocity = rb.velocity.y;

        state = isRunning ? anim_state.running : anim_state.idle;

        if (isRunning)
        {
            bool isRunningLeft = dir_x < 0;
            srenderer.flipX = isRunningLeft;
        }

        if (vertical_velocity != 0)
        {
            state = (vertical_velocity > 0.01f) ? anim_state.jumping : anim_state.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
