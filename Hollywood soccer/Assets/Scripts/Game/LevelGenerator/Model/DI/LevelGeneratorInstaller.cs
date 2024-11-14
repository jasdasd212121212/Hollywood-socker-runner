using UnityEngine;
using Zenject;

public class LevelGeneratorInstaller : MonoInstaller
{
    [SerializeField] private LevelGeneratorSettings _settings;

    private LevelGeneratorModel _model;

    public override void InstallBindings()
    {
        _model = new LevelGeneratorModel(_settings);

        Container.Bind<LevelGeneratorModel>().FromInstance(_model).AsSingle().NonLazy();
        Container.Bind<IReadOnlyLevelGenerator>().FromInstance(_model).AsSingle().NonLazy();
    }
}