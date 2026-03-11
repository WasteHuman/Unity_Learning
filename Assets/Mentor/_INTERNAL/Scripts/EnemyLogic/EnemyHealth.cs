using System;
using UnityEngine;

namespace Mentor.EnemyLogic
{
    public class EnemyHealth
    {
        private float _maxHealthIncreaseMultiplier;

        private float _currentHealth = 0f;
        private float _maxHealth;

        // Событие, сейчас без него не обойтись, поэтому мы его затронем
        public event Action EnemyDied;

        public EnemyHealth(float maxHealth, float maxHealthIncreaseMultiplier)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            _maxHealthIncreaseMultiplier = maxHealthIncreaseMultiplier;
        }

        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                return;

            _currentHealth -= damage;
            Debug.Log($"Enemy damaged: Current Health {_currentHealth}/Damage {damage}");

            if (_currentHealth <= 0f)
                EnemyRessurection();
        }

        private void EnemyRessurection()
        {
            _maxHealth *= _maxHealthIncreaseMultiplier;

            _currentHealth = _maxHealth;
            EnemyDied?.Invoke();
            Debug.Log($"Enemy ressurected, max health: {_maxHealth}");
        }
    }
}