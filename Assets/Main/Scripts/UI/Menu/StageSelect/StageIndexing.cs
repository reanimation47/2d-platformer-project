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
            {StageIndex.Stage6, "Stage06" },
            {StageIndex.Stage7, "Stage07" },
            {StageIndex.Stage8, "Stage08" }
        };
        private static Dictionary<StageIndex, string> EndlessSceneDictionary = new Dictionary<StageIndex, string>()
        {
            {StageIndex.Stage1, "Stage1000" },
            {StageIndex.Stage2, "Stage2000" },
            {StageIndex.Stage3, "Stage3000"},
            {StageIndex.Stage4, "Stage4000" },
            {StageIndex.Stage5, "Stage5000" },
            {StageIndex.Stage6, "Stage6000" }
        };
        public static string GetStageAtIndex(int index)
        {
            
            var dictionary = index > 999 ? EndlessSceneDictionary : SceneDictionary;
            index = index > 999 ? index / 1000 : index;
            Debug.Log(index);
            StageIndex _enum = (StageIndex)index;
            string scenename;

            if (dictionary.TryGetValue(_enum, out scenename))
            {
                return dictionary[_enum];
            }else
            {
                IStage.LoadCurrentPlayingLevel(1);
                Debug.LogError("Stage index was out of bound, defaulting to the first stage, check StageIndexing.cs for more info");
                return dictionary[(StageIndex)1];
            }
        }
    }
}
