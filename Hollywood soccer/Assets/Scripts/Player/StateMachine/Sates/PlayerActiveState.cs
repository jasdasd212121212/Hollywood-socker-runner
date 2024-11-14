public class PlayerActiveState : State
{
    private PlayerMover _mover;

    public PlayerActiveState(PlayerMover mover)
    {
        _mover = mover;
    }

    public override void OnEnter()
    {
        _mover.enabled = true;
    }
}