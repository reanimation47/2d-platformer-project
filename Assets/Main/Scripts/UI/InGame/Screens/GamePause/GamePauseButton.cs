using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseButton : InGameButtonBase
{
    public override void ConfirmAction()
    {
        InGameCanvasInterface.ResumeGame();
    }
    public override void QuitAction()
    {
        Time.timeScale = 1;
        InGameCanvasInterface.BackToStageSelect();
    }
    public override void RestartAction()
    {
        Time.timeScale = 1;
        InGameCanvasInterface.RestartGame();
    }
}
