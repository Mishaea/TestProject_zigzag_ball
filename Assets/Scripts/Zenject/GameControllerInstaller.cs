using UnityEngine;
using Zenject;

public class GameControllerInstaller : MonoInstaller
{
    [SerializeField] private GameController GameController;
    
    public override void InstallBindings()
    {
        Container.Bind<GameController>().FromInstance(GameController).AsSingle();
    }
}