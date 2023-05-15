using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStage 
{
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
}
