using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel;
        public LootData LootData;

        public WorldData(string levelName)
        {
            LootData = new LootData();
            PositionOnLevel = new PositionOnLevel(levelName);
        }

    }
}