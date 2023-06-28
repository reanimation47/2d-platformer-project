
using Enum.StageSelect.EnemyTypes;
using System.Collections.Generic;

namespace Common.StageConfiguration
{
    public class StageConfiguration
    {
        //hardcoded for now
        public static int UnlockedIndex = 4; 

        //For displaying enemy types in popup window
        public readonly static Dictionary<int, List<EnemyType>> StagesInfo = new Dictionary<int, List<EnemyType>>()
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
                EnemyType.SpikeHead,
                EnemyType.BulletTrunk} }, 
            //Level 4
            {4, new List<EnemyType>() {
                EnemyType.TeleGhost,
                EnemyType.BulletTrunk} },
        };
    }
}
