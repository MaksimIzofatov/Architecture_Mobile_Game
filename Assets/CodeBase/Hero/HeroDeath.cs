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
        public HeroAttack Attack;
        
        public GameObject DeathEffect;
        private bool _isDead;

        private void Start()
        {
            Health.HealthChanged += HealthChanged;
        }

        private void OnDestroy()
        {
            Health.HealthChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            if (!_isDead && Health.CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
            Move.enabled = false;
            Attack.enabled = false;
            Animator.PlayDeath();

            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }
    }
}