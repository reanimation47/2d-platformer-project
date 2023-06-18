using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Extension;

public interface ICommon //Interface for communications between components
{
    //Related to player
    private static float player_last_injected_dir = 0;
    public static GameObject GetPlayerObject() //return player object
    {
        return IPlayer.GetPlayerObject();
    }

    public static void KillPlayer() //Kills player
    {
        IPlayer.KillPlayer();
        InGameCanvasInterface.ShowGameOverScreen();
    }

    public static void InjectHorizontalInput(float _dir)
    {
        IPlayer.InjectHorizontalInput(_dir);
        player_last_injected_dir = _dir;
    }
    public static void InjectJumpInput()
    {
        IPlayer.InjectJumpInput();
    }

    public static float GetPlayerLastInjectedDir()
    {
        return player_last_injected_dir;
    }

    //Commonly used functions
    public static int GetCollisionDirection(Collision2D collision) //Works properly on collisions with player
    {
        return Extension.GetCollisionDirection(collision);
        //returns 0 if the collided horizontally
        //returns 1 if collided from top
        //returns 2 if collided from bottom
    }

    //ICanvas
    public static void ToggleSkipToStageSelect(bool toggle)
    {
        ICanvas.SkipToStageSelect = toggle;
    }

    //In game events
    public static void StageCompleted()
    {
        InGameCanvasInterface.ShowStageCompleteScreen();
    }
}
