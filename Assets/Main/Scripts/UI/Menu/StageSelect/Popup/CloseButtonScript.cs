using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseButtonScript : BasicButtonClass
{
    public override void ButtonAction()
    {
        IStage.TogglePopup(false);
        IStage.DisableCurrentHighlightedStage();
    }
}
