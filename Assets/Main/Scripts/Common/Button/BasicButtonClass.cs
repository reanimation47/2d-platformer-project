using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BasicButtonClass : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Vector3 scaler = new Vector3(1, 1, 1);
    private Vector3 normal = new Vector3(1, 1, 1);
    private Vector3 shrinker = new Vector3(0.8f, 0.8f, 1);
    private float target = 1;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectTransform.localScale = scaler;
    }

    private void FixedUpdate()
    {
        scaler.x = Mathf.Lerp(scaler.x, target, 0.3f);
        scaler.y = Mathf.Lerp(scaler.y, target, 0.3f);
    }

    public void OnPointerDown(PointerEventData e)
    {
        target = 0.8f;
    }

    public void OnPointerUp(PointerEventData e)
    {
        target = 1f;
        //IStage.TogglePopup(false);
        //IStage.DisableCurrentHighlightedStage();
        ButtonAction();
    }

    public virtual void ButtonAction()
    {
        //override this
    }
}
