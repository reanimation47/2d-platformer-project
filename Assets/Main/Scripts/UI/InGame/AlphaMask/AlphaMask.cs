
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaMask : MonoBehaviour
{
    private Color bg_blur = new Color();
    private float bg_blur_scaler;
    private float bg_blur_target = 0;
    private float blur_speed = 0.05f;
    private Image mask;
    void Start()
    {
        mask = GetComponent<Image>();    
        
    }

    private void Update()
    {
        UpdateBlur();
    }

    private void FixedUpdate()
    {
        UpdateBlurScaler();
    }

    private void UpdateBlurScaler()
    {
        bg_blur_scaler = Mathf.Lerp(bg_blur_scaler, bg_blur_target, blur_speed);
    }

    private void UpdateBlur()
    {
        bg_blur.a = bg_blur_scaler;
        mask.color = bg_blur;
    }

    public void SetBackGroundFullBlur()
    {
        bg_blur_target = 1;
        bg_blur_scaler = 1;

    }

    public void ToggleBackgroundBlur(float _blur, float _speed)
    {
        blur_speed = _speed;
        bg_blur_target = _blur;
    }
    
}
