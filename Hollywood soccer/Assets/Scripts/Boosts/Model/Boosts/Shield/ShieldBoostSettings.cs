using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Game design/Player/Boosts/Shield")]
public class ShieldBoostSettings : BaseBoostSettings
{
    protected override Type ProviderType => typeof(ShieldBoost);
}