using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullHead : MonoBehaviour
{
    //For Idle Stage
    [Header("Idle")]
    public float idleMoveSpeed;
    public Vector2 idleMoveDirection;

    //For Attack stage
    [Header("Attack")]
    public float attackMoveSpeed;
    public Vector2 attackMoveDirection;


    private float attackPlayerSpeed;
    public Transform player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == IPlayer.GetPlayerObject())
        {
            IPlayer.KillPlayer();
        }
    }
}
