using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    private string defaultPlayerTag = "Player";
    public GameObject GetPlayer()
    {
        return GameObject.FindWithTag(defaultPlayerTag);
    }

    public GameObject[] GetPlayers()
    {
        return GameObject.FindGameObjectsWithTag(defaultPlayerTag);
    }
}
