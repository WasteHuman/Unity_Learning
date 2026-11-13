using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _enemyHealth;
        [SerializeField] private int _damage;
        [SerializeField] private Button _damageButton;
        [SerializeField] private Button _ressurectButton;
        
        private bool _isDied = false;

        private void Start()
        {
            _damageButton.onClick.AddListener(HandleClick);
            _ressurectButton.onClick.AddListener(RessurectEnemy);
            Debug.Log($"Current hp: {_enemyHealth}");
        }

        private void OnDestroy()
        {
            _damageButton.onClick.RemoveListener(HandleClick);
            _ressurectButton.onClick.RemoveListener(RessurectEnemy);
        }

        private void RessurectEnemy()
        {
            if (!_isDied)
                return;

            _enemyHealth = _maxHealth;
            _isDied = false;
            Debug.Log("Enemy ressurected");
        }

        private void HandleClick()
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