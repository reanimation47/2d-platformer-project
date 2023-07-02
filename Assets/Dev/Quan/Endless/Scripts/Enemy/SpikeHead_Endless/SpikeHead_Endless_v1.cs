using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead_Endless_v1 : MonoBehaviour
{
    public float speed;
    public float range;
    public float checkDelay;
    public LayerMask playerLayer;
    private float checkTimer;
    private Vector3 destination;
    private Vector3 previous_destination;

    private Transform player_transform;

    private bool attacking;

    private Vector3[] directions = new Vector3[4];

    private void OnEnable()
    {
        Stop();
    }

    private void Start()
    {
        player_transform = ICommon.GetPlayerObject().transform;
    }

    private void Update()
    {
        if (attacking)
        {
            AttackingStarted();
            transform.Translate(destination * Time.deltaTime * speed);
        }
        CheckDistance();
    }

    
    private void Stop()
    {
        previous_destination = destination;
        destination = transform.position;
        attacking = false;
    }

    //adjustments for endless

    public void StartAttackAtDir(Vector2 dir)
    {
        destination = dir;
        attacking = true;
    }

    private void CheckDistance()
    {
        if (!player_transform) { return; }
        float distance = Vector2.Distance(player_transform.position, transform.position);
        if (distance < 1)
        {
            ICommon.KillPlayer();
        }
    }

    private bool AttackingStarted_ = false;
    private void AttackingStarted()
    {
        if (AttackingStarted_) { return; } // make sure this only gets called once
        StartCoroutine(DisableAfterSeconds(7));
    }

    IEnumerator DisableAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        Stop();
    }
    



    
}
