using System.Collections;
using System.Collections.Generic;

namespace Enum.StageSelect.StageIndex
{
    public class StageIndexing
    {
        private static Dictionary<StageIndex, string> SceneDictionary = new Dictionary<StageIndex, string>()
        {
            {StageIndex.Stage1, "Stage01" },
            {StageIndex.Stage2, "Stage02" },
            {StageIndex.Stage3, "Stage03" },
            {StageIndex.Stage4, "Stage04" }
        };
        public static string GetStageAtIndex(int index)
        {
            var _enum = (StageIndex)index;
            return SceneDictionary[_enum];
        }
    }
}
