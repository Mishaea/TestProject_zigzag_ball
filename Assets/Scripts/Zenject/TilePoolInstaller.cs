using UnityEngine;
using Zenject;

public class TilePoolInstaller : MonoInstaller
{
    [SerializeField] private TilePool TilePool;
    
    public override void InstallBindings()
    {
        Container.Bind<TilePool>().FromInstance(TilePool).AsSingle();
    }
}