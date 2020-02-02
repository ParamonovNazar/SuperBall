using UnityEngine;

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

        private void SpawnPlatform()
        {
        }
    }
}
