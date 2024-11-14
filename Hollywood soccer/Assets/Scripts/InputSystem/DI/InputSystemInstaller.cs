using UnityEngine;
using Zenject;

public class InputSystemInstaller : MonoInstaller
{
    [SerializeField] private InputPanelView _panel;

    public override void InstallBindings()
    {
        Container.Bind<IDirectionInputSystem>().FromInstance(new TouchInputSystem(_panel)).AsSingle().Lazy();
    }
}