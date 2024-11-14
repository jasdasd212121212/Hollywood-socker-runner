public class ShieldBoost : BaseBoost
{
    private IKIllable _player;

    protected override void OnSettedUp()
    {
        _player = Player.GetComponent<IKIllable>();
    }

    protected override void OnActivate()
    {
        _player.SetImmortality(true);
    }

    protected override void OnDeactivate()
    {
        _player.SetImmortality(false);
    }
}