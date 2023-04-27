using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommon 
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
}
