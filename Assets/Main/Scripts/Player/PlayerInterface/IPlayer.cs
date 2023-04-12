using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : MonoBehaviour
{
    public void ITest()
    {
        Debug.Log("Hey there!");
    }

    public class Player
    {
        //Player's modifiable values
        private static float JumpHeight;
        private static float MovementSpeed;

        //Static stuff
        private static PlayerScript script;
        public static GameObject PlayerObject;
        private static Rigidbody2D rb;
        private static Animator anim;
        private static SpriteRenderer srenderer;
        private static BoxCollider2D collider;


        //Dynamic values
        private static float dir_x {get;set;}
        //private enum anim_state { idle, running, jumping, falling };

        public static void GetPlayerObject()
        {
            //Get components
            script = PlayerObject.GetComponent<PlayerScript>();
            rb = PlayerObject.GetComponent<Rigidbody2D>();
            anim = PlayerObject.GetComponent<Animator>();
            srenderer = PlayerObject.GetComponent<SpriteRenderer>();
            collider = PlayerObject.GetComponent<BoxCollider2D>();

            //Get values
            JumpHeight = script.PlayerJumpHeight;
            MovementSpeed = script.PlayerMovementSpeed;
        }

        public static void GetHorizontalInput()
        {
            dir_x = Input.GetAxisRaw("Horizontal");
        }

        public static void GetJumpInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            };
        }

        public static void Move()
        {
            rb.velocity = new Vector2(dir_x * MovementSpeed, rb.velocity.y);
            PlayerAnimation.UpdateAnimState(anim, rb, dir_x, srenderer);
        }

        private static void Jump()
        {
            if (!PlayerInteraction.isGrounded(collider))
            {
                return;
            }
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        }

        
    }

    private class PlayerAnimation : IPlayerAnimation
    {
        public static void anim_test()
        {
            IPlayerAnimation.Testing();
        }

        public static void UpdateAnimState(Animator anim, Rigidbody2D rb, float dir_x, SpriteRenderer srenderer)
        {
            IPlayerAnimation.UpdateAnimState(anim, rb, dir_x, srenderer);
        }
    }

    private class PlayerInteraction: IPlayerInteraction
    {
        public static bool isGrounded(BoxCollider2D collider)
        {
            return IPlayerInteraction.isGrounded(collider);
        }
    }
    


}
