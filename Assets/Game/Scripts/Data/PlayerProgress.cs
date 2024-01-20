﻿using System;

namespace ZeroCombat.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;

        public PlayerProgress(string sceneName)
        {
            WorldData = new WorldData(sceneName);
        }
    }
}