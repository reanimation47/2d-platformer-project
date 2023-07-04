using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGuard_Endless : MonoBehaviour
{
    Transform PlayerTransform;

    private void Awake()
    {
        PlayerTransform = ICommon.GetPlayerObject().transform;
    }

    private void Update()
    {
        CheckDistanceWithPlayer();
    }
    private void CheckDistanceWithPlayer()
    {
        if (!PlayerTransform) { return; }
        float distance = Vector2.Distance(PlayerTransform.position, transform.position);
        if (distance < 1)
        {
            ICommon.KillPlayer();
        }
    }
}
