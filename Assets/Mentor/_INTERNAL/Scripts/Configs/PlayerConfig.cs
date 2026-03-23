using UnityEngine;

namespace Mentor.Configs
{
    [CreateAssetMenu(menuName = "Configs/Player/Player Config", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 100f)] public float InitialPlayerDamage { get; private set; }
        [field: SerializeField, Range(0f, 100f)] public float PlayerDamageIncrease { get; private set;  }
    }
}