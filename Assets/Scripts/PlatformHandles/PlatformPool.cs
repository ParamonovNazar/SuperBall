using System.Collections.Generic;
using UnityEngine;

namespace PlatformHandles
{
    public class PlatformPool
    {
        private Dictionary<PlatformType, Platform.Pool> _platformPool = new Dictionary<PlatformType, Platform.Pool>();


        public PlatformPool(IEnumerable<Platform.Pool> platformPool)
        {
            foreach (var pool in platformPool)
            {
                if (_platformPool.ContainsKey(pool.PlatformType))
                    _platformPool[pool.PlatformType] = pool;
                else
                    _platformPool.Add(pool.PlatformType, pool);
            }
        }

        public Platform Spawn(PlatformType platformType)
        {
            if (!_platformPool.ContainsKey(platformType))
            {
                throw new UnityException($"The pool with such type: {platformType} does not exist.");
            }

            return _platformPool[platformType].Spawn();
        }

        public void Despawn(Platform platform)
        {
            _platformPool[platform.PlatformType].Despawn(platform);
        }
    }
}