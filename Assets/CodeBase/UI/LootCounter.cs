using CodeBase.Data;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class LootCounter : MonoBehaviour
    {
         public TextMeshProUGUI CounterText;
         private WorldData _worldData;

         private void Start()
         {
             UpdateCounter();
         }

         public void Constructor(WorldData worldData)
         {
             _worldData = worldData;
             _worldData.LootData.Changed += UpdateCounter;
         }

         private void UpdateCounter()
         {
             CounterText.text = $"{_worldData.LootData.Collected}";
         }
    }
}