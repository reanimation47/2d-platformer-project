using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player_transform;
    void Start()
    {
        player_transform = ICommon.GetPlayerObject().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_transform) { return; }
        transform.position = new Vector3(player_transform.position.x, player_transform.position.y, -10);
    }
}
