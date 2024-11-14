using UnityEngine;
using Zenject;

public class PlayerStateMachineInstaller : MonoInstaller
{
    [SerializeField] private PlayerStateMachine _player;

    public override void InstallBindings()
    {
        Container.Bind<PlayerStateMachine>().FromInstance(_player).AsSingle().NonLazy();
    }
}