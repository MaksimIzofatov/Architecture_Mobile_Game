using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        public EnemyHealth  Health;
        public EnemyAnimator  Animator;
        
        public GameObject DeathEffect;
        
        public event Action Happened;

        private void Start() => 
            Health.HealthChanged += HealthChanged;

        private void OnDestroy() => 
            Health.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (Health.CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Health.HealthChanged -= HealthChanged;
            
            Animator.PlayDeath();
            
            SpawnDeathFx();
            StartCoroutine(DestroyTimer());
            
            Happened?.Invoke();
        }

        private void SpawnDeathFx() => 
            Instantiate(DeathEffect, transform.position, Quaternion.identity);

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
    }
}