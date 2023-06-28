using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCompleteButton : InGameButtonBase
{
    public override void ConfirmAction()
    {
        InGameCanvasInterface.ProceedToNextStage();
    }
    public override void QuitAction()
    {
        InGameCanvasInterface.BackToStageSelect();
    }
    public override void RestartAction()
    {

    }
}
