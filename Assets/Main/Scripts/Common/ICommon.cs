using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommon //List of important & common functions
{
    //Related to player
    public static GameObject GetPlayerObject() //return player object
    {
        return IPlayer.GetPlayerObject();
    }

    public static void KillPlayer() //Kills player
    {
        IPlayer.KillPlayer();
    }

    //Commonly used functions
    public static int GetCollisionDirection(Collision2D collision) //Works properly on collisions with player
    {
        return ExtensionCommon.GetCollisionDirection(collision);
        //returns 0 if the collided horizontally
        //returns 1 if collided from top
        //returns 2 if collided from bottom
    }
}
