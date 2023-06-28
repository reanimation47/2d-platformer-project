using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonScript : BasicButtonClass
{
    public override void ButtonAction()
    {
        if (InGameCanvasInterface.isPaused())
        {
            return;
        }
        InGameCanvasInterface.ShowPauseScreen();
    }
}
