using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private int UnlockedIndex = 4; //placeholder for testing, will use PlayPrefs to store this in the future
    public List<StageButton> StageButtons;

    public Dictionary<int, List<int>> StagesInfo = new Dictionary<int, List<int>>()
    {
        {1, new List<int>() {0} },
        {2, new List<int>() {1,2} },
        {3, new List<int>() {2,3} },
        {3000, new List<int>() {0,1,2,3,4} }, //for extra stage of 3rd stage
        {4, new List<int>() {3,4} },
    };

    private void Awake()
    {
        IStage.LoadStageManager(this);
    }

    void Start()
    {
        
        LoadStageButtons();
        SetupUnlockedStages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //custom methods

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
        return StagesInfo[index];
    }
}
