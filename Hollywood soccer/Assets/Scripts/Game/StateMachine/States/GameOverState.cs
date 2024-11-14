public class GameOverState : State
{
    private IDirectionInputSystem _playerInputs;
    private SpeedContainer _speedContainer;

    public GameOverState(IDirectionInputSystem playerInputs, SpeedContainer speedContainer)
    {
        _playerInputs = playerInputs;
        _speedContainer = speedContainer;
    }

    public override void OnEnter()
    {
        _playerInputs.SetActive(false);
        _speedContainer.Speed = 0;
    }
}