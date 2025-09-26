using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroHealth : MonoBehaviour, ISavedProgress, IHealth
    {
        public event Action HealthChanged;
        
        private State _state;
        
        public HeroAnimator HeroAnimator;
        public float CurrentHealth
        {
            get => _state.CurrentHealth;
            set
            {
                if (_state.CurrentHealth != value)
                {
                    _state.CurrentHealth = value;

                    HealthChanged?.Invoke();
                }
            }
        }

        public float MaxHealth
        {
            get => _state.MaxHealth;
            set => _state.MaxHealth = value;
        }


        public void LoadProgress(PlayerProgress progress)
        {
            _state = progress.HeroState;
            HealthChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.HeroState.CurrentHealth = CurrentHealth;
            progress.HeroState.MaxHealth = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if(CurrentHealth <= 0)
                return;
            
            CurrentHealth -= damage;
            HeroAnimator.PlayHit();
        }
    }
}