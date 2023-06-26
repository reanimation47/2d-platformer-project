using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        player = ICommon.GetPlayerObject().transform;
    }
    // Update is called once per frame
    private void Update()
    {
        if (!player) { return; }
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
    }
}
