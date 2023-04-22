using UnityEngine;
using Zenject;

public class UIManagerInstaller : MonoInstaller
{
    [SerializeField] private UIManager UIManager;

    public override void InstallBindings()
    {
        Container.Bind<UIManager>().FromInstance(UIManager).AsSingle();
    }
}