using Mentor.MVC.Common.BaseMVC;
using Mentor.Configs;
using System;

namespace Mentor.MVC.EnemyLogic
{
    public class EnemyModelMVC : IModel
    {
        private readonly EnemyHealth _healthComponent;

        public event Action EnemyDied;

        public EnemyModelMVC(EnemyComponentsConfig config)
        {
            _healthComponent = new(config.MaxInitialHealth, config.MaxHealthIncreaseMultiplier);
            _healthComponent.EnemyDied += HandleEnemyDie;
        }

        public void Dispose() => _healthComponent.EnemyDied -= HandleEnemyDie;

        private void HandleEnemyDie() => EnemyDied?.Invoke();

        public void ApplyDamage(float damage) => _healthComponent.ApplyDamage(damage);
    }
}