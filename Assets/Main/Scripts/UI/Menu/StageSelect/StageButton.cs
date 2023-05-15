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

    private void Start()
    {
        SetupStageIndex();
    }

    public void OnPointerDown(PointerEventData e)
    {

        //ToggleStageHighlight(true);
        IStage.RegisterHighlightedStage(this);
    }

    private void SetupStageIndex()
    {
        stage_index_object.GetComponent<TextMeshProUGUI>().text = stage_index.ToString();
    }

    public void ToggleStageHighlight(bool _toggle)
    {
        stage_hightlight.SetActive(_toggle);
    }
}
