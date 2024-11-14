using Zenject;
using UnityEngine;

[RequireComponent(typeof(ZenAutoInjecter))]
public class SpeedUpBoost : BaseBoost
{
    [Inject] private SpeedContainer _speedContainer;

    private SpeedUpBoostSettins _settings;
    private PlayerMover _playerMover;

    protected override void OnSettedUp()
    {
        _settings = Settings as SpeedUpBoostSettins;
        _playerMover = Player.GetComponent<PlayerMover>();
    }

    protected override void OnActivate()
    {
        _playerMover.IncreaseSpeed(_settings.SpeedBoostCoeficient);
        _speedContainer.Speed += _settings.SpeedBoostCoeficient;
    }

    protected override void OnDeactivate()
    {
        _playerMover.DecreaseSpeed(_settings.SpeedBoostCoeficient);
        _speedContainer.Speed -= _settings.SpeedBoostCoeficient;
    }
}