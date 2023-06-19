using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverButton : InGameButtonBase
{
    public override void ConfirmAction()
    {
        InGameCanvasInterface.RestartGame();
    }
    public override void QuitAction()
    {
        InGameCanvasInterface.BackToStageSelect();
    }
    public override void RestartAction()
    {

    }

}
