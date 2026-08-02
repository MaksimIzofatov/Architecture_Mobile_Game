using TMPro;

namespace CodeBase.UI.Windows
{
    public class ShopWindow : WindowBase
    {
        public TextMeshProUGUI SkullText;
        
        protected override void Initialize()
        {
            RefreshSkullText();
        }

        protected override void SubscribeUpdates()
        {
            PlayerProgress.WorldData.LootData.Changed += RefreshSkullText;
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            PlayerProgress.WorldData.LootData.Changed -= RefreshSkullText;
        }

        private void RefreshSkullText()
        { 
            SkullText.text = PlayerProgress.WorldData.LootData.Collected.ToString();
        }

    }
}