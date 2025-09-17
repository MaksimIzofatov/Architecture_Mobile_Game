using System;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        public HeroHealth Health;
        public HeroMove Move;
        public HeroAnimator Animator;
        
        public GameObject DeathEffect;
        private bool _isDead;

        private void Start()
        {
            Health.HeathChanged += HealthChanged;
        }

        private void OnDestroy()
        {
            Health.HeathChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            if (!_isDead && Health.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
            Move.enabled = false;
            Animator.PlayDeath();

            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }
    }
}