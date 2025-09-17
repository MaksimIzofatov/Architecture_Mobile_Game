using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State HeroState;
        public WorldData WorldData;

        public PlayerProgress(string levelName)
        {
            WorldData = new(levelName);
            HeroState = new State();
        }
    }
}