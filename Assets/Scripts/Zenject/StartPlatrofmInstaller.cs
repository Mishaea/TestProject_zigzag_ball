using UnityEngine;
using Zenject;

public class StartPlatrofmInstaller : MonoInstaller
{
    [SerializeField] private StartPlatform StartPlatform;

    public override void InstallBindings()
    {
        Container.Bind<StartPlatform>().FromInstance(StartPlatform).AsSingle();
    }
}