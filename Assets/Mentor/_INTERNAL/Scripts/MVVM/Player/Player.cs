using Mentor.Configs;
using Mentor.MVVM.PlayerLogic.Components;

namespace Mentor.MVVM.PlayerLogic
{
    public class Player
    {
        private readonly DamageComponent _damageComponent;

        public Player(PlayerConfig config)
        {
            _damageComponent = new(config.PlayerDamageIncrease, config.InitialPlayerDamage);
        }

        public float GetCurrentPlayerDamage() => _damageComponent.CurrentDamage;
        public void IncreasePlayerDamage() => _damageComponent.IncreaseDamage();
    }
}