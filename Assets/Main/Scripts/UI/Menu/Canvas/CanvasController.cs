using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CanvasController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CharacterSelection;
    public GameObject StageSelect;

    private enum CurrentScreen { startmenu, characterselect, stageselect}
    private CurrentScreen current_screen = CurrentScreen.startmenu;
    private bool is_on_cselection = false;
    private bool is_on_stageselect = false;

    private static float _default_offset = 450;

    private Vector3 _default_mainmenu_pos;
    private Vector3 _mainmenu_positioner = new Vector3(0,0,0);
    private Vector3 _cselection_positioner = new Vector3(0, -_default_offset, 0);
    private Vector3 _stageselect_positioner = new Vector3(_default_offset * 3, 0, 0);


    private float _mainmenu_target_y = 0f;

    private float _cselection_target_y = -_default_offset;
    private float _cselection_target_x = 0;

    private float _stageselect_target_x = _default_offset * 3;

    private void Awake()
    {
        ICanvas.LoadCanvasController(this);
        _default_mainmenu_pos = MainMenu.transform.position;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void Update()
    {
        UpdateMainMenuPosition();
        UpdateCharacterSelectionPosition();
        UpdateStageSelectionPosition();
    }

    private void FixedUpdate()
    {
        UpdateMainMenuPositioner();
        UpdateCharacterSelectionPositioner();
        UpdateStageSelectionPositioner();
    }

    //custom methods
    public void ToggleCharacterSelectionScreen()
    {
        if (current_screen != CurrentScreen.characterselect)
        {
            _mainmenu_target_y = _default_offset;
            _cselection_target_y = 0;
            current_screen = CurrentScreen.characterselect;
        }
        else
        {
            _mainmenu_target_y = 0;
            _cselection_target_y = -_default_offset;
            current_screen = CurrentScreen.startmenu;
        }
        //is_on_cselection = !is_on_cselection;
    }

    public void ToggleStageSelectScreen()
    {
        if (current_screen != CurrentScreen.stageselect)
        {
            _cselection_target_x = - _default_offset * 2;
            _stageselect_target_x = 0;
            current_screen = CurrentScreen.stageselect;
        }
    }

    //Start Menu
    private void UpdateMainMenuPosition()
    {
        MainMenu.transform.localPosition = _mainmenu_positioner;
    }

    private void UpdateMainMenuPositioner()
    {
        _mainmenu_positioner.y = Mathf.Lerp(_mainmenu_positioner.y, _mainmenu_target_y, 0.05f);
    }


    //Character Select
    private void UpdateCharacterSelectionPosition()
    {
        CharacterSelection.transform.localPosition = _cselection_positioner;
    }

    private void UpdateCharacterSelectionPositioner()
    {
        _cselection_positioner.y = Mathf.Lerp(_cselection_positioner.y, _cselection_target_y, 0.05f);
        _cselection_positioner.x = Mathf.Lerp(_cselection_positioner.x, _cselection_target_x, 0.02f);
    }


    //Stage Select
    private void UpdateStageSelectionPosition()
    {
        StageSelect.transform.localPosition = _stageselect_positioner;
    }

    private void UpdateStageSelectionPositioner()
    {
        _stageselect_positioner.x = Mathf.Lerp(_stageselect_positioner.x, _stageselect_target_x, 0.02f);
    }
}
