using UnityEngine;

namespace Mentor.Configs
{
    [CreateAssetMenu(menuName = "Configs/Player/Player Config", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Range(1f, float.PositiveInfinity)] public float InitialPlayerDamage;
        [Range(0f, float.PositiveInfinity)] public float PlayerDamageIncrease;
    }
}