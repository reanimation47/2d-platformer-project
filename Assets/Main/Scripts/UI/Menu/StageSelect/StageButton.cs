using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class StageButton : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public enum ButtonType { Normal, Extra_Top, Extra_Bottom}
    public ButtonType button_type;

    [SerializeField] private GameObject stage_hightlight;
    [SerializeField] private GameObject stage_icon;

    public GameObject stage_index_object;
    public int stage_index = 0;

    private bool _stage_highlighted = false;
    private bool _stage_unlocked = false;

    private void Start()
    {
        SetupStageIndex();
        InitUnlockedExtraStage();
    }

    public void OnPointerDown(PointerEventData e)
    {
        StageHighlightAction();
    }


    //custom methods
    private void SetupStageIndex()
    {
        stage_index_object.GetComponent<TextMeshProUGUI>().text = stage_index.ToString();
    }

    public void ToggleStageHighlight(bool _toggle)
    {
        _stage_highlighted = _toggle;
        stage_hightlight.SetActive(_toggle);
        IStage.TogglePopup(_toggle);
    }

    public void DebugIndex()
    {
        Debug.Log(stage_index);
    }

    public void ToggleStageUnlocked(bool _is_unlocked)
    {
        _stage_unlocked = _is_unlocked;
        transform.Find("Unlocked").gameObject.SetActive(_is_unlocked);
        transform.Find("Locked").gameObject.SetActive(!_is_unlocked);
    }

    private void InitUnlockedExtraStage() // only for extra stages
    {
        if (button_type == ButtonType.Normal) { return; }

        int _unlocked_index = IStage.GetCurrentUnlockedIndex();
        bool _stage_unlocked = _unlocked_index >= stage_index;
        ToggleStageUnlocked(_stage_unlocked);
    }

    private void StageHighlightAction()
    {
        if (!_stage_unlocked) { return; }
        if (_stage_highlighted)
        {
            ToggleStageHighlight(false);
        }
        else
        {
            IStage.RegisterHighlightedStage(this);
        }
    }

    //public methods for info
    public int GetStageIndex()
    {
        if (isExtraStage())
        {
            return stage_index * 1000;
        }
        else
        {
            return stage_index;
        }
    }

    public bool isExtraStage()
    {
        return button_type == ButtonType.Extra_Bottom || button_type == ButtonType.Extra_Top;
    }
}
