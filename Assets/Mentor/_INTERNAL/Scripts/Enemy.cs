using Mentor.EnemyLogic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mentor
{
    [RequireComponent(typeof(EnemyHealth))]
    [RequireComponent(typeof(EnemyAnimations))]
    public class Enemy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private EnemyAnimations _animations;
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private DamageDealer _damageDealer;

        private void Awake()
        {
            _animations = GetComponent<EnemyAnimations>();
            _health = GetComponent<EnemyHealth>();

            if (_damageDealer == null)
                _damageDealer = FindFirstObjectByType<DamageDealer>();
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