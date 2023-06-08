using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    public float speed;
    public float range;
    public float checkDelay;
    public LayerMask playerLayer;
    private float checkTimer;
    private Vector3 destination;
    private Vector3 previous_destination;
    
    private bool attacking;

    private Vector3[] directions = new Vector3[4];  

    private void OnEnable(){
        Stop();
    }

    private void Update()
    {
        if(attacking)
        transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();

        for (int i =0;i< directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i],Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if(hit.collider != null & !attacking)
            {
                if (previous_destination == directions[i]) { return; }
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range;
        directions[1] = -transform.right * range;
        directions[2] = transform.up * range;
        directions[3] = -transform.up * range;
    }
    private void Stop(){
        previous_destination = destination;
        destination = transform.position;
        attacking = false;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == IPlayer.GetPlayerObject())
    {
            ICommon.KillPlayer();
    }
    else 
    {
        Stop();
    }
    }


}