using System;
using System.Collections.Generic;
using Enum.StageSelect.EnemyTypes;

namespace Common.Extension
{
    public static class Extension
    {
        public static List<int> ConvertEnemyTypeListToInt(List<EnemyType> List)
        {
            return List.ConvertAll(x => (int)x);
        }
    }
}
