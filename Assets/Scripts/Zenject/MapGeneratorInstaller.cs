using UnityEngine;
using Zenject;

public class MapGeneratorInstaller : MonoInstaller
{
    [SerializeField] private MapGenerator MapGenerator;

    public override void InstallBindings()
    {
        Container.Bind<MapGenerator>().FromInstance(MapGenerator).AsSingle();
    }
}