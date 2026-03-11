using Mentor.Configs;
using Mentor.EnemyLogic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mentor
{
    [RequireComponent(typeof(EnemyAnimations))]
    public class Enemy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private EnemyAnimations _animations;

        [Space(5), Header("Configs")]
        [SerializeField] private EnemyComponentsConfig _config;
        [SerializeField] private PlayerConfig _playerConfig;

        private EnemyHealth _health;
        private DamageDealer _damageDealer;

        private void Awake()
        {
            _animations = GetComponent<EnemyAnimations>();
            _health = new(_config.MaxHealth, _config.MaxHealthIncreaseMultiplier);
            _health.EnemyDied += HandleEnemyDie;

            _damageDealer = new(_playerConfig.InitialPlayerDamage, _playerConfig.PlayerDamageIncrease);
        }

        private void OnDestroy()
        {
            _health.EnemyDied -= HandleEnemyDie;
        }

        private void HandleEnemyDie()
        {
            _damageDealer.IncreaseDamage();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _animations.TurnOnAnimations();
            _health.ApplyDamage(_damageDealer.Damage);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _animations.TurnOffAnimations();
        }
    }
}