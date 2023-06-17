using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum.StageSelect.EnemyTypes;
using Common.Extension;

public class StageManager : MonoBehaviour
{
    private int UnlockedIndex = 2; //placeholder for testing, will use PlayPrefs to store this in the future
    public List<StageButton> StageButtons;

    public Dictionary<int, List<EnemyType>> StagesInfo = new Dictionary<int, List<EnemyType>>()
    {
        //Level 1
        {1, new List<EnemyType>() {
            EnemyType.RockHead,
            EnemyType.SpikeHead,
            EnemyType.AngryPig} },
        //Level 2
        {2, new List<EnemyType>() {
            EnemyType.BulletTrunk} },
        //Level 3
        {3, new List<EnemyType>() {
            EnemyType.ChargeRino,
            EnemyType.TeleGhost} },
        //Level 3 extra (endless)
        {3000, new List<EnemyType>() {
            EnemyType.BlueTurtle,
            EnemyType.FatBird,
            EnemyType.ChargeRino,
            EnemyType.TeleGhost,
            EnemyType.BulletTrunk} }, //for extra stage of 3rd stage
        //Level 4
        {4, new List<EnemyType>() {
            EnemyType.TeleGhost,
            EnemyType.BulletTrunk} },
    };

    private void Awake()
    {
        IStage.LoadStageManager(this);
        UnlockedIndex -= 1;
    }

    void Start()
    {
        LoadStageButtons();
        SetupUnlockedStages();
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
        //List<int> _converted_to_int = StagesInfo[index].ConvertAll(x => (int)x); // convert all elements inside a list into int type
        return Extension.ConvertEnemyTypeListToInt(StagesInfo[index]);
    }
}
