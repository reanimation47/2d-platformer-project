using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enum.StageSelect.StageIndex
{
    public class StageIndexing : MonoBehaviour
    {
        private static Dictionary<StageIndex, string> SceneDictionary = new Dictionary<StageIndex, string>()
        {
            {StageIndex.Stage1, "Stage01" },
            {StageIndex.Stage2, "Stage02" },
            {StageIndex.Stage3, "Stage03" },
            {StageIndex.Stage4, "Stage04" },
            {StageIndex.Stage5, "Stage05" },
            {StageIndex.Stage6, "Stage06" }
        };
        public static string GetStageAtIndex(int index)
        {
            StageIndex _enum = (StageIndex)index;
            string scenename;
            if (SceneDictionary.TryGetValue(_enum, out scenename))
            {
                return SceneDictionary[_enum];
            }else
            {
                Debug.LogError("Stage index was out of bound, check StageIndexing.cs");
                return "Stage01";
            }
        }
    }
}
