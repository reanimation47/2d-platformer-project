using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    private Vector3 popup_positioner = new Vector3(0, 0, 0);
    private Vector3 popup_positioner_default = new Vector3(0, 0, 0);
    private float popup_target_x = 0;
    private bool popup_shown = false;
    RectTransform rectTransform;
    private void Awake()
    {
        IStage.LoadPopupController(this);
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        TogglePopup(false);

    }

    void Update()
    {
        rectTransform.anchoredPosition = popup_positioner;
    }

    private void FixedUpdate()
    {
        popup_positioner.x = Mathf.Lerp(popup_positioner.x, popup_target_x, 0.1f);
    }

    public void TogglePopup(bool _toggle)
    {
        if (_toggle)
        {
            popup_target_x = 0;
        }else
        {
            popup_target_x = 400;
        }
        popup_shown = _toggle;

    }
}
