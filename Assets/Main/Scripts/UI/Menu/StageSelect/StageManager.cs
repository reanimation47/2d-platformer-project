using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private int UnlockedIndex = 4; //placeholder for testing, will use PlayPrefs to store this in the future
    public List<StageButton> StageButtons;
    void Start()
    {
        LoadStageButtons();
        SetupUnlockedStages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadStageButtons()
    {
        for (int i = 0; i< transform.childCount; i ++)
        {
            StageButton _stage = transform.GetChild(i).gameObject.transform.Find("State").GetComponent<StageButton>();
            StageButtons.Add(_stage);
        }
    }

    private void SetupUnlockedStages()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i <= UnlockedIndex)
            {
                StageButtons[i].ToggleStageUnlocked(true);
            }else
            {
                StageButtons[i].ToggleStageUnlocked(false);
            }
        }
    }
}
