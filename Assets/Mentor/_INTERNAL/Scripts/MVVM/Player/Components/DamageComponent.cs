using UnityEngine;

namespace Mentor.MVVM.PlayerLogic.Components
{
    public class DamageComponent
    {
        private readonly float _damageIncreaseMultiplier;

        private float _currentDamage;

        public float CurrentDamage => _currentDamage;

        public DamageComponent(float damageIncreaseMultiplier, float currentDamage)
        {
            _damageIncreaseMultiplier = damageIncreaseMultiplier;
            _currentDamage = currentDamage;
        }

        public void IncreaseDamage()
        {
            _currentDamage *= _damageIncreaseMultiplier;
            Debug.Log($"[PlayerLogic/Damage Component] Damage was increased by {_damageIncreaseMultiplier}, current damage: {_currentDamage}!");
        }
    }
}