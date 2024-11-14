using Zenject;

public class StatsRecorderInstaller : MonoInstaller
{
    [Inject] private ISavingSystem _savingSystem;
    [Inject] private ScoreCounterModel _scoreCounterModel;

    public override void InstallBindings()
    {
        StatsRecorderModel model = new StatsRecorderModel(_scoreCounterModel);
        new UniversalSaver<StatsRecorderDataTransfreObject>(_savingSystem, model, SavingSystemConfig.STATS_SAVE_KEY);

        Container.Bind<StatsRecorderModel>().FromInstance(model).AsSingle().Lazy();
    }
}