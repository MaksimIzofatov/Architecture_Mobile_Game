using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField]private float _currentHealth;
        [SerializeField]private float _maxHealth;
        public EnemyAnimator  Animator;

        public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
        public float MaxHealth { get => _maxHealth; set  => _maxHealth = value; }

        public event Action HealthChanged;

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            
            Animator.PlayHit();
            
            HealthChanged?.Invoke();
        }
    }
}