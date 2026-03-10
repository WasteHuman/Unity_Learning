using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mentor
{
    public class Enemy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Move Animation Settings")]
        [SerializeField] private Vector3 _targetScale;
        [SerializeField] private Vector3 _defaultScale = Vector3.one;
        [SerializeField] private float _moveYDistance = 1f;
        [SerializeField] private float _moveYSpeed = 2f;

        [Space(5), Header("Shake Animation Settings")]
        [SerializeField] private float _shakeDuration = 0.25f;
        [SerializeField] private float _shakeMagnitude = 5f;

        private bool _isMoving = false;

        private Vector3 _defaultPosition;
        private Vector3 _targetPosition;

        private Vector3 _startRotation;
        private Coroutine _shakeCoroutine;

        private void Start()
        {
            transform.localScale = _defaultScale;

            _defaultPosition = transform.localPosition;
            _targetPosition = new(_defaultPosition.x, _defaultPosition.y + _moveYDistance);
        }

        private void Update()
        {
            if (_isMoving)
                MoveUp();
            else
                MoveDown();
        }

        private void MoveDown()
        {
            if (Vector3.Distance(transform.localPosition, _defaultPosition) > 0.05f)
            {
                transform.localPosition = Vector3.Lerp( transform.localPosition, _defaultPosition, Time.deltaTime * _moveYSpeed);
            }
        }

        private void MoveUp()
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPosition, Time.deltaTime * _moveYSpeed);

            if (Vector3.Distance(transform.localPosition, _targetPosition) < 0.05f)
                _isMoving = false;
        }

        private void TriggerShake()
        {
            if (_shakeCoroutine != null)
                StopCoroutine(_shakeCoroutine);

            _startRotation = transform.localEulerAngles;
            _shakeCoroutine = StartCoroutine(ShakeRoutine());
        }

        private IEnumerator ShakeRoutine()
        {
            float timer = 0f;

            while (timer < _shakeDuration)
            {
                timer += Time.deltaTime;

                // Вычисляем процент оставшегося времени (от 1 до 0)
                float percentRemaining = 1 - (timer / _shakeDuration);

                // Уменьшаем амплитуду со временем (затухание)
                float currentMagnitude = _shakeMagnitude * percentRemaining;

                // Генерируем случайное отклонение
                float randomX = Random.Range(-currentMagnitude, currentMagnitude);
                float randomZ = Random.Range(-currentMagnitude, currentMagnitude);

                // Применяем вращение (Y обычно не трогаем для 2D/плоской тряски)
                transform.localEulerAngles = _startRotation + new Vector3(randomX, 0, randomZ);

                yield return null;
            }

            // Гарантированно возвращаем исходную позицию (чтобы не было дрейфа)
            transform.localEulerAngles = _startRotation;
            _shakeCoroutine = null;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.localScale = _targetScale;
            _isMoving = true;
            TriggerShake();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.localScale = _defaultScale;
        }
    }
}