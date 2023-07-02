using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum.StageSelect.EnemyTypes;
using Common.Extension;
using Common.StageConfiguration;

public class StageManager : MonoBehaviour
{
    private int UnlockedIndex = StageConfiguration.UnlockedIndex;
    public List<StageButton> StageButtons;

    public Dictionary<int, List<EnemyType>> StagesInfo = StageConfiguration.StagesInfo;

    private void Awake()
    {
        IStage.LoadStageManager(this);
        LoadPlayerProgression();
        //UnlockedIndex -= 1;
    }

    void Start()
    {
        LoadStageButtons();
        SetupUnlockedStages();
    }

    //custom methods

    private void LoadPlayerProgression()
    {
        string UnlockedIndexKey = StageConfiguration.UnlockedIndexKey;
        //PlayerPrefs.DeleteKey(UnlockedIndexKey);
        if (PlayerPrefs.HasKey(UnlockedIndexKey))
        {
            UnlockedIndex = PlayerPrefs.GetInt(UnlockedIndexKey);
        }else
        {
            UnlockedIndex = 0;
            PlayerPrefs.SetInt(UnlockedIndexKey, UnlockedIndex);
        }
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


    //public methods for info
    public int GetCurrentUnlockedIndex()
    {
        return UnlockedIndex;
    }

    public List<int> GetIndexedStageEnemyInfo(int index)
    {
        //List<int> _converted_to_int = StagesInfo[index].ConvertAll(x => (int)x); // convert all elements inside a list into int type
        return Extension.ConvertEnemyTypeListToInt(StagesInfo[index]);
    }
}
