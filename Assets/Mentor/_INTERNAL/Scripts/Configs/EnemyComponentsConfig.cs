using UnityEditor;
using UnityEngine;

namespace Mentor.Configs
{
    [CreateAssetMenu(menuName = "Configs/Enemy/Enemy Components Config", fileName = "EnemyComponentsConfig")]
    public class EnemyComponentsConfig : ScriptableObject
    {
        [Header("Health Component Settings")]
        [Range(0f, float.PositiveInfinity)] public float MaxHealth;
        [Range(1f, float.PositiveInfinity)] public float MaxHealthIncreaseMultiplier;
    }
}