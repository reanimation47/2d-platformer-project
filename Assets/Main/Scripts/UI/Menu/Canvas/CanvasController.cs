using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CanvasController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CharacterSelection;

    private bool is_on_cselection;

    private static float _default_offset = 450;

    private Vector3 _default_mainmenu_pos;
    private Vector3 _mainmenu_positioner = new Vector3(0,0,0);
    private Vector3 _cselection_positioner = new Vector3(0, -_default_offset, 0);


    private float _mainmenu_target_y = 0f;
    private float _cselection_target_y = -_default_offset;

    private void Awake()
    {
        ICanvas.LoadCanvasController(this);
        _default_mainmenu_pos = MainMenu.transform.position;
    }

    private void Start()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    private void Update()
    {
        UpdateMainMenuPosition();
        UpdateCharacterSelectionPosition();
    }

    private void FixedUpdate()
    {
        UpdateMainMenuPositioner();
        UpdateCharacterSelectionPositioner();
    }

    //custom methods
    public void ToggleCharacterSelectionScreen()
    {
        if (!is_on_cselection)
        {
            _mainmenu_target_y = _default_offset;
            _cselection_target_y = 0;
        }
        else
        {
            _mainmenu_target_y = 0;
            _cselection_target_y = -_default_offset;

        }
        is_on_cselection = !is_on_cselection;
    }

    private void UpdateMainMenuPosition()
    {
        MainMenu.transform.localPosition = _mainmenu_positioner;
    }

    private void UpdateMainMenuPositioner()
    {
        _mainmenu_positioner.y = Mathf.Lerp(_mainmenu_positioner.y, _mainmenu_target_y, 0.05f);
    }

    private void UpdateCharacterSelectionPosition()
    {
        CharacterSelection.transform.localPosition = _cselection_positioner;
    }

    private void UpdateCharacterSelectionPositioner()
    {
        _cselection_positioner.y = Mathf.Lerp(_cselection_positioner.y, _cselection_target_y, 0.05f);
    }
}
