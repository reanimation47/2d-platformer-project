using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public GameObject GetPlayer()
    {
        return GameObject.FindWithTag("Player");
    }

    public GameObject[] GetPlayers()
    {
        return GameObject.FindGameObjectsWithTag("Player");
    }
}
