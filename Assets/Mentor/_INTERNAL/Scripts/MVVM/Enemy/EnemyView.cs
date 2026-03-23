using Mentor.MVC.EnemyLogic;
using Mentor.MVVM.BaseMVVM;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mentor.MVVM.Enemy
{
    [RequireComponent(typeof(EnemyAnimations))]
    public class EnemyView : MonoBehaviour, IView, IPointerClickHandler
    {
        [SerializeField] private float _animationsOffDelay = 0.1f;

        private EnemyViewModel _viewModel;
        private EnemyAnimations _animations;

        private Coroutine _animationRoutine;

        private void Start() => _animations = GetComponent<EnemyAnimations>();

        private IEnumerator AnimationsTurnOff()
        {
            yield return new WaitForSeconds(_animationsOffDelay);
            _animations.TurnOffAnimations();
            _animationRoutine = null;
        }

        public void BindViewModel(IViewModel viewModel)
        {
            _viewModel = viewModel as EnemyViewModel;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _viewModel?.EnemyClicked();
            _animations.TurnOnAnimations();
            _animationRoutine = StartCoroutine(AnimationsTurnOff());
        }
    }
}