using Mentor.MVC.Common.BaseMVC;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mentor.MVC.EnemyLogic
{
    [RequireComponent(typeof(EnemyAnimations))]
    public class EnemyViewMVC : MonoBehaviour, IPointerDownHandler, IView
    {
        [SerializeField] private EnemyAnimations _animations;
        [SerializeField] private float _animationsOffDelay = 0.1f;

        private Coroutine _animationRoutine;

        public event Action EnemyClicked;

        private void Start()
        {
            _animations = GetComponent<EnemyAnimations>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_animationRoutine != null)
                StopCoroutine(_animationRoutine);

            _animations.TurnOnAnimations();
            EnemyClicked?.Invoke();
            _animationRoutine = StartCoroutine(AnimationsTurnOff());
        }

        private IEnumerator AnimationsTurnOff()
        {
            yield return new WaitForSeconds(_animationsOffDelay);
            _animations.TurnOffAnimations();
            _animationRoutine = null;
        }
    }
}