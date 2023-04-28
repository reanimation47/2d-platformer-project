using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    //references
    private static GameObject PlayerObject;
    private static PlayerScript PlayerScript;

    //Player object
    public static void LoadPlayerObject(GameObject player_object)
    {
        PlayerObject = player_object;
        PlayerScript = PlayerObject.GetComponent<PlayerScript>();
    }
    public static GameObject GetPlayerObject()
    {
        if (!PlayerObject)
        {
            Debug.LogError("err 1 - Player's game object is not loaded!");
        }
        return PlayerObject;
    }

    //Player's public methods

    public static void KillPlayer()
    {
        if (!PlayerObject)
        {
            Debug.LogError("err 2 - Player's game object is not loaded!");
        }
        PlayerScript.KillPlayer();
    }
}
