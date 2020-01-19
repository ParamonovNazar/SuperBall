using Gameplay;
using UnityEngine;
using Zenject;

public class BallInstaller : MonoInstaller
{
    [SerializeField] private GameObject _ballGameobject;
    
    public override void InstallBindings()
    {
        var verticalSystem = new VerticalsSystem();
        Container.Bind<VerticalsSystem>().FromInstance(verticalSystem).AsSingle().NonLazy();
        Container.Bind<BallMover>().FromNewComponentOn(_ballGameobject).AsSingle().WithArguments(verticalSystem.GetVerticalCentres()).NonLazy();
    }
}