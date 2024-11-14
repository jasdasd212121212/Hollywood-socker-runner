using UnityEngine;
using Zenject;

public class SpeedContainerInstaller : MonoInstaller
{
    [SerializeField][Min(0.1f)] private float _speed;

    public override void InstallBindings()
    {
        Container.Bind<SpeedContainer>().FromInstance(new SpeedContainer(_speed)).AsSingle().NonLazy();
    }
}