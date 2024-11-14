public class LockedGameState : State
{
    private IDirectionInputSystem _playerInputs;
    private SpeedContainer _speedContainer;

    private float _initialSpeed = 0;

    public LockedGameState(IDirectionInputSystem playerInputs, SpeedContainer speedContainer)
    {
        _playerInputs = playerInputs;
        _speedContainer = speedContainer;
    }

    public override void OnEnter()
    {
        _initialSpeed = _speedContainer.Speed;

        _playerInputs.SetActive(false);
        _speedContainer.Speed = 0;
    }

    public override void OnExit()
    {
        _playerInputs.SetActive(true);
        _speedContainer.Speed = _initialSpeed;
    }
}