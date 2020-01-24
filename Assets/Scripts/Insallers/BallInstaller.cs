using Dto;
using Gameplay;
using UnityEngine;
using Zenject;

public class BallInstaller : MonoInstaller
{
    [SerializeField] private GameObject _ballGameobject;
    [SerializeField] private PlatformPrefabsDto platformPrefabsDto;
    
    public override void InstallBindings()
    {
        var verticalSystem = new VerticalsSystem();
        Container.Bind<VerticalsSystem>().FromInstance(verticalSystem).AsSingle().NonLazy();
        Container.Bind<BallMover>().FromNewComponentOn(_ballGameobject).AsSingle().WithArguments(verticalSystem.GetVerticalCentres()).NonLazy();
        Container.Bind<PlatformGenerator>().AsSingle().WithArguments(platformPrefabsDto).NonLazy();


    }
}