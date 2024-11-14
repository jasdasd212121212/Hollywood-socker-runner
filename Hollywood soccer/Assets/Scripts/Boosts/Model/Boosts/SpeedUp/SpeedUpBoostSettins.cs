using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoost", menuName = "Game design/Player/Boosts/Speed")]
public class SpeedUpBoostSettins : BaseBoostSettings
{
    [SerializeField][Min(0)] private float _speedBoostCoeficient;

    public float SpeedBoostCoeficient => _speedBoostCoeficient;

    protected override Type ProviderType => typeof(SpeedUpBoost);
}