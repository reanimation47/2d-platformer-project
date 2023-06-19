using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseController : MonoBehaviour
{
    public void ToggleGroup(bool toggle)
    {
        gameObject.SetActive(toggle);
    }
}
