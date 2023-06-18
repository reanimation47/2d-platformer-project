using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerControlGroup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector] public enum InputType { Left, Right, Jump }

    [SerializeField] private Image img;
    public InputType _input_type;

    private float _left_dir = -1;
    private float _right_dir = 1;

    public void OnPointerDown(PointerEventData e)
    {
        if (_input_type == InputType.Left)
        {
            ICommon.InjectHorizontalInput(_left_dir);
        }else if (_input_type == InputType.Right)
        {
            ICommon.InjectHorizontalInput(_right_dir);
        }else if (_input_type == InputType.Jump)
        {
            ICommon.InjectJumpInput();
        }

    }

    public void OnPointerUp(PointerEventData e)
    {
        if (ICommon.GetPlayerLastInjectedDir() == _left_dir && _input_type == InputType.Left)
        {
            ICommon.InjectHorizontalInput(0);
        }else if (ICommon.GetPlayerLastInjectedDir() == _right_dir && _input_type == InputType.Right)
        {
            ICommon.InjectHorizontalInput(0);
        }else
        {
            //Nothing
        }

    }

    //custom methods
    public void ToggleControl(bool _enable)
    {
        gameObject.SetActive(_enable);
    }
}
