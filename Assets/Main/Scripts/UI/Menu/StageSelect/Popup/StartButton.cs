using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum.StageSelect.StageIndex;
using UnityEngine.SceneManagement;

public class StartButton : BasicButtonClass
{
    public override void ButtonAction()
    {
        string _scene_name = StageIndexing.GetStageAtIndex(IStage.GetCurrentHighlightedStageIndex());
        Debug.Log(_scene_name);
        SceneManager.LoadScene(_scene_name);
    }
}
