using Mentor.EnemyLogic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mentor
{
    [RequireComponent(typeof(EnemyAnimations))]
    [RequireComponent(typeof(EnemyHealth))]
    public class Enemy : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private EnemyAnimations _animations;
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private DamageDealer _damageDealer;

<<<<<<< HEAD
        [Space(5), Header("Shake Animation Settings")]
        [SerializeField] private float _shakeDuration = 0.25f;
        [SerializeField] private float _shakeMagnitude = 5f;

        private bool _isMoving = false;

        private Vector3 _defaultPosition;
        private Vector3 _targetPosition;

        private Vector3 _startRotation;
        private Coroutine _shakeCoroutine;

        private void Start()
=======
        private void Awake()
>>>>>>> origin/main
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