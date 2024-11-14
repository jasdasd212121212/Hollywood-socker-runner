using Zenject;

public class ScoreCounterInstaller : MonoInstaller
{
    [Inject] private IReadOnlyLevelGenerator _levelsGenerator;

    public override void InstallBindings()
    {
        Container.Bind<ScoreCounterModel>().FromInstance(new ScoreCounterModel(_levelsGenerator)).AsSingle().NonLazy();
    }
}