using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ICanvas //communicating between canvas controller and other UI components
{
    private static CanvasController CanvasController;
    public static bool SkipToStageSelect = false;

    public static void LoadCanvasController(CanvasController _canvas)
    {
        CanvasController = _canvas;
    }

    public static void ToggleCharacterSelectionScreen()
    {
        CanvasController.ToggleCharacterSelectionScreen();
    }

    public static void ToggleStageSelectScreen()
    {
        CanvasController.ToggleStageSelectScreen();
    }

    public static void SkipToStageSelectScreen()
    {
        CanvasController.SkipToStageSelectScreen();
    }

    public static void ToggleAlphaMask(float _alpha)
    {
        CanvasController.ToggleAlphaMask(_alpha);
    }
}
