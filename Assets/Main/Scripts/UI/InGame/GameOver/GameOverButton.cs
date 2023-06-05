using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector] public enum ButtonType { Quit, Confirm }
    public ButtonType _button_type;
    public void OnPointerDown(PointerEventData e)
    {
        
    }

    public void OnPointerUp(PointerEventData e)
    {
        
    }
}
