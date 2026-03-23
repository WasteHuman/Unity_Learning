using UnityEngine;

namespace Mentor.MVC.PlayerLogic
{
    public class DamageDealer
    {
        private readonly float _damageIncreaseMultiplier = 1f;

        private float _damage = 1f;

        public float Damage => _damage;

        public DamageDealer(float damage, float damageIncreaseMultiplier)
        {
            _damage = damage;
            _damageIncreaseMultiplier = damageIncreaseMultiplier;
        }

        public void IncreaseDamage()
        {
            _damage *= _damageIncreaseMultiplier;
            Debug.Log($"Damage has increased, current damage: {_damage}");
        }
    }
}