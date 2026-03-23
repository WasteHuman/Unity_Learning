using Mentor.MVC.Common.BaseMVC;
using Mentor.Configs;

namespace Mentor.MVC.PlayerLogic
{
    public class PlayerModel : IModel
    {
        private readonly DamageDealer _damageDealer;

        public PlayerModel(PlayerConfig config)
        {
            _damageDealer = new(config.InitialPlayerDamage, config.PlayerDamageIncrease);
        }

        public float GetDamage() => _damageDealer.Damage;

        public void IncreasePlayerDamage() => _damageDealer.IncreaseDamage();
    }
}