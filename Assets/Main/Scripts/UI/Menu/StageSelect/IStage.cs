using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStage 
{
    //Monitoring highlighted stages
    private static StageButton _highlighted_stage = null;
    public static void RegisterHighlightedStage(StageButton _stage)
    {
        if (_highlighted_stage == null)
        {
            _highlighted_stage = _stage;
            _stage.ToggleStageHighlight(true);
        }else
        {
            _highlighted_stage.ToggleStageHighlight(false);
            _highlighted_stage = null;

            RegisterHighlightedStage(_stage);
        }
    }

    //Stage Manager
    private static StageManager StageManager;
    public static void LoadStageManager(StageManager _stagemanager)
    {
        StageManager = _stagemanager;
    }
    public static int GetCurrentUnlockedIndex()
    {
        return StageManager.GetCurrentUnlockedIndex();
    }

    //PopupController
    private static PopupController PopupController;
    public static void LoadPopupController(PopupController _controller)
    {
        PopupController = _controller;
    }

    public static void TogglePopup(bool _toggle)
    {
        PopupController.TogglePopup(_toggle);
    }
}
