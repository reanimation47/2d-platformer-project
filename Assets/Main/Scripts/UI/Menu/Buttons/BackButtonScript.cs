using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BackButtonScript : BasicButtonClass
{
    [HideInInspector] public enum CurrentScreen { startmenu, characterselect, stageselect }
    public CurrentScreen current_screen = CurrentScreen.startmenu;
    public override void ButtonAction()
    {
        if(current_screen == CurrentScreen.characterselect)
        {
            ICanvas.ToggleCharacterSelectionScreen(); //back to start menu
        }else if(current_screen == CurrentScreen.stageselect)
        {
            ICanvas.ToggleStageSelectScreen(); //back to characterselect menu
        }
        //Debug.Log("heyy");
    }
}

