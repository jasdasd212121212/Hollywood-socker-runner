public class PlayerInactiveState : State
{
    private PlayerMover _mover;

    public PlayerInactiveState(PlayerMover mover)
    {
        _mover = mover;
    }

    public override void OnEnter()
    {
        _mover.enabled = false;
    }
}