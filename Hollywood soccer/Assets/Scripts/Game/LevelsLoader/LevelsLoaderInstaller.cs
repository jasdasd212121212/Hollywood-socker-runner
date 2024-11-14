using UnityEngine;
using Zenject;

public class LevelsLoaderInstaller : MonoInstaller
{
    [SerializeField] private LevelsLoaderSettings _settings;

    [Inject] private ScoreCounterModel _scoreCounterModel;
    [Inject] private StatsRecorderModel _statsRecorderModel;

    public override void InstallBindings()
    {
        Container.Bind<LevelsLoader>().FromInstance(new LevelsLoader(_settings, _scoreCounterModel, _statsRecorderModel)).AsSingle().NonLazy();
    }
}