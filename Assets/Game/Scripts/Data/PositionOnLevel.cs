using System;
using System.Numerics;

namespace ZeroCombat.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public string SceneName;
        public Vector3Data Position;

        public PositionOnLevel(string sceneName)
        {
            SceneName = sceneName;
            Position = new Vector3Data(0f, 0f, 0f);
        }

        public PositionOnLevel(string sceneName, Vector3Data position)
        {
            SceneName = sceneName;
            Position = position;
        }
    }
}