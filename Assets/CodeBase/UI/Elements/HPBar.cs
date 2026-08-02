using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class HPBar : MonoBehaviour
    {
        public Image HPBarImage;

        
        public void SetValue(float current, float max)
        {
            HPBarImage.fillAmount = current / max;
        }
    }
}