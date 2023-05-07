using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Image img;
    public Sprite _default, _clicked;

    private void OnMouseDown()
    {
        Debug.Log("hit");
    }

    public void OnPointerDown(PointerEventData e)
    {
        img.sprite = _clicked;
    }

    public void OnPointerUp(PointerEventData e)
    {
        img.sprite = _default;
    }
}

