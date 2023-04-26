using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private Transform player_transform;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

        if (player)
        {
            player_transform = player.GetComponent<Transform>();
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!player) { return; }
        float duck_x = transform.position.x;
        float player_x = player_transform.position.x;

        float distance_x = player_x - duck_x;


        rb.velocity = new Vector2(distance_x, 0);
    }
}
