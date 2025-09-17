using System;
using System.Reflection.Emit;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        public HPBar HpBar;
        
        private HeroHealth _heroHealth;

        private void OnDestroy() => 
            _heroHealth.HeathChanged -= UpdateHpBar;

        public void Constructor(HeroHealth heroHealth)
        {
            _heroHealth = heroHealth;

            _heroHealth.HeathChanged += UpdateHpBar;
        }

        private void UpdateHpBar()
        {
            HpBar.SetValue(_heroHealth.Current, _heroHealth.Max);
        }
    }
}