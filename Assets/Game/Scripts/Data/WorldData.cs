using System;
using UnityEngine;

namespace ZeroCombat.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel;

        public WorldData(string sceneName)
        {
            PositionOnLevel = new PositionOnLevel(sceneName);
        }
    }
}