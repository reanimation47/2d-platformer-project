
using Enum.StageSelect.EnemyTypes;
using System.Collections.Generic;

namespace Common.StageConfiguration
{
    public class StageConfiguration
    {
        //hardcoded for now
        public static int UnlockedIndex = 4;
        public readonly static string UnlockedIndexKey = "382193821391230098";

        //For displaying enemy types in popup window
        public readonly static Dictionary<int, List<EnemyType>> StagesInfo = new Dictionary<int, List<EnemyType>>()
        {
            //Level 1
            {1, new List<EnemyType>() {
                EnemyType.Mushroom} },
            //Level 2
            {2, new List<EnemyType>() {
                EnemyType.RockHead} },
            //Level 3
            {3, new List<EnemyType>() {
                EnemyType.BulletTrunk} },
            //Level 3 extra (endless)
            {3000, new List<EnemyType>() {
                EnemyType.SpikeHead,
                EnemyType.BulletTrunk} }, 
            //Level 4
            {4, new List<EnemyType>() {
                EnemyType.Mushroom} },
            {5, new List<EnemyType>() {
                EnemyType.FatBird,
                EnemyType.RockHead} },
            {6, new List<EnemyType>() {
                EnemyType.BulletTrunk} },
            {7, new List<EnemyType>() {
                EnemyType.BulletTrunk,
                EnemyType.Mushroom} },
            {8, new List<EnemyType>() {
                EnemyType.BulletTrunk,
                EnemyType.Mushroom,
                EnemyType.RockHead} },
            {10, new List<EnemyType>() {
                EnemyType.Mushroom,
                EnemyType.BlueTurtle,
                EnemyType.FatBird,
                EnemyType.ChargeRino,
                EnemyType.TeleGhost,
                EnemyType.BulletTrunk,
                EnemyType.RockHead,
                EnemyType.SpikeHead} },
        };
    }
}
