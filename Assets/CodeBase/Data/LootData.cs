using System;
using CodeBase.Enemy;

namespace CodeBase.Data
{
    [Serializable]
    public class LootData
    {
        public event Action Changed;
        public int Collected;

        public void Collect(Loot loot)
        {
            Collected += loot.Value;
            Changed?.Invoke();
        }
    }
}