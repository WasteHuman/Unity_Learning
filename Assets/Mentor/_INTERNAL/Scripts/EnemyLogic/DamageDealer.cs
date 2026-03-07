using UnityEngine;

namespace Mentor.EnemyLogic
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private float _damage = 1f;

        public float Damage => _damage;
    }
}