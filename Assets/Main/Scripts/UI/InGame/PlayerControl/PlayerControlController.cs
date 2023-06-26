using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlController : MonoBehaviour
{
    [SerializeField] private List<PlayerControlGroup> Inputs;

    public void ToggleControls(bool _enable)
    {
        foreach (PlayerControlGroup input in Inputs)
        {
            input.ToggleControl(_enable);
        }
    }
}
