using Mentor.Configs;
using Mentor.MVVM.BaseMVVM;
using Mentor.MVVM.PlayerLogic.Components;
using R3;
using UnityEngine;

namespace Mentor.MVVM.PlayerLogic
{
    public class Player : IModel
    {
        private readonly ReactiveProperty<int> _playerLevelChanged = new();

        private readonly DamageComponent _damageComponent;
        private int _playerLevel;

        public int PlayerLevel
        {
            get { return _playerLevel; }
            private set
            {
                _playerLevel = value;
                _playerLevelChanged.Value = _playerLevel;
                Debug.Log($"[Player (MVVM)] Player level changed: {_playerLevel}");
            }
        }

        public Observable<int> PlayerLevelChanged => _playerLevelChanged.AsObservable();

        public Player(PlayerConfig config)
        {
            _damageComponent = new(config.PlayerDamageIncrease, config.InitialPlayerDamage);
            PlayerLevel = config.InitialPlayerLevel;
        }

        public float GetCurrentPlayerDamage() => _damageComponent.CurrentDamage;
        public void IncreasePlayerDamage() => _damageComponent.IncreaseDamage();
        public void IncreasePlayerLevel() => PlayerLevel++;
    }
}