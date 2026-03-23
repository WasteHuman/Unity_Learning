using UnityEngine;

namespace Mentor.Configs
{
    [CreateAssetMenu(menuName = "Configs/EnemyView/EnemyView Components Config", fileName = "EnemyComponentsConfig")]
    public class EnemyComponentsConfig : ScriptableObject
    {
        [Header("Health Component Settings")]
        [field: SerializeField, Range(0f, 100f)] public float MaxInitialHealth { get; private set; }
        [field: SerializeField, Range(1f, 100f)] public float MaxHealthIncreaseMultiplier { get; private set;  }
    }
}