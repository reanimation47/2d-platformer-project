using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InGameCanvasInterface 
{
    private static InGameCanvasController controller;
    public static void LoadController(InGameCanvasController _controller)
    {
        if (controller != null)
        {
            Debug.LogError("Unexpected InGameCanvasController was loaded into the interface!");
        }
        controller = _controller;
    }

    public static void ShowGameOverScreen()
    {
        controller.ShowGameOverScreen();
    }
    public static void RestartGame()
    {
        controller.RestartGame();
    }
    public static void BackToStageSelect()
    {
        controller.BackToStageSelect();
    }
}
