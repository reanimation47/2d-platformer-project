using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class InGameScreenBase : MonoBehaviour
{
    //Title
    [SerializeField] private TextMeshProUGUI Title;
    private float _title_opacity_target;
    private float _title_opacity_scaler = 0;
    public string _title_text = "YOU LOST";
    //Body
    [SerializeField] private TextMeshProUGUI Body;
    private float _body_opacity_target;
    private float _body_opacity_scaler = 0;
    public string _body_text = "Try Again?";

    [SerializeField] private GameObject Buttons;
    private float _button_scale_target;
    private Vector2 _button_scaler = new Vector2(0, 0);

    private float _lerp_speed = 0.1f;

    private void Start()
    {
        SetTexts();
    }

    private void Update()
    {
        UpdateTitleOpacity();
        UpdateBodyOpacity();
        UpdateButtonsScale();
    }

    private void FixedUpdate()
    {
        UpdateTitleOpacityScaler();
        UpdateBodyOpacityScaler();
        UpdateButtonsScaler();
    }


    //Title
    private void UpdateTitleOpacityScaler()
    {
        _title_opacity_scaler = Mathf.Lerp(_title_opacity_scaler, _title_opacity_target, _lerp_speed);
    }
    private void UpdateTitleOpacity()
    {
        if (_title_opacity_scaler < 10)
        {
            Title.text = "<alpha=#0" + _title_opacity_scaler + ">" + _title_text;

        }
        else
        {
            Title.text = "<alpha=#" + (int)_title_opacity_scaler + ">" + _title_text;
        }
    }
    IEnumerator ShowTitleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _title_opacity_target = 100;
    }

    //Body
    private void UpdateBodyOpacityScaler()
    {
        _body_opacity_scaler = Mathf.Lerp(_body_opacity_scaler, _body_opacity_target, _lerp_speed);
    }
    private void UpdateBodyOpacity()
    {
        if (_body_opacity_scaler < 10)
        {
            Body.text = "<alpha=#0" + _body_opacity_scaler + ">" + _body_text;

        }
        else
        {
            Body.text = "<alpha=#" + (int)_body_opacity_scaler + ">" + _body_text;
        }
    }
    IEnumerator ShowBodyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _body_opacity_target = 100;
    }

    //Buttons
    private void UpdateButtonsScaler()
    {
        _button_scaler.x = Mathf.Lerp(_button_scaler.x, _button_scale_target, _lerp_speed);
        _button_scaler.y = Mathf.Lerp(_button_scaler.y, _button_scale_target, _lerp_speed);
    }
    private void UpdateButtonsScale()
    {
        Buttons.transform.localScale = _button_scaler;
    }
    IEnumerator ShowButtonsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _button_scale_target = 1.2f;
        yield return new WaitForSeconds(0.1f);
        _button_scale_target = 1f;
    }



    //final
    public void ToggleGroup(bool toggle)
    {
        gameObject.SetActive(toggle);
    }
    public void ShowTitle(float delay)
    {
        StartCoroutine(ShowTitleAfterDelay(delay));
    }
    public void ShowBody(float delay)
    {
        StartCoroutine(ShowBodyAfterDelay(delay));
    }
    public void ShowButtons(float delay)
    {
        StartCoroutine(ShowButtonsAfterDelay(delay));
    }

    public virtual void ChangeLerpSpeed(float _newvalue)
    {
        _lerp_speed = _newvalue;
    }
    //Abstract methods
    public abstract void SetTexts();

}
