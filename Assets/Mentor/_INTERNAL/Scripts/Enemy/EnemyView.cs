using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private int _enemyHealth;
        [SerializeField] private int _damage;
        
        private bool _isDied = false;

        public Button _button;

        private void Start()
        {
            _button.onClick.AddListener(HandleClick);
            Debug.Log($"Current hp: {_enemyHealth}");
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(HandleClick);
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
                return;
            }

            _enemyHealth -= _damage;
            Debug.Log($"Current hp: {_enemyHealth}");
        }
    }
}