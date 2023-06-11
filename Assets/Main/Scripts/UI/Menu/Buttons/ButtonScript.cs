using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector] public enum ButtonType { PlayButton, CharacterSelect }
    [HideInInspector] public enum Character { Froggy, Dasher }

    public ButtonType _button_type;
    public Character _character_select;

    public CSCharacterController CharacterController;

    public Image img;
    public Sprite _default, _clicked;
    public GameObject _text_normal, _text_compressed;
    private bool _text_is_compressed = false;

    public void OnPointerDown(PointerEventData e)
    {
        img.sprite = _clicked;
        _text_is_compressed = true;
    }

    public void OnPointerUp(PointerEventData e)
    {
        img.sprite = _default;
        _text_is_compressed = false;
        ButtonClicked();
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

    private void ButtonClicked()
    {
        if (_button_type == ButtonType.PlayButton)
        {
            ICanvas.ToggleCharacterSelectionScreen();
        }

        if (_button_type == ButtonType.CharacterSelect)
        {
            CharacterController.CharacterPicked();
            Invoke("CharacterPicked", 0f);
        }
    }

    private void CharacterPicked()
    {
        Debug.Log("hey");
        StartCoroutine(ToggleStageSelectScreen());
        //ICanvas.ToggleCharacterSelectionScreen();
    }

    IEnumerator ToggleStageSelectScreen()
    {
        ICanvas.ToggleAlphaMask(1f);
        yield return new WaitForSeconds(1f);
        ICanvas.ToggleStageSelectScreen();
        yield return new WaitForSeconds(1f);
        ICanvas.ToggleAlphaMask(0f);
    }

}

