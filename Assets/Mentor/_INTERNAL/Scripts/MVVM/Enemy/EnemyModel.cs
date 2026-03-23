using Mentor.Configs;
using Mentor.MVVM.BaseMVVM;
using Mentor.MVVM.Enemy.Components;
using Mentor.MVVM.PlayerLogic;
using System;
using UnityEngine;

namespace Mentor.MVVM.Enemy
{
    public class EnemyModel : IModel, IDisposable
    {
        private readonly Player _player;
        private readonly HealthComponent _health;

        public EnemyModel(EnemyComponentsConfig config, Player player)
        {
            _player = player;

            _health = new(config.MaxInitialHealth, config.MaxHealthIncreaseMultiplier);

            _health.EnemyDied += HandleEnemyDie;
        }

        public void Dispose() => _health.EnemyDied -= HandleEnemyDie;

        public void ApplyDamage() => _health.ApplyDamage(_player.GetCurrentPlayerDamage());

        private void HandleEnemyDie()
        {
            Debug.Log("[Enemy Model (MVVM)] Enemy die");
            _health.ResurrectEnemy();
            _player.IncreasePlayerDamage();
        }
    }
}