using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : IPlayer
{


    //Public values
    public float PlayerJumpHeight = 9f;
    public float PlayerMovementSpeed = 9f;
    public int PlayerJumpCount = 1; //How many times player could jump mid air



    //Unity's method
    private void Start()
    {
        InitPlayerObject();
        
    }

    private void Update()
    {
        Player.GetHorizontalInput(); //getting user's horizontal inputs
        Player.GetJumpInput(); //getting user's jump input AND also do jump action
    }

    private void FixedUpdate()
    {
        Player.Move();
    }





    //Custom methods
    private void InitPlayerObject()
    {
        Player.PlayerObject = this.gameObject;
        Player.GetPlayerObject();
    }




}
