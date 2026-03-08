using System.Collections;
using UnityEngine;

namespace Mentor
{
    public class EnemyAnimations : MonoBehaviour
    {
        [Header("Move Animation Settings")]
        [SerializeField] private Vector3 _targetScale;
        [SerializeField] private Vector3 _defaultScale = Vector3.one;
        [SerializeField] private float _moveYDistance = 1f;
        [SerializeField] private float _moveYSpeed = 2f;

        [Space(5), Header("Shake Animation Settings")]
        [SerializeField] private float _shakeDuration = 0.25f;
        [SerializeField] private float _shakeMagnitude = 5f;

        [Space(5), Header("Color Animation Settigns")]
        [SerializeField] private Color _damagedColor;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private float _fadeDuration = 0.5f;

        private bool _isMoving = false;

        private Vector3 _defaultPosition;
        private Vector3 _targetPosition;

        private Vector3 _startRotation;
        private Coroutine _shakeCoroutine;
        private Coroutine _fadeCoroutine;

        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();

            _defaultColor = _renderer.material.color;
        }

        private void Start()
        {
            transform.localScale = _defaultScale;
            _startRotation = transform.localEulerAngles;

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
                transform.localPosition = Vector3.Lerp(transform.localPosition, _defaultPosition, Time.deltaTime * _moveYSpeed);
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
            
            _shakeCoroutine = StartCoroutine(ShakeRoutine());
        }

        private void TakeDamageVisual()
        {
            if(_fadeCoroutine != null)
                StopCoroutine(_fadeCoroutine);

            _fadeCoroutine = StartCoroutine(FlashColorRoutine());
        }

        private IEnumerator FlashColorRoutine()
        {
            // Применяем цвет дамага на врага
            _renderer.material.color = _damagedColor;

            // Ждём некоторое время, чтобы цвет успел примениться
            yield return new WaitForSeconds(0.1f);

            // Таймер для контроля длительности анимации
            float timer = 0f;

            while(timer < _fadeDuration)
            {
                // Увеличиваем наш таймер, чтобы контролировать длительность анимации
                timer += Time.deltaTime;

                // Вычисляем процент выполнения (в float от 0 до 1 (то есть от 0% до 100%))
                float t = timer / _fadeDuration;

                // Постепенно применяем цвет через интерполяцию
                _renderer.material.color = Color.Lerp(_damagedColor, _defaultColor, t);

                // Возвращаем null, чтобы подождать следующего кадра
                yield return null;
            }

            _renderer.material.color = _defaultColor;

            // Обнуляем корутину в конце анимации
            _fadeCoroutine = null;
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

        public void TurnOnAnimations()
        {
            transform.localScale = _targetScale;
            _isMoving = true;
            TriggerShake();
            TakeDamageVisual();
        }

        public void TurnOffAnimations()
        {
            transform.localScale = _defaultScale;
        }
    }
}