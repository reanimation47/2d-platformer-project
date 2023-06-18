using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum.StageSelect.StageIndex;
using UnityEngine.SceneManagement;

public class StartButton : BasicButtonClass
{
    public override void ButtonAction()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        ICanvas.ToggleAlphaMask(1f);
        yield return new WaitForSeconds(1f);
        string _scene_name = StageIndexing.GetStageAtIndex(IStage.GetCurrentHighlightedStageIndex());
        AsyncOperation async_load = SceneManager.LoadSceneAsync(_scene_name);
        while(!async_load.isDone)
        {
            yield return null;
        }

    }
}
