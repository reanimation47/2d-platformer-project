using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public abstract class InGameButtonBase : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public enum ButtonType { Quit, Confirm, Restart }
    public ButtonType _button_type;
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void OnPointerDown(PointerEventData e)
    {
        if (_button_type == ButtonType.Confirm)
        {
            StartCoroutine(startWiggling(1));
            ConfirmAction();
        }
        else if (_button_type == ButtonType.Quit)
        {
            StartCoroutine(startWiggling(1));
            QuitAction();
            //Debug.LogError("Clicked");
        }
        else if (_button_type == ButtonType.Restart)
        {
            StartCoroutine(startWiggling(1));
            RestartAction();
            //Debug.LogError("Clicked");
        }
        else
        {
            Debug.LogError("Button type not defined, check GameOverButton.cs");
        }
    }

    //Try wiggling effect
    bool is_wiggling = false;
    bool wiggle_up = false;

    Vector2 scaler;
    Vector2 default_scale = new Vector2(1, 1);

    private void Start()
    {
        default_scale = rectTransform.localScale;
        scaler = default_scale;
    }

    void Update()
    {
        rectTransform.localScale = scaler;
    }
    void FixedUpdate()
    {
        if (is_wiggling)
        {
            if (wiggle_up)
            {
                scaler.x = Mathf.Lerp(scaler.x, default_scale.x + default_scale.x / 3, 0.15f);
            }
            else
            {
                scaler.x = Mathf.Lerp(scaler.x, default_scale.x, 0.15f);
            }
        }
    }

    public IEnumerator startWiggling(float duration)
    {
        is_wiggling = true;
        StartCoroutine(wigglingAction(0.1f));
        yield return new WaitForSeconds(duration);
        is_wiggling = false;
        StopCoroutine(wigglingAction(0.1f));

    }

    public IEnumerator wigglingAction(float rate)
    {
        while (is_wiggling)
        {
            yield return new WaitForSeconds(rate);
            wiggle_up = wiggle_up ? false : true;
        }

    }

    
    //Abstract methods
    public abstract void ConfirmAction();
    public abstract void QuitAction();
    public abstract void RestartAction();
}
