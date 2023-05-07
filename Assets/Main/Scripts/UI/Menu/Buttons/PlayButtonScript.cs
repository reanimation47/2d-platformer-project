using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Image img;
    public Sprite _default, _clicked;
    public GameObject _text_normal, _text_compressed;
    private bool _text_is_compressed = false;

    private void OnMouseDown()
    {
        Debug.Log("hit");
    }

    public void OnPointerDown(PointerEventData e)
    {
        img.sprite = _clicked;
        _text_is_compressed = true;
    }

    public void OnPointerUp(PointerEventData e)
    {
        img.sprite = _default;
        _text_is_compressed = false;
    }

    void Update()
    {
        ToggleTexts();
    }

    //custom methods

    private void ToggleTexts()
    {
        _text_normal.SetActive(!_text_is_compressed);
        _text_compressed.SetActive(_text_is_compressed);
    }
}

