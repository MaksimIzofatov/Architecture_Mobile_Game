using System;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel;

        public WorldData(string levelName)
        {
            PositionOnLevel = new PositionOnLevel(levelName);
        }
    }
}