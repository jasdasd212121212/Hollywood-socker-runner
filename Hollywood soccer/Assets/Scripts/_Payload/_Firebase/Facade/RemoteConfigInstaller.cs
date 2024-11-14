using Zenject;

public class RemoteConfigInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<RemoteConfigFacade>().FromInstance(new RemoteConfigFacade()).AsSingle().NonLazy();
    }
}