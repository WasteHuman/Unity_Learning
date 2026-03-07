using UnityEngine;

namespace Mentor.EnemyLogic
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float _currentHealth = 0f;
        [SerializeField] private float _maxHealth = 100f;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void ApplyDamage(float damage)
        {
            if(damage < 0)
                return;

            _currentHealth -= damage;
            Debug.Log($"Enemy damaged: Current Health {_currentHealth}/Damage {damage}");
            if (_currentHealth <= 0f)
                _currentHealth = _maxHealth;
        }
    }
}