using Dto;
using Gameplay.BallMovement;
using Gameplay.Camera;
using UnityEngine;
using Zenject;

namespace Insallers
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private CameraController _camera;
        [SerializeField] private PlatformPrefabsDto platformPrefabsDto;

        public override void InstallBindings()
        {
            Container.Bind<VerticalsSystem>().AsSingle().NonLazy();
            CreateAndBindBall();

            Container.Bind<PlatformGenerator>().AsSingle().WithArguments(platformPrefabsDto).NonLazy();
        }

        private void CreateAndBindBall()
        {
            var verticalPositions = Container.Resolve<VerticalsSystem>().GetVerticalCentres();

            Container.Bind<BallVerticalMover>().AsSingle();
            Container.Bind<BallHorizontalMover>().AsSingle();

            var ball = Container.InstantiatePrefab(_ballPrefab);
            ball.transform.position = new Vector3(verticalPositions[1], 0f, 0f);

            _camera.Target = ball.transform;
        }
    }
}