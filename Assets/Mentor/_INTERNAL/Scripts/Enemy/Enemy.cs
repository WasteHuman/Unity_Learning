using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _enemyHealth;
        [SerializeField] private int _damage;

        [Space(5), Header("Buttons")]
        [SerializeField] private Button _hitButton;
        [SerializeField] private Button _resurrectButton;
        
        private bool _isDied = false;

        private void Start()
        {
            _hitButton.onClick.AddListener(HandleHitButtonClick);
            _resurrectButton.onClick.AddListener(ResurrectEnemy);
            Debug.Log($"Current hp: {_enemyHealth}");
        }

        private void OnDestroy()
        {
            _hitButton.onClick.RemoveListener(HandleHitButtonClick);
            _resurrectButton.onClick.RemoveListener(ResurrectEnemy);
        }

        // Метод воскрешения врага
        private void ResurrectEnemy()
        {
            if (!_isDied)
                return;

            _enemyHealth = _maxHealth;
            _isDied = false;
            Debug.Log("Enemy resurrected");
        }

        private void HandleHitButtonClick()
        {
            if (_isDied)
            {
                Debug.Log("Enemy already die");
                return;
            }

            if (_enemyHealth <= 0)
            {
                _isDied = true;
                Debug.Log("Enemy die");
                return;
            }

            _enemyHealth -= _damage;
            Debug.Log($"Current hp: {_enemyHealth}");
        }
    }
}
