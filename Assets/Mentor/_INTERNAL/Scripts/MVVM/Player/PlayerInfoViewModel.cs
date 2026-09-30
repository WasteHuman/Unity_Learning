using Mentor.MVVM.BaseMVVM;
using R3;
using System;
using UnityEngine;

namespace Mentor.MVVM.PlayerLogic
{
    public class PlayerInfoViewModel : IViewModel, IDisposable
    {
        private readonly CompositeDisposable _disposables = new();
        private readonly ReactiveProperty<int> _playerLevelChanged = new();

        private int _playerLevel;

        private Player _model;

        public Observable<int> PlayerLevelChanged => _playerLevelChanged.AsObservable();

        public void BindModel(IModel model)
        {
            _model = model as Player;

            _model.PlayerLevelChanged.Subscribe(HandlePlayerLevelChanged).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void HandlePlayerLevelChanged(int newLevel)
        {
            _playerLevel = newLevel;
            _playerLevelChanged.Value = _playerLevel;
            Debug.Log($"[Player Info ViewModel] Player level changed: {_playerLevel}");
        }
    }
}