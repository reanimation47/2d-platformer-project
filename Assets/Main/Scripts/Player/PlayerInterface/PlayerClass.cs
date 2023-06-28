using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
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
        private static int JumpCount;

        //Static stuff
        private static PlayerScript script;
        public static GameObject PlayerObject;
        private static Rigidbody2D rb;
        private static Animator anim;
        private static SpriteRenderer srenderer;
        //private static BoxCollider2D collider;
        private static CapsuleCollider2D collider;
        private static int defaultJumpCount;
        private static string obstacleTag;


        //Dynamic values
        public static float dir_x {get;set;}
        private static bool _is_being_injected = false;
        //private enum anim_state { idle, running, jumping, falling };

        public static void GetPlayerObject()
        {
            PlayerObject = IPlayer.GetPlayerObject();
            

            //Get components
            script = PlayerObject.GetComponent<PlayerScript>();
            rb = PlayerObject.GetComponent<Rigidbody2D>();
            anim = PlayerObject.GetComponent<Animator>();
            srenderer = PlayerObject.GetComponent<SpriteRenderer>();
            //collider = PlayerObject.GetComponent<BoxCollider2D>();
            collider = PlayerObject.GetComponent<CapsuleCollider2D>();

            //Get values
            JumpHeight = script.PlayerJumpHeight;
            MovementSpeed = script.PlayerMovementSpeed;
            JumpCount = script.PlayerJumpCount;
            defaultJumpCount = JumpCount;
            //obstacleTag = script.ObstacleTag;
        }

        public static void GetHorizontalInput()
        {
            if (_is_being_injected) { return; }
            dir_x = Input.GetAxisRaw("Horizontal");
        }

        public static void InjectHorizontalInput(float _x)
        {
            _is_being_injected = _x != 0;
            dir_x = _x;
        }

        public static void GetJumpInput()
        {
            //ResetJumpCount();
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            };
        }

        public static void Move()
        {
            rb.velocity = new Vector2(dir_x * MovementSpeed, rb.velocity.y);
            IPlayerAnimation.UpdateAnimState(anim, rb, dir_x, srenderer);
        }

        public static void Jump()
        {
            bool stillHaveMidAirJump = JumpCount > 0;
            if (stillHaveMidAirJump)
            {
                JumpCount -= 1;
            }
            else
            {
                return;
            }
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        }

        public static void ResetJumpCount(Collider2D collision)
        {
            JumpCount = defaultJumpCount;
        }

        public static int CheckOnCollision(Collision2D collision)
        {
            if (IPlayerInteraction.CollidedWithAnObstacle(collision))
            {
                Debug.Log("hit!!");
                rb.isKinematic = true; //freeze player position
                return 0;
            }else
            {
                return 1;
            }
        }

        public static void ToggleAnimTrigger(string trigger)
        {
            IPlayerAnimation.ToggleAnimTrigger(anim, trigger);
        }

        public static void Killed()
        {
            Destroy(PlayerObject);
        }


     

        
    }

}
