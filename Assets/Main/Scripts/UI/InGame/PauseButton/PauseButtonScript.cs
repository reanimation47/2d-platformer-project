using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonScript : BasicButtonClass
{
    public override void ButtonAction()
    {
        InGameCanvasInterface.ShowPauseScreen();
    }
}
