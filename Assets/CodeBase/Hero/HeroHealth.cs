using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroHealth : MonoBehaviour, ISavedProgress
    {
        public event Action HeathChanged;
        
        private State _state;
        
        public HeroAnimator HeroAnimator;
        public float Current
        {
            get => _state.CurrentHealth;
            set
            {
                if (_state.CurrentHealth != value)
                {
                    _state.CurrentHealth = value;

                    HeathChanged?.Invoke();
                }
            }
        }

        public float Max
        {
            get => _state.MaxHealth;
            set => _state.MaxHealth = value;
        }


        public void LoadProgress(PlayerProgress progress)
        {
            _state = progress.HeroState;
            HeathChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.HeroState.CurrentHealth = Current;
            progress.HeroState.MaxHealth = Max;
        }

        public void TakeDamage(float damage)
        {
            if(Current <= 0)
                return;
            
            Current -= damage;
            HeroAnimator.PlayHit();
        }
    }
}