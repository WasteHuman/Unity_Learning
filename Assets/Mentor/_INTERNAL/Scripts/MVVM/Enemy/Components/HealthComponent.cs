using System;
using UnityEngine;

namespace Mentor.MVVM.Enemy.Components
{
    public class HealthComponent
    {
        private readonly float _maxHealthIncreaseMultiplier;

        private float _maxHealth;
        private float _currentHealth;

        public event Action EnemyDied;

        public HealthComponent(float maxHealth, float increaseMultiplier)
        {
            _maxHealth = maxHealth;
            _maxHealthIncreaseMultiplier = increaseMultiplier;

            _currentHealth = maxHealth;
        }

        public void ApplyDamage(float damage)
        {
            if(damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage), "[Enemy/Health Component] Damage cannot be a negative!");

            _currentHealth -= damage;
            Debug.Log($"[Enemy/Health Component] Enemy has damaged by {damage}, Current Health: {_currentHealth}");

            if (CheckDie())
                EnemyDied?.Invoke();
        }

        public void ResurrectEnemy()
        {
            IncreaseMaxHealth();
            _currentHealth = _maxHealth;
            Debug.Log($"[Enemy/Health Component] Enemy was resurrected, Max Health: {_maxHealth}");
        }

        private void IncreaseMaxHealth() => _maxHealth *= _maxHealthIncreaseMultiplier;

        private bool CheckDie()
        {
            if(_currentHealth <= 0)
                return true;

            return false;
        }
    }
}