using Mentor.MVC.Common.BaseMVC;
using Mentor.Configs;
using R3;
using UnityEngine;

namespace Mentor.MVC.PlayerLogic
{
    public class PlayerModel : IModel
    {
        private readonly ReactiveProperty<int> _playerLevelChanged = new();

        private readonly DamageDealer _damageDealer;
        private int _playerLevel;

        public int PlayerLevel
        {
            get { return _playerLevel; }
            private set
            {
                _playerLevel = value;
                _playerLevelChanged.Value = _playerLevel;
                Debug.Log($"[Player Model] Player level changed: {_playerLevel}");
            }   
        }

        public Observable<int> PlayerLevelChanged => _playerLevelChanged.AsObservable();

        public PlayerModel(PlayerConfig config)
        {
            _damageDealer = new(config.InitialPlayerDamage, config.PlayerDamageIncrease);
            PlayerLevel = config.InitialPlayerLevel;
        }

        public float GetDamage() => _damageDealer.Damage;

        public void IncreasePlayerDamage() => _damageDealer.IncreaseDamage();

        public void IncreasePlayerLevel() => PlayerLevel++;
    }
}