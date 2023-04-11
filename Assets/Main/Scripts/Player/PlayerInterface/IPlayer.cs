using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : MonoBehaviour
{
    public void Test()
    {
        Debug.Log("Hey there!");
    }

    public class Player
    {
        //Player's modifiable values
        public static float JumpHeight;
        public static float MovementSpeed;

        //Static stuff
        public static PlayerScript script;
        public static GameObject PlayerObject;
        public static Rigidbody2D rb;
        public static Animator anim;
        public static SpriteRenderer srenderer;


        //Dynamic values
        public static float dir_x {get;set;}

        public static void GetPlayerObject()
        {
            //Get components
            script = PlayerObject.GetComponent<PlayerScript>();
            rb = PlayerObject.GetComponent<Rigidbody2D>();
            anim = PlayerObject.GetComponent<Animator>();
            srenderer = PlayerObject.GetComponent<SpriteRenderer>();

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
            Anim_Run();
        }

        public static void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        }

        public static void Anim_Run()
        {
            bool isRunning = dir_x != 0;
            anim.SetBool("isRunning", isRunning);

            if (isRunning)
            {
                bool isRunningLeft = dir_x < 0;
                srenderer.flipX = isRunningLeft;
            }



        }

        
    }

    


}
