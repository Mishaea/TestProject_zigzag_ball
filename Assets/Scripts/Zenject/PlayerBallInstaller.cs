using UnityEngine;
using Zenject;

public class PlayerBallInstaller : MonoInstaller
{
    [SerializeField] private GameObject PlayerInstance;

    public override void InstallBindings()
    {
        Container.Bind<PlayerMovement>().FromComponentOn(PlayerInstance).AsSingle();
        Container.Bind<PlayerInput>().FromComponentOn(PlayerInstance).AsSingle();
    }
}