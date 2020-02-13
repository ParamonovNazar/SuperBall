using Gameplay.BallMovement;
using Gameplay.Camera;
using PlatformHandles;
using UnityEngine;
using Zenject;

namespace Insallers
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private Platform[] platforms;
        [SerializeField] private CameraController _camera;
        [SerializeField] private LineRoot _lineRoot;
        private GameObject _ball;

        public override void InstallBindings()
        {
            Container.Bind<VerticalsSystem>().AsSingle().NonLazy();
            CreateAndBindBall();
            BindPools();

            Container.Bind<PlatformGenerator>().AsSingle().WithArguments(_ball).NonLazy();
            Container.Bind<LineRoot>().FromInstance(_lineRoot).AsSingle().NonLazy();
        }

        private void CreateAndBindBall()
        {
            var verticalPositions = Container.Resolve<VerticalsSystem>().GetVerticalCentres();

            _ball = Container.InstantiatePrefab(_ballPrefab);
            _ball.transform.position = new Vector3(verticalPositions[1], 0f, 0f);
            Container.Bind<BallVerticalMover>().AsSingle();
            Container.Bind<BallHorizontalMover>().AsSingle();
            _camera.Target = _ball.transform;
        }
        
        
        private void BindPools()
        {

            foreach (var platform in platforms)
            {
                Container.BindMemoryPool<Platform, Platform.Pool>().WithFactoryArguments(platform.PlatformType).FromComponentInNewPrefab(platform)
                    .UnderTransformGroup(platform.PlatformType + "Platforms");
            }

            Container.Bind<PlatformPool>().AsSingle();
        }
    }
}