using Mentor.MVVM.BaseMVVM;
using R3;
using TMPro;
using UnityEngine;

namespace Mentor.MVVM.PlayerLogic
{
    public class PlayerInfoView : MonoBehaviour, IView
    {
        private readonly CompositeDisposable _disposables = new();

        [SerializeField] private TextMeshProUGUI _playerLevelText;

        private PlayerInfoViewModel _viewModel;

        public void BindViewModel(IViewModel viewModel)
        {
            _viewModel = viewModel as PlayerInfoViewModel;

            _viewModel.PlayerLevelChanged.Subscribe(HandlePlayerLevelChanged).AddTo(_disposables);
        }

        private void HandlePlayerLevelChanged(int newLevel)
        {
            _playerLevelText.text = $"Level: {newLevel}";
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}