using UnityEngine;
using UniRx.Async;

namespace PlatformHandles
{
    public class PlatformGenerator
    {
        private readonly PlatformPool _platformPool;
        private GameObject _mainBall;

        public PlatformGenerator(PlatformPool platformPool, GameObject mainBall)
        {
            _platformPool = platformPool;
            _mainBall = mainBall;
        }

        async UniTask Update()
        {
            while (true)
            {
                await UniTask.DelayFrame(0);
            }
        }


        private void SpawnPlatform()
        {
        }
    }
}