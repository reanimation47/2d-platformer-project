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
    public static void ShowStageCompleteScreen()
    {
        controller.ShowStageCompleteScreen();
    }
    public static void RestartGame()
    {
        controller.RestartGame();
    }
    public static void BackToStageSelect()
    {
        controller.BackToStageSelect();
    }
    public static void ShowPauseScreen()
    {
        controller.ShowPauseScreen();
    }
    public static void ResumeGame()
    {
        controller.ResumeGame();
    }
}
