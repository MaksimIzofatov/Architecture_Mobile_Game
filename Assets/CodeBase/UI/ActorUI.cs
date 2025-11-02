using System;
using System.Reflection.Emit;
using CodeBase.Hero;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        public HPBar HpBar;
        
        private IHealth _health;

        private void Start()
        {
            IHealth _health = GetComponent<IHealth>();
            
            if (_health != null)
                Constructor(_health);
        }

        private void OnDestroy() => 
            _health.HealthChanged -= UpdateHpBar;

        public void Constructor(IHealth heroHealth)
        {
            _health = heroHealth;

            _health.HealthChanged += UpdateHpBar;
        }

        private void UpdateHpBar()
        {
            HpBar.SetValue(_health.CurrentHealth, _health.MaxHealth);
        }
    }
}