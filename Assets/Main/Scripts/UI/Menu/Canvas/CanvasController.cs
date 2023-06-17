using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CanvasController : MonoBehaviour
{
    public Image AlphaMask;
    public GameObject MainMenu;
    public GameObject CharacterSelection;
    public GameObject StageSelect;

    private enum CurrentScreen { startmenu, characterselect, stageselect}
    private CurrentScreen current_screen = CurrentScreen.startmenu;
    private bool is_on_cselection = false;
    private bool is_on_stageselect = false;

    private static float _default_offset = 450;

    //
    private Vector3 _default_mainmenu_pos;
    private Vector3 _mainmenu_positioner = new Vector3(0,0,0);
    private Vector3 _cselection_positioner = new Vector3(0, -_default_offset, 0);
    private Vector3 _stageselect_positioner = new Vector3(_default_offset * 3, 0, 0);


    private float _mainmenu_target_y = 0f;

    private float _cselection_target_y = -_default_offset;
    private float _cselection_target_x = 0;

    private float _stageselect_target_x = _default_offset * 3;

    private float _x_lerp_speed = 0.02f;
    private float _y_lerp_speed = 0.05f;


    //alpha mask
    private float _alpha_scaler = 0f;
    private float _alpha_target =0f;

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
        UpdateAlphaMask();
        UpdateMainMenuPosition();
        UpdateCharacterSelectionPosition();
        UpdateStageSelectionPosition();
    }

    private void FixedUpdate()
    {
        UpdateAlphaMaskScaler();
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
            _x_lerp_speed = 0.07f;
            _cselection_target_x = - _default_offset * 2;
            _stageselect_target_x = 0;
            current_screen = CurrentScreen.stageselect;
        }else
        {
            _x_lerp_speed = 0.07f;
            _cselection_target_x = 0;
            _stageselect_target_x = _default_offset * 3;
            current_screen = CurrentScreen.characterselect;
        }
    }

    //Alpha mask
    private void UpdateAlphaMask()
    {
        Color _color = new Color();
        _color.a = _alpha_scaler;
        AlphaMask.color = _color;
    }
    private void UpdateAlphaMaskScaler()
    {
        _alpha_scaler = Mathf.Lerp(_alpha_scaler, _alpha_target, 0.1f);
    }
    public void ToggleAlphaMask(float _alpha)
    {
        _alpha_target = _alpha;
    }


    //Start Menu
    private void UpdateMainMenuPosition()
    {
        MainMenu.transform.localPosition = _mainmenu_positioner;
    }

    private void UpdateMainMenuPositioner()
    {
        _mainmenu_positioner.y = Mathf.Lerp(_mainmenu_positioner.y, _mainmenu_target_y, _y_lerp_speed);
    }


    //Character Select
    private void UpdateCharacterSelectionPosition()
    {
        CharacterSelection.transform.localPosition = _cselection_positioner;
    }

    private void UpdateCharacterSelectionPositioner()
    {
        _cselection_positioner.y = Mathf.Lerp(_cselection_positioner.y, _cselection_target_y, _y_lerp_speed);
        _cselection_positioner.x = Mathf.Lerp(_cselection_positioner.x, _cselection_target_x, _x_lerp_speed);
    }


    //Stage Select
    private void UpdateStageSelectionPosition()
    {
        StageSelect.transform.localPosition = _stageselect_positioner;
    }

    private void UpdateStageSelectionPositioner()
    {
        _stageselect_positioner.x = Mathf.Lerp(_stageselect_positioner.x, _stageselect_target_x, _x_lerp_speed);
    }
}
